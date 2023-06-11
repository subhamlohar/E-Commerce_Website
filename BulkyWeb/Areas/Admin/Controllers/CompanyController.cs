using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SubhamBook.DataAccess.Repository.IRepository;
using SubhamBook.Models;
using SubhamBook.Models.ViewModels;

namespace SubhamBookWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public CompanyController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			
		}

		public IActionResult Index()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return View(objCompanyList);
		}


		[HttpGet]
		public IActionResult Upsert(int? id)
		{
			//ViewBag.Category = CategoryList;
			//ViewData["CategoryList"] = CategoryList;

			
			if (id == null || id == 0)
			{
				//create
				return View(new Company());
			}
			else
			{
				//update
				Company CompanyObj = _unitOfWork.Company.Get(u => u.Id == id);
				return View(CompanyObj);
			}

		}
		[HttpPost]
		public IActionResult Upsert(Company CompanyObj)
		{
			if (ModelState.IsValid)
			{
				if (CompanyObj.Id == 0)
				{
					_unitOfWork.Company.Add(CompanyObj);
					_unitOfWork.Save();
					TempData["success"] = "Company created successfully";
				}
				else
				{
					_unitOfWork.Company.Update(CompanyObj);
					_unitOfWork.Save();
					TempData["success"] = "Company Updated successfully";
				}

				return RedirectToAction("Index");
			}
			else
			{
				return View(CompanyObj);
			}


		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAll()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return Json(new { data = objCompanyList });
		}


		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var CompanyToBeDeleted = _unitOfWork.Company.Get(u => u.Id == id);

			if (CompanyToBeDeleted == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.Company.Remove(CompanyToBeDeleted);
			_unitOfWork.Save();

			return Json(new { success = true, message = "Delete Successful" });



			#endregion



		}
	}
}
