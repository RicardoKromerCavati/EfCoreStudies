
using Core.Entities.Contracts;

namespace Core.Entities
{
	public class Order : IDatabaseEntity
	{		
		public int CustomerId { get; set; }
		public int BookId { get; set; }

		public Customer Customer { get; set; }
		public Book Book { get; set; }
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}