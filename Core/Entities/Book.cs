namespace Core.Entities
{
	public class Book : BaseDatabaseEntity
	{
		public required string Name { get; set; }
		public required string Publisher { get; set; }
		
		public ICollection<Order> Orders { get; set; }
	}
}
