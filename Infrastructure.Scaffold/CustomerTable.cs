using System;
using System.Collections.Generic;

namespace Infrastructure.Scaffold;

public partial class CustomerTable
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual ICollection<OrderTable> OrderTables { get; set; } = new List<OrderTable>();
}
