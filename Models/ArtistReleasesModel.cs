using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SupportBand.Models
{
	[JsonObject(MemberSerialization.OptIn)]
	public class ArtistReleasesModel
	{
		[JsonProperty("pagination")]
		public Pagination Pagination { get; set; }

		[JsonProperty("releases")]
		public List<Release> Releases { get; set; }
	}
}
