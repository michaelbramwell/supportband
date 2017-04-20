using System;
using Newtonsoft.Json;

namespace SupportBand
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ExtraArtist
	{
		[JsonProperty("anv")]
		public string Anv { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("join")]
		public string Join { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("resource_url")]
		public string ResourceUrl { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("tracks")]
		public string Tracks { get; set; }
	}
}
