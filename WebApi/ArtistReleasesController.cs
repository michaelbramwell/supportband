using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using SupportBand.Models;
using SupportBand.Helpers;

namespace SupportBand.Controllers
{
	[Route("api/[controller]")]
	public class ArtistReleasesController : Controller
	{
		readonly ILogger<ArtistReleasesController> _log;

		public ArtistReleasesController(ILogger<ArtistReleasesController> log)
		{
			_log = log;
		}

		[HttpGet("{id}")]
		public async Task<ArtistReleasesModel> Get(long id) 
		{
			using(var client = new HttpClient())
			{
				try
				{
					client.BaseAddress = new Uri("https://api.discogs.com");
					client.DefaultRequestHeaders.Add("user-agent", "SupportBand/0.1");
					client.DefaultRequestHeaders.Add("Authorization", $"Discogs key=kSIMajKbTQuetWWCLwLb, secret=kVNEMiGJEyrbedtgjZuXmxfEWPcYmOHS");

					var response = await client.GetAsync($"/artists/{id}/releases");
					response.EnsureSuccessStatusCode();

					var stringResponse = await response.Content.ReadAsStringAsync();
					var artistReleases = JsonConvert.DeserializeObject<ArtistReleasesModel>(stringResponse);

					_log.LogInformation(Convert.ToInt16(EventCodes.Ok), $"Artist releases {id} was queried");

					return artistReleases;
				}
				catch(HttpRequestException ex)
				{
					_log.LogError(Convert.ToInt16(EventCodes.Error), ex, ex.Message);
					return new ArtistReleasesModel();
				}
			}
		}	
	}
}
