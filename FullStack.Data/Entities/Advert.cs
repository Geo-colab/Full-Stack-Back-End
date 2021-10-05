using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class Advert
    {
        public int Id { get; set; }
        public string AdvertHead { get; set; }
        public string AdvertDetails { get; set; }
        public decimal Price { get; set; }
        public string AdvertState { get; set; }
        
        //foreign key
        public int UserId { get; set; }
        public User User { get; set; }

        //City and Province foreign keys
        public int ProvinceId { get; set; }
        public int CityId { get; set; }

    }
}
