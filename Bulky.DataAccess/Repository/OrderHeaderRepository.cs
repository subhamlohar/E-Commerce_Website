using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SubhamBook.DataAccess.Data;
using SubhamBook.DataAccess.Repository.IRepository;
using SubhamBook.Models;
using Microsoft.EntityFrameworkCore;

namespace SubhamBook.DataAccess.Repository
{
	public class OrderHeaderRepository : Repository<OrderHeader> , IOrderHeaderRepository
	{
		private readonly ApplicationDbContext _db;
		public OrderHeaderRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(OrderHeader obj)
		{
			_db.OrderHeaders.Update(obj);
		}
	}
}
