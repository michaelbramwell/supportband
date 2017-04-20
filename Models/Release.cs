using System;
using Newtonsoft.Json;

namespace SupportBand.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Release
	{
		[JsonProperty("thumb")]
		public string Thumb { get; set; }

		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("main_release")]
		public int MainRelease { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("role")]
		public string Role { get; set; }

		[JsonProperty("year")]
		public int Year { get; set; }

		[JsonProperty("resource_url")]
		public string ResourceUrl { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("label")]
		public string label { get; set; }

		[JsonProperty("trackinfo")]
		public string TrackInfo { get; set; }
	}
}
