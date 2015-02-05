using DemoTD.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTD.Services
{
    public class BookmarkStats
    {
		private readonly ApplicationDbContext db;

		public BookmarkStats(ApplicationDbContext context)
		{
			db = context;
		}

		public async Task<int> GetBookmarksCount()
		{
			return await Task.FromResult(db.Bookmarks.Count());
		}

		public async Task<int> GetTotalHits()
		{
			return await Task.FromResult(
				db.Bookmarks.Sum(b => b.NoOfVisits));
		}
	}
}