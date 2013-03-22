using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MobileRedirect.Framework;
using BestFitBusinessLayer;
using BusinessLMSWeb.Helpers;

namespace BestFitPCBWeb.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {

        public int UserId
        {
            get
            {
                string value = "0";
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("BestPcbInfo");
                HttpCookie fbCookie = Request.Cookies[name];
                if (fbCookie != null) value = fbCookie.Value != null ? crypto.DecryptString(fbCookie.Value) : "0";
                return int.Parse(value);
            }
            set
            {
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("BestPcbInfo");
                HttpCookie fbCookie = new HttpCookie(name);
                fbCookie.Value = crypto.EncryptToString(value.ToString());
                fbCookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(fbCookie);
            }
        }

        public Administrator_siteEntities db = new Administrator_siteEntities();

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
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

        public string FacebookId
        {
            get
            {
                string value = "";
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("fid");
                HttpCookie fbCookie = Request.Cookies[name];
                if (fbCookie != null) value = fbCookie.Value != null ? crypto.DecryptString(fbCookie.Value) : "";
                return value;
            }
            set
            {
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("fid");
                HttpCookie fbCookie = new HttpCookie(name);
                fbCookie.Value = crypto.EncryptToString(value);
                fbCookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(fbCookie);
            }
        }

        public string AccessToken
        {
            get
            {
                string value = "";
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("at");
                HttpCookie fbCookie = Request.Cookies[name];
                if (fbCookie != null)
                    value = fbCookie.Value != null ? crypto.DecryptString(fbCookie.Value) : "";
                return value;
            }
            set
            {
                SimpleAES crypto = new SimpleAES();
                string name = crypto.EncryptToString("at");
                HttpCookie fbCookie = new HttpCookie(name);
                fbCookie.Value = crypto.EncryptToString(value);
                fbCookie.Expires = DateTime.Now.AddDays(365);
                Response.Cookies.Add(fbCookie);
            }
        }

    }
}