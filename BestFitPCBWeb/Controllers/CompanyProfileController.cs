using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BestFitBusinessLayer;

namespace BestFitPCBWeb.Controllers
{
    public class CompanyProfileController : BaseController
    {

        #region General Company Profile

        public ActionResult ProfileList(int id)
        {
            company cmp = db.companies.FirstOrDefault(c => c.companyId == id);
            List<companyProfile> profiles = companyProfile.GetList(cmp.companyId, db);
            ViewBag.profiles = profiles;
            ViewBag.companyName = cmp.companyName;
            ViewBag.companyId = cmp.companyId;
            return PartialView();
        }

        public ActionResult NewProfile(int id)
        {
            companyProfile model = new companyProfile();
            model.companyId = id;
            model.profileName = "Default Name";
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NewProfile(FormCollection collection)
        {
            int companyId; int.TryParse(collection["companyId"], out companyId);
            string profileName = collection["profileName"];

            if (companyProfile.Exists(profileName, companyId, db) == false) 
            {
                companyProfile cmp = new companyProfile();
                cmp.companyId = companyId;
                cmp.profileName = profileName;
                cmp.createDate = DateTime.Now;
                cmp.modifiedDate = DateTime.Now;
                cmp.Save(db);
                return Json(new { success = true, companyId = companyId });
            } 
            else
            {
                return Json(new { success = false, companyId = companyId });
            }            
        }

        public ActionResult EditProfile(int id)
        {
            companyProfile model = companyProfile.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditProfile(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int companyId; int.TryParse(collection["companyId"], out companyId);
            try
            {
                companyProfile cmp = companyProfile.FindById(profileId, db);
                cmp.profileName = collection["profileName"];
                cmp.Update(db);
                return Json(new { success = true, companyId = companyId });
            }
            catch
            {
                return Json(new { success = false, companyId = companyId });
            }
        }

        [HttpPost]
        public ActionResult DeleteProfileAjax(int id)
        {
            companyProfile cmp = companyProfile.FindById(id, db);
            if (cmp.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        /// <summary>
        /// List of all the profile Details
        /// </summary>
        /// <param name="id">profile Id</param>
        /// <returns></returns>
        public ActionResult ProfileDetails(int id)
        {
            String profileName = companyProfile.FindById(id, db).profileName;
            List<arraySpacing> arrayspacings = arraySpacing.GetList(id, db);
            List<panelSpacing> panelspacings = panelSpacing.GetList(id, db);
            List<cupon> cupons = cupon.GetList(id, db);
            List<panelSize> panelsizes = panelSize.GetList(id, db);
            List<panelTooling> paneltoolings = panelTooling.GetList(id, db);
            List<drowingColor> drowingcolors = drowingColor.GetList(id, db);
            ViewBag.profileId = id;
            ViewBag.profileName = profileName;
            ViewBag.arrayspacings = arrayspacings;
            ViewBag.panelspacings = panelspacings;
            ViewBag.cupons = cupons;
            ViewBag.panelsizes = panelsizes;
            ViewBag.paneltoolings = paneltoolings;
            ViewBag.drowingcolors = drowingcolors;
            return PartialView();
        }

        #region Profile Details

        #region Panel Size

        public ActionResult CreatePanelSize(int id)
        {
            panelSize ps = new panelSize();
            ps.profileId = id;
            ps.x = 12;
            ps.y = 18;
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreatePanelSize(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                bool @default = (collection["default"].Split(',')[0] == "true");
                decimal x; decimal.TryParse(collection["x"], out x);
                decimal y; decimal.TryParse(collection["y"], out y);
                panelSize ps = new panelSize();
                ps.profileId = profileId;
                ps.x = x;
                ps.y = y;
                ps.@default = @default;
                ps.Save(db);
                if (ps.@default == true) panelSize.noDefault(ps.panelSizeId, db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId});
            }
        }

        public ActionResult EditPanelSize(int id)
        {
            panelSize model = panelSize.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditPanelSize(FormCollection collection)
        {
            int panelSizeId; int.TryParse(collection["panelSizeId"], out panelSizeId);
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                bool @default = (collection["default"].Split(',')[0] == "true");
                decimal x; decimal.TryParse(collection["x"], out x);
                decimal y; decimal.TryParse(collection["y"], out y);
                panelSize ps = panelSize.FindById(panelSizeId, db);
                ps.x = x;
                ps.y = y;
                ps.@default = @default;
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        [HttpPost]
        public ActionResult DeletePanelSizeAjax(int id)
        {
            panelSize cmp = panelSize.FindById(id, db);
            if (cmp.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        public ActionResult SetDefaultPanelSizeAjax(int id)
        {
            panelSize cmp = panelSize.FindById(id, db);
            cmp.@default = true;
            if (cmp.Update(db) == 1)
            {
                return Json(new { success = true, profileId = cmp.profileId });
            }
            else
            {
                return Json(new { success = false, profileId = 0 });
            }
        }

        #endregion

        #region Panel Spacing

        public ActionResult CreatePanelSpacing(int id)
        {
            panelSpacing ps = new panelSpacing();
            ps.profileId = id;
            ps.panelSpacingName = "PANEL_MARGIN_X";
            ps.min = (decimal)0.0;
            ps.max = (decimal)5.0;
            ps.std = (decimal)1.0;
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreatePanelSpacing(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                string panelSpacingName = collection["panelSpacingName"];
                decimal min; decimal.TryParse(collection["min"], out min);
                decimal max; decimal.TryParse(collection["max"], out max);
                decimal std; decimal.TryParse(collection["max"], out std);
                panelSpacing ps = new panelSpacing();
                ps.profileId = profileId;
                ps.panelSpacingName = panelSpacingName;
                ps.min = min;
                ps.max = max;
                ps.std = std;
                ps.Save(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        public ActionResult EditPanelSpacing(int id)
        {
            panelSpacing model = panelSpacing.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditPanelSpacing(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int panelSpacingId; int.TryParse(collection["panelSpacingId"], out panelSpacingId);
            try
            {
                string panelSpacingName = collection["panelSpacingName"];
                decimal min; decimal.TryParse(collection["min"], out min);
                decimal max; decimal.TryParse(collection["max"], out max);
                decimal std; decimal.TryParse(collection["max"], out std);
                panelSpacing ps = panelSpacing.FindById(panelSpacingId, db);
                ps.panelSpacingName = panelSpacingName;
                ps.min = min;
                ps.max = max;
                ps.std = std;
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        [HttpPost]
        public ActionResult DeletePanelSpacingAjax(int id)
        {
            panelSpacing ps = panelSpacing.FindById(id, db);
            if (ps.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        #region Array Spacing

        public ActionResult CreateArraySpacing(int id)
        {
            arraySpacing ps = new arraySpacing();
            ps.profileId = id;
            ps.arraySpacingName = "BOARD_SPACING_X";
            ps.min = (decimal)0.0;
            ps.max = (decimal)5.0;
            ps.std = (decimal)0.2;
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreateArraySpacing(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                string arraySpacingName = collection["arraySpacingName"];
                decimal min; decimal.TryParse(collection["min"], out min);
                decimal max; decimal.TryParse(collection["max"], out max);
                decimal std; decimal.TryParse(collection["max"], out std);
                arraySpacing ps = new arraySpacing();
                ps.profileId = profileId;
                ps.arraySpacingName = arraySpacingName;
                ps.min = min;
                ps.max = max;
                ps.std = std;
                ps.Save(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        public ActionResult EditArraySpacing(int id)
        {
            arraySpacing model = arraySpacing.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditArraySpacing(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int arraySpacingId; int.TryParse(collection["arraySpacingId"], out arraySpacingId);
            try
            {
                string arraySpacingName = collection["arraySpacingName"];
                decimal min; decimal.TryParse(collection["min"], out min);
                decimal max; decimal.TryParse(collection["max"], out max);
                decimal std; decimal.TryParse(collection["max"], out std);
                arraySpacing ps = arraySpacing.FindById(arraySpacingId, db);
                ps.arraySpacingName = arraySpacingName;
                ps.min = min;
                ps.max = max;
                ps.std = std;
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        [HttpPost]
        public ActionResult DeleteArraySpacingAjax(int id)
        {
            arraySpacing ps = arraySpacing.FindById(id, db);
            if (ps.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        #region Cupons

        public ActionResult CreateCupon(int id)
        {
            cupon ps = new cupon();
            ps.profileId = id;
            ps.cuponName = "AB";
            ps.width = (decimal)1.00;
            ps.height = (decimal)1.00;
            ps.spacing = (decimal)1.00;
            ps.color = "000000";
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreateCupon(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                string cuponName = collection["cuponName"];
                decimal width; decimal.TryParse(collection["width"], out width);
                decimal height; decimal.TryParse(collection["height"], out height);
                decimal spacing; decimal.TryParse(collection["spacing"], out spacing);
                string color = collection["color"];
                cupon ps = new cupon();
                ps.profileId = profileId;
                ps.cuponName = cuponName;
                ps.width = width;
                ps.height = height;
                ps.spacing = spacing;
                ps.color = color;
                ps.Save(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        public ActionResult EditCupon(int id)
        {
            cupon model = cupon.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditCupon(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int cuponId; int.TryParse(collection["cuponId"], out cuponId);
            try
            {

                string cuponName = collection["cuponName"];
                decimal width; decimal.TryParse(collection["width"], out width);
                decimal height; decimal.TryParse(collection["height"], out height);
                decimal spacing; decimal.TryParse(collection["spacing"], out spacing);
                string color = collection["color"];
                cupon ps = cupon.FindById(cuponId, db);
                ps.profileId = profileId;
                ps.cuponName = cuponName;
                ps.width = width;
                ps.height = height;
                ps.spacing = spacing;
                ps.color = color;
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }
        
        [HttpPost]
        public ActionResult DeleteCuponAjax(int id)
        {
            cupon ps = cupon.FindById(id, db);
            if (ps.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        #region Panel Tooling

        public ActionResult CreatePanelTooling(int id)
        {
            panelTooling ps = new panelTooling();
            ps.profileId = id;
            ps.x = "X1+1.000";
            ps.y = "Y1+0.500";
            ps.r = "R0.125";
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreatePanelTooling(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                string x = collection["x"];
                string y = collection["y"];
                string r = collection["r"];
                panelTooling ps = new panelTooling();
                ps.profileId = profileId;
                ps.x = x;
                ps.y = y;
                ps.r = r;
                ps.Save(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        public ActionResult EditPanelTooling(int id)
        {
            panelTooling model = panelTooling.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditPanelTooling(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int panelToolingId; int.TryParse(collection["panelToolingId"], out panelToolingId);
            try
            {

                string x = collection["x"];
                string y = collection["y"];
                string r = collection["r"];
                panelTooling ps = panelTooling.FindById(panelToolingId,db);
                ps.profileId = profileId;
                ps.x = x;
                ps.y = y;
                ps.r = r;
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        [HttpPost]
        public ActionResult DeletePanelToolingAjax(int id)
        {
            panelTooling ps = panelTooling.FindById(id, db);
            if (ps.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        #region Drawing Colors

        public ActionResult CreateDrowingColor(int id)
        {
            drowingColor ps = new drowingColor();
            ps.profileId = id;
            ps.background = "FF0000";
            ps.profile = "00FF00";
            ps.panel = "0000FF";
            ps.margin = "F0F000";
            ps.pcb = "0F0F00";
            ps.tooling = "00F0F0";
            return PartialView(ps);
        }

        [HttpPost]
        public ActionResult CreateDrowingColor(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            try
            {
                string background = collection["background"];
                string profile = collection["profile"];
                string panel = collection["panel"];
                string margin = collection["margin"];
                string pcb = collection["pcb"];
                string tooling = collection["tooling"];
                drowingColor ps = new drowingColor();
                ps.profileId = profileId;
                ps.background = background;
                ps.profile = profile;
                ps.panel = panel;
                ps.margin = margin;
                ps.pcb = pcb;
                ps.tooling = tooling;
                ps.Save(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        public ActionResult EditDrowingColor(int id)
        {
            drowingColor model = drowingColor.FindById(id, db);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult EditDrowingColor(FormCollection collection)
        {
            int profileId; int.TryParse(collection["profileId"], out profileId);
            int drowingId; int.TryParse(collection["drowingId"], out drowingId);
            try
            {
                string background = collection["background"];
                string profile = collection["profile"];
                string panel = collection["panel"];
                string margin = collection["margin"];
                string pcb = collection["pcb"];
                string tooling = collection["tooling"];
                drowingColor ps = drowingColor.FindById(drowingId, db);
                ps.profileId = profileId;
                ps.background = background;
                ps.profile = profile;
                ps.panel = panel;
                ps.margin = margin;
                ps.pcb = pcb;
                ps.tooling = tooling;                
                ps.Update(db);
                return Json(new { success = true, profileId = profileId });
            }
            catch
            {
                return Json(new { success = false, profileId = profileId });
            }
        }

        [HttpPost]
        public ActionResult DeleteDrowingColorAjax(int id)
        {
            drowingColor ps = drowingColor.FindById(id, db);
            if (ps.Delete(db) == 1)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        #endregion

        #endregion

    }
}
