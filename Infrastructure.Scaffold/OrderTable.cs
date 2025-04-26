using System;
using System.Collections.Generic;

namespace Infrastructure.Scaffold;

public partial class OrderTable
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int BookId { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual BookTable Book { get; set; } = null!;

    public virtual CustomerTable Customer { get; set; } = null!;
}
