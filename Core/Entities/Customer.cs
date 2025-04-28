namespace Core.Entities
{
	// [Table("CustomerTable")]
	public class Customer : BaseDatabaseEntity
    {
        // [Required]
        // [Column("Name")]
        public required string Name { get; set; }
		public required string Cpf { get; set; }
        public DateTime BirthDate { get; set; }

		public virtual ICollection<Order> Orders { get; set; } = [];
	}
}