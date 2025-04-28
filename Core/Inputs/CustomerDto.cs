using Core.Entities;

namespace Core.Inputs;

public class CustomerDto
{
	public int Id { get; set; }
	public DateTime CreationDate { get; set; }
	public required string Name { get; set; }
	public required string Cpf { get; set; }
	public DateTime BirthDate { get; set; }

	public ICollection<Order> Orders { get; set; } = [];
}
