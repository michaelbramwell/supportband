using System;
using System.Collections.Generic;

namespace SupportBand.Models
{
	public class Community
	{
		public List<Contributor> contributors { get; set; }
		public string data_quality { get; set; }
		public int have { get; set; }
		public Rating rating { get; set; }
		public string status { get; set; }
		public Submitter submitter { get; set; }
		public int want { get; set; }
	}
}
