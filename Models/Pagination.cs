using System;
using Newtonsoft.Json;

namespace SupportBand.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Pagination
	{
		[JsonProperty("per_page")]
		public int PerPage { get; set; }

		[JsonProperty("items")]
		public int Items { get; set; }

		[JsonProperty("page")]
		public int Page { get; set; }

		[JsonProperty("urls")]
		public Urls Urls { get; set; }

		[JsonProperty("pages")]
		public int Pages { get; set; }
	}
}
