using System;
using System.Collections.Generic;

namespace MasterFloorShurkov.Models;

public partial class Partner
{
    public int Idpartner { get; set; }

    public int? IdpartnerType { get; set; }

    public string? NameOrganization { get; set; }

    public string? Director { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Inn { get; set; }

    public int? Rating { get; set; }

    public virtual PartnerType? IdpartnerTypeNavigation { get; set; }

    public virtual ICollection<PartnerProduct> PartnerProducts { get; set; } = new List<PartnerProduct>();
}
