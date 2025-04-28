using Core.Entities;
using Core.Inputs;
using Core.Models;

namespace Core.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
	EntityResult<CustomerDto> GetOrdersInLastSixMonths(int id);
}
