using Core.Entities;
using Core.Models;

namespace Core.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
	EntityResult<Customer> GetOrdersInLastSixMonths(int id);
}
