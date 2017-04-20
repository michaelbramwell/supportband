using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupportBand.Helpers;

namespace SupportBand.Controllers
{
	[Route("api/[controller]")]
	public class PlaylistController : Controller
	{
		readonly ILogger<PlaylistController> _log;

		public PlaylistController(ILogger<PlaylistController> log)
		{
			_log = log;
		}

		[HttpGet]
		public async Task<string> Get()
		{
			try
			{
				var run = await Run();
				_log.LogInformation(Convert.ToInt16(EventCodes.Ok), $"{run}");
				return run;
			}
			catch (AggregateException ex)
			{
				foreach (var e in ex.InnerExceptions)
				{
					_log.LogError(Convert.ToInt16(EventCodes.Error), ex, ex.Message);
				}

				return "error";
			}
		}

		private async Task<string> Run()
		{
			UserCredential credential;
			using (var stream = new FileStream("client_secrets.json", FileMode.Open, FileAccess.Read))
			{
				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets,
					// This OAuth 2.0 access scope allows for full read/write access to the
					// authenticated user's account.
					new[] { YouTubeService.Scope.Youtube },
					"user",
					CancellationToken.None,
					new FileDataStore(this.GetType().ToString())
				);
			}

			var youtubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = this.GetType().ToString()
			});

			// Create a new, private playlist in the authorized user's channel.
			var newPlaylist = new Playlist();
			newPlaylist.Snippet = new PlaylistSnippet();
			newPlaylist.Snippet.Title = "Test Playlist";
			newPlaylist.Snippet.Description = "A playlist created with the YouTube API v3";
			newPlaylist.Status = new PlaylistStatus();
			newPlaylist.Status.PrivacyStatus = "public";
			   
			newPlaylist = await youtubeService.Playlists.Insert(newPlaylist, "snippet,status").ExecuteAsync();

			// Add a video to the newly created playlist.
			var newPlaylistItem = new PlaylistItem();
			newPlaylistItem.Snippet = new PlaylistItemSnippet();
			newPlaylistItem.Snippet.PlaylistId = newPlaylist.Id;
			newPlaylistItem.Snippet.ResourceId = new ResourceId();
			newPlaylistItem.Snippet.ResourceId.Kind = "youtube#video";
			newPlaylistItem.Snippet.ResourceId.VideoId = "GNRMeaz6QRI";
			newPlaylistItem = await youtubeService.PlaylistItems.Insert(newPlaylistItem, "snippet").ExecuteAsync();

			return $"Playlist item id {newPlaylistItem.Id} was added to playlist id {newPlaylist.Id}.";
		}
	}
}
