using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using DemoTD.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoTD.Controllers.Controllers
{
    [Route("api/[controller]")]
    public class BookmarksAPIController : Controller
    {
		//private properties
		private readonly ApplicationDbContext db;

		//inject the data context to the API controller
		public BookmarksAPIController(ApplicationDbContext context)
		{
			//save the reference in controller
			db = context;
		}

        // GET: api/values
        [HttpGet]
		[Produces("Application/xml")]
        public IEnumerable<Bookmark> Get()
        {
			return db.Bookmarks.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


		//add the dispose code
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}
