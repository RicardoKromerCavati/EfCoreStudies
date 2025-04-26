using Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace SampleStoreApi.Controllers
{
	[ApiController]
	[Route("/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		[HttpGet("orders-in-last-six-months/{id:int}")]
		public IActionResult Get([FromRoute] int id)
		{
			try
			{
				var customerResult
					= _customerRepository.GetOrdersInLastSixMonths(id);

				if (customerResult.IsSuccess is false)
				{
					return NotFound(customerResult.ErrorMessage);
				}

				return Ok(customerResult.Entity);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
