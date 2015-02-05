using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;

namespace DemoTD.Controllers
{
    public class HomeController
    {
		[Activate]
		public ActionContext ActionContext { get; set; }

		[Activate]
		public ViewDataDictionary ViewData { get; set; }

		public IActionResult Index()
        {
            return new ViewResult(){ ViewName = ActionContext.ActionDescriptor.Name };
        }

		public IActionResult About()
		{
			ViewData["Message"] = WebMessaging.WebMessage.GetMessage();//"Your application description page.";

			return new ViewResult() {
				ViewName = ActionContext.ActionDescriptor.Name,
				ViewData = ViewData
			};
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return new ViewResult()
			{
				ViewName = ActionContext.ActionDescriptor.Name,
				ViewData = ViewData
			};
		}

		public IActionResult Error()
		{
			return new ViewResult() { ViewName = "~/Views/Shared/Error.cshtml" };
		}
	}
}