using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class ProductType
{
    public int IdproductType { get; set; }

    public string? TypeName { get; set; }

    public double? Coefficient { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
