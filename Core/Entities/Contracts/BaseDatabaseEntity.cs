namespace Core.Entities.Contracts
{
	public class BaseDatabaseEntity
	{
		// [Key]
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
