using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subham.Models;
using SubhamBook.Models;

namespace SubhamBook.DataAccess.Repository.IRepository
{
	public interface IShoppingCartRepository : IRepository<ShoppingCart>
	{
		void Update(ShoppingCart obj);
		
	}
}
