using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BestFitPCBWeb.Controllers
{
    public class PanelController : BaseController
    {

        public ActionResult NewPanel()
        {

            Guid id = Guid.NewGuid();
            String path = HttpContext.Server.MapPath("~/Media");
            path = String.Concat(path, "\\", id.ToString(), ".jpg");

            Bitmap bmp = new Bitmap(500, 800, PixelFormat.Format24bppRgb);
            Graphics img = Graphics.FromImage(bmp);

            img.DrawRectangle(Pens.Red, 10, 20, 500 - 10, 800 - 20);
            bmp.Save(path, ImageFormat.Jpeg);

            img.Dispose();
            bmp.Dispose();

            ViewBag.ImageName = String.Concat(id.ToString(), ".jpg");

            return View();
        }

    }
}
