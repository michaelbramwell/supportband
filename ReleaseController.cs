using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using SupportBand.Models;

namespace SupportBand.Controllers
{
	[Route("api/[controller]")]
	public class ReleaseController : Controller
	{
		readonly ILogger<ReleaseController> _log;

		public ReleaseController(ILogger<ReleaseController> log)
		{
			_log = log;
		}

		[HttpGet("{id}")]
		public async Task<ReleaseModel> Get(long id) 
		{
			using(var client = new HttpClient())
			{
				try
				{
					client.BaseAddress = new Uri("https://api.discogs.com");
					client.DefaultRequestHeaders.Add("user-agent", "SupportBand/0.1");
					client.DefaultRequestHeaders.Add("Authorization", $"Discogs key=kSIMajKbTQuetWWCLwLb, secret=kVNEMiGJEyrbedtgjZuXmxfEWPcYmOHS");

					var response = await client.GetAsync($"/releases/{id}");
					response.EnsureSuccessStatusCode();

					var stringResponse = await response.Content.ReadAsStringAsync();
					var release = JsonConvert.DeserializeObject<ReleaseModel>(stringResponse);

					_log.LogInformation(2, $"Release {release.Id} was queried");

					return release;
				}
				catch(HttpRequestException ex)
				{
					_log.LogError(1, ex, ex.Message);
					return new ReleaseModel();
				}
			}
		}	
	}
}
