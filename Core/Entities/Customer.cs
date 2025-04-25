namespace Core.Entities
{
    // [Table("CustomerTable")]
    public class Customer : BaseDatabaseEntity
    {
        // [Required]
        // [Column("Name")]
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}