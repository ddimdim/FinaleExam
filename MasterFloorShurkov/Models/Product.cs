using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class Product
{
    public int Articul { get; set; }

    public int? IdproductType { get; set; }

    public int? IdmaterialType { get; set; }

    public string? NameProduct { get; set; }

    public double? MinPriceForPartner { get; set; }

    public virtual MaterialType? IdmaterialTypeNavigation { get; set; }

    public virtual ProductType? IdproductTypeNavigation { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
