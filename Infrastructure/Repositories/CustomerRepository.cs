using Core.Entities;
using Core.Inputs;
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

		public EntityResult<CustomerDto> GetOrdersInLastSixMonths(int id)
		{
			//_dbSet
			//	.Include(customer => customer.Orders)
			//	.ThenInclude(order => order.Book)
			//	.FirstOrDefault(customer => customer.Id == id);

			var customer =
				_applicationDbContext.Customers
				.FirstOrDefault(customer => customer.Id == id);

			if (customer is null)
			{
				return EntityResult<CustomerDto>.CreateErrorResult("Could not find customer");
			}

			var customerDto = new CustomerDto
			{
				Id = customer.Id,
				Cpf = customer.Cpf,
				BirthDate = customer.BirthDate,
				CreationDate = customer.CreationDate,
				Name = customer.Name,
				Orders = customer.Orders.Where(cutomer => cutomer.CreationDate >= DateTime.Now.AddMonths(-6))
				.Select(order =>
				{
					order.Customer = null;
					order.Book.Orders = null;
					return order;
				})
				.ToList()
			};

			return EntityResult<CustomerDto>.CreateSuccessfulResult(customerDto);
		}
	}
}
