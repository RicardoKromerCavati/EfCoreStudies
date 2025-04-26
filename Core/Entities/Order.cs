namespace Core.Entities
{
	public class Order : BaseDatabaseEntity
	{		
		public int CustomerId { get; set; }
		public int BookId { get; set; }

		public Customer Customer { get; set; }
		public Book Book { get; set; }
	}
}