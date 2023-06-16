using SubhamBook.DataAccess.Repository.IRepository;
using SubhamBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubhamBook.DataAccess.Repository.IRepository
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
	}
}