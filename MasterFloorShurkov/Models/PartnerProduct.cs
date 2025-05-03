using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class PartnerProduct
{
    public int IdpartnerProduct { get; set; }

    public int? Articul { get; set; }

    public int? Idpartner { get; set; }

    public int? Count { get; set; }

    public DateOnly? DateOfSale { get; set; }

    public virtual Product? ArticulNavigation { get; set; }

    public virtual Partner? IdpartnerNavigation { get; set; }
}
