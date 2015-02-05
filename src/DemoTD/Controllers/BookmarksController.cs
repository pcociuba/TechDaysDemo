using DemoTD.Models;
using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoTD.Controllers
{
    public class BookmarksController : Controller
    {
		//priavte variables
		private readonly ApplicationDbContext db;


		//inject the DB context into the constructor
		public BookmarksController(ApplicationDbContext context)
		{
			//transfer the reference to the context
			db = context;
		}

		// GET: /<controller>/
		public IActionResult Index()
		{
			var bookmarks = db.Bookmarks.ToList();

			return View(bookmarks);
		}


		// GET: api/bookmarks/list
		[HttpGet]
		[Route("api/[controller]/list")]
		[Produces("Application/xml")]
		public IEnumerable<Bookmark> Get()
		{
			return db.Bookmarks.ToList();
		}


		#region Create Actions

		public IActionResult Create()
		{
			//return the create
			return View();
		}


		[HttpPost]
		public IActionResult Create(Bookmark model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			//add to the dabase
			db.Bookmarks.Add(model);
			db.SaveChanges();

			return RedirectToAction("Index");
		}

		#endregion

		#region Delete Action

		public IActionResult Delete(int? id)
		{
			//attempt to retrieve the id
			if (id != null)
			{
				//retrieve a bookmark with the given ID
				Bookmark selectedBookmark = db.Bookmarks.FirstOrDefault(b => b.Id == id);
				db.Bookmarks.Remove(selectedBookmark);

				//save the changes
				db.SaveChanges();
			}

			//just redirect back to index
			return RedirectToAction("Index");
		}

		#endregion


		[HttpGet]
		public IActionResult Details(int? id)
		{
			//attempt to retrieve the id
			if (id != null)
			{
				//retrieve a bookmark with the given ID
				Bookmark selectedBookmark = db.Bookmarks.FirstOrDefault(b => b.Id == id);

				return View(selectedBookmark);
			}
			else
			{
				//just redirect back to index
				return RedirectToAction("Index");
			}
		}


		public IActionResult Visit(int? id)
		{
			//attempt to retrieve the id
			if (id != null)
			{
				//retrieve a bookmark with the given ID
				Bookmark selectedBookmark = db.Bookmarks.FirstOrDefault(b => b.Id == id);

				//add a hit to the bookmark
				selectedBookmark.NoOfVisits = selectedBookmark.NoOfVisits + 1;
				db.SaveChanges();

				return new RedirectResult(selectedBookmark.Url);
			}
			else
			{
				//just redirect back to index
				return RedirectToAction("Index");
			}
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
