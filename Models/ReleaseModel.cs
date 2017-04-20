using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SupportBand.Models
{
	
	[JsonObject(MemberSerialization.OptIn)]
	public class ReleaseModel
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		public List<Artist> artists { get; set; }
		public string data_quality { get; set; }
		public string thumb { get; set; }
		public Community community { get; set; }
		public List<Company> companies { get; set; }
		public string country { get; set; }
		public string date_added { get; set; }
		public string date_changed { get; set; }
		public int estimated_weight { get; set; }

		[JsonProperty("extraartists")]
		public List<ExtraArtist> ExtraArtists { get; set; }

		public int format_quantity { get; set; }
		public List<Format> formats { get; set; }
		public List<string> genres { get; set; }
		public List<Identifier> identifiers { get; set; }
		public List<Image> images { get; set; }
		public List<Label> labels { get; set; }
		public double lowest_price { get; set; }
		public int master_id { get; set; }
		public string master_url { get; set; }
		public string notes { get; set; }
		public int num_for_sale { get; set; }
		public string released { get; set; }
		public string released_formatted { get; set; }
		public string resource_url { get; set; }
		public List<object> series { get; set; }
		public string status { get; set; }
		public List<string> styles { get; set; }
		public List<Tracklist> tracklist { get; set; }
		public string uri { get; set; }

		[JsonProperty("videos")]
		public List<Video> Videos { get; set; }

		public int year { get; set; }
	}
}
