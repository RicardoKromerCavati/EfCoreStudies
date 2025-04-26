using Core.Entities.Contracts;

namespace Core.Entities
{
	// [Table("CustomerTable")]
	public class Customer : IDatabaseEntity
    {
        // [Required]
        // [Column("Name")]
        public required string Name { get; set; }
		public required string Cpf { get; set; }
        public DateTime BirthDate { get; set; }

		public ICollection<Order> Orders { get; set; }
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }
	}
}