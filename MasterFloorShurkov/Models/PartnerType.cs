using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class PartnerType
{
    public int IdpartnerType { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Partner> Partners { get; set; } = new List<Partner>();
}
