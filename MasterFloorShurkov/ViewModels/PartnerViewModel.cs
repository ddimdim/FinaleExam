using MasterFloorShurkov.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterFloorShurkov.ViewModels
{
    public class PartnerViewModel
    {
        public Partner Model { get;}
        public string TypeName { get; set; }
        public string NameOrganization { get; set; }
        public string Director { get; set; }
        public string PhoneNumber { get; set; }
        public int? Rating { get; set; }
        public int? TotalSale { get; set; }
        public string Discount => $"{PartnerDiscount( )}%";
        public PartnerViewModel (Partner partner, int? totalSale)
        {
            Model = partner;
            TypeName = partner.IdpartnerTypeNavigation.TypeName;
            NameOrganization = partner.NameOrganization;
            Director = partner.Director;
            PhoneNumber = "+7 " + partner.PhoneNumber;
            Rating = partner.Rating;
            TotalSale = totalSale;
        }
        public int PartnerDiscount ()
        {
            if (TotalSale < 10000) return 0;
            if (TotalSale < 50000) return 5;
            if (TotalSale < 300000) return 10;
            else return 15;
        }


    }
}
