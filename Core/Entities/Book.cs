
using Core.Entities.Contracts;

namespace Core.Entities
{
	public class Book : IDatabaseEntity
	{
		public required string Name { get; set; }
		public required string Publisher { get; set; }
		
		public ICollection<Order> Orders { get; set; }
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
