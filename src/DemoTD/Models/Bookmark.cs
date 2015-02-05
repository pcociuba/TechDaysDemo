using Microsoft.AspNet.Mvc;
using System;

namespace DemoTD.Models
{
    public class Bookmark
    {
		public int Id { get; set; }

		[FromForm]
		public string Title { get; set; }

		[FromForm]
		public string Url { get; set; }

		[FromForm]
		public string Description { get; set; }

		[FromQuery]
		public int NoOfVisits { get; set; }

		[FromHeader]
		public string Accept { get; set; }
	}
}