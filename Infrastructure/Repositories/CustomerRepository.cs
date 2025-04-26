using Core.Entities;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
	{
		public CustomerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
		{
		}

		public EntityResult<Customer> GetOrdersInLastSixMonths(int id)
		{
			//_dbSet
			//	.Include(customer => customer.Orders)
			//	.ThenInclude(order => order.Book)
			//	.FirstOrDefault(customer => customer.Id == id);

			var customer =
				_applicationDbContext.Customers
				.Include(customer => customer.Orders)
				.ThenInclude(order => order.Book)
				.FirstOrDefault(customer => customer.Id == id);

			if (customer is null)
			{
				return EntityResult<Customer>.CreateErrorResult("Could not find customer");
			}

			customer.Orders = customer.Orders
				.Where(cutomer => cutomer.CreationDate >= DateTime.Now.AddMonths(-6))
				.Select(order =>
				{
					order.Customer = null;
					order.Book.Orders = null;
					return order;
				})
				.ToList();

			return EntityResult<Customer>.CreateSuccessfulResult(customer);
		}
	}
}
