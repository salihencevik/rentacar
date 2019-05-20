using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Entity
{
    public class CarBlog
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string MaksSpeed { get; set; }
        public string Gear { get; set; }
        public string image { get; set; }
        public string TenantScore { get; set; }
        public string explanation { get; set; }
        public string Detailimage { get; set; }
    }
}