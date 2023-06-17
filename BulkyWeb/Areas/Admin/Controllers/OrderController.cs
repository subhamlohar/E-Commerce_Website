using System.Diagnostics;
using Bulky.Utility;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using SubhamBook.DataAccess.Repository.IRepository;
using SubhamBook.Models;

namespace SubhamBookWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OrderController : Controller
	{

		private readonly IUnitOfWork _unitOfWork;

		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			return View();
		}

		#region API CALLS

		[HttpGet]
		public IActionResult GetAll(string status)
		{
			IEnumerable<OrderHeader> objOrderHeaders = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser").ToList();
			

			switch (status)
			{
				case "pending":
					objOrderHeaders = objOrderHeaders.Where(u => u.PaymentStatus == SD.PaymentStatusForDelayedPayment);
					break;
				case "inprocess":
					objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusProcessing);
					break;
				case "completed":
					objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusShipped);
					break;
				case "approved":
					objOrderHeaders = objOrderHeaders.Where(u => u.OrderStatus == SD.StatusApproved);
					break;
				default:
					break;
			}
			return Json(new { data=objOrderHeaders });

		} 


		#endregion
	}
}
