using BestFitBusinessLayer.Models;
using BestFitPCBWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BestFitPCBWeb.Controllers
{

	public class CompanyController : BaseController
	{

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult CreateCompany()
		{
			int someUSer = UserId;
			return View();
		}

		[HttpPost]
		public ActionResult CreateCompany(CreateCompanyModel model)
		{
			if (ModelState.IsValid)
			{
				if (company.Exists(model.companyName, db) == false)
				{
					company cmp = new company();
					cmp.companyName = model.companyName;
					cmp.companyEmail = model.companyEmail;
					cmp.companyPhone = model.companyPhone;
					if (cmp.Save(db) == 1)
					{
						ViewBag.success = true;
						ViewBag.Message = "Saved Successfully";
					}
					else
					{
						ViewBag.success = false;
						ViewBag.Message = "There was an issue please try again latter.";
					}
					companyUser cmpUsr = new companyUser();
					cmpUsr.companyId = cmp.companyId;
					cmpUsr.userId = UserId;
					cmpUsr.admin = true;
					cmpUsr.deleted = false;
					cmpUsr.Save(db);

				}
				else
				{
					ViewBag.success = false;
					ViewBag.Message = "The Company Already Exist.";
				}
			}
			return View(model);
		}

		public ActionResult EditCompany(int companyId = 0)
		{
			company cmp = db.companies.FirstOrDefault(c => c.companyId == companyId);
			return View(cmp);
		}

		[HttpPost]
		public ActionResult EditCompany(company model)
		{
			if (ModelState.IsValid)
			{
				company cmp = db.companies.FirstOrDefault(c => c.companyId == model.companyId);
				cmp.companyName = model.companyName;
				cmp.companyPhone = model.companyPhone;
				cmp.companyEmail = model.companyEmail;
				if (cmp.Update(db) == 1)
				{
					ViewBag.success = true;
					ViewBag.Message = "Saved Successfully";
				}
				else
				{
					ViewBag.success = false;
					ViewBag.Message = "There was an issue please try again latter.";
				}
			}
			return View(model);
		}

		[HttpPost]
		public ActionResult DeleteCompany(int companyId)
		{
			company cmp = db.companies.FirstOrDefault(c => c.companyId == companyId);
			cmp.Delete(db);
			return RedirectToAction("CompanyList", "Company");
		}

		[HttpPost]
		public ActionResult DeleteCompanyAjax(int companyId)
		{
			try
			{
				company cmp = db.companies.FirstOrDefault(c => c.companyId == companyId);
				cmp.Delete(db);
				return Json(new { success = true });
			}
			catch
			{
				return Json(new { success = false });
			}
		}

		public ActionResult CompanyList()
		{
			List<company> companies = company.GetList(UserId, db);
			return View(companies);
		}

		public ActionResult CompanyUserList()
		{
			List<company> companies = company.GetList(UserId, db);
			return View(companies);
		}

		public ActionResult UserList(int id)
		{
			string companyName = company.FindById(id, db).companyName;
			ViewBag.companyName = companyName;
			ViewBag.companyId = id;
			Dictionary<BestFitBusinessLayer.Models.UserProfile, bool> users = (from usr in db.UserProfiles
																			   join cmpusr in db.companyUsers
																				   on usr.UserId equals cmpusr.userId
																			   where cmpusr.companyId == id
																			   select new { user = usr, isAdmin = cmpusr.admin }).ToDictionary(item => item.user, item => item.isAdmin);
			return PartialView(users);
		}

		[HttpGet]
		public ActionResult SearchUser(string term)
		{
			List<searchObject> userNames = (from usr in db.UserProfiles
											where usr.UserName.Contains(term) || usr.Email.Contains(term)
											select new searchObject { label = usr.UserName, value = usr.UserId }).ToList();
			return Json(userNames, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public ActionResult AddCompanyUserAjax(int usrId, int cmpId)
		{
			try
			{
				companyUser cmpUsr = new companyUser();
				cmpUsr.companyId = cmpId;
				cmpUsr.userId = usrId;
				cmpUsr.Save(db);
				return Json(new { success = true });
			}
			catch
			{
				return Json(new { success = false });
			}
		}

		[HttpPost]
		public ActionResult SetAdminUserAjax(int usrId, int cmpId)
		{
			try
			{
				companyUser cmpUsr = companyUser.FindById(cmpId, usrId, db);
				cmpUsr.admin = !cmpUsr.admin;
				cmpUsr.Update(db);
				return Json(new { success = true });
			}
			catch
			{
				return Json(new { success = false });
			}
		}

		[HttpPost]
		public ActionResult DeleteCompanyUserAjax(int usrId, int cmpId)
		{
			try
			{
				companyUser cmpUsr = companyUser.FindById(cmpId, usrId, db);
				cmpUsr.Delete(db);
				return Json(new { success = true });
			}
			catch
			{
				return Json(new { success = false });
			}
		}

	}
}
