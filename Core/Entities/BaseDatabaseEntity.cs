namespace Core.Entities
{
	public class BaseDatabaseEntity
	{
		// [Key]
		public int Id { get; set; }
		public DateTime CreationDate { get; set; } = DateTime.Now;
	}
}
