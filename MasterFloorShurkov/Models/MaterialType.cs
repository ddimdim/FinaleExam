using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class MaterialType
{
    public int IdmaterialType { get; set; }

    public string? TypeName { get; set; }

    public double? DefectRate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
