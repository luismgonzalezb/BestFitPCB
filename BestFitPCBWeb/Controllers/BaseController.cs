using BestFitBusinessLayer.Models;
using MobileRedirect.Framework;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BestFitPCBWeb.Controllers
{

	[Authorize]
	public class BaseController : Controller
	{

		public int UserId { get { return WebSecurity.CurrentUserId; } }

		public BestFitPCBContext db = new BestFitPCBContext();

		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			String actionName = filterContext.ActionDescriptor.ActionName;
			if (actionName != "_ProductCuponView")
			{
				#region Browser Detection
				try
				{
					List<string> phoneAgents = new List<string>() { "ipod", "iphone", "android 2", "blackberry", "opera mobi", "windows phone" };
					MobileRedirectUtility mru = new MobileRedirectUtility(phoneAgents);
					if (mru.IsPhone())
					{
						filterContext.Result = RedirectToAction("index", "Mobile");
					}
				}
				catch { }
				#endregion
			}
			base.OnActionExecuted(filterContext);
		}
	}
}