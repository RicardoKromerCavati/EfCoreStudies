namespace Core.Entities
{
	public class Order : BaseDatabaseEntity
	{		
		public int CustomerId { get; set; }
		public int BookId { get; set; }

		public virtual Customer Customer { get; set; }
		public virtual Book Book { get; set; }
	}
}