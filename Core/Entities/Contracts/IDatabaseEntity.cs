namespace Core.Entities.Contracts
{
	public interface IDatabaseEntity
	{
		// [Key]
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}
