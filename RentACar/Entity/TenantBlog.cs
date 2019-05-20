using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Entity
{
    public class TenantBlog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public string BuyAdress { get; set; }
        public string ReturnAdress { get; set; }
        public int? RolesId { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Cars { get; set; }
        public int? DayCount { get; set; }
    }
}