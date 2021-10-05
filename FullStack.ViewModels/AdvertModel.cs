using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.ViewModels
{
    public class AdvertModel
    {
        public int Id { get; set; }
        public string AdvertHead { get; set; }
        public string AdvertDetails { get; set; }
        public decimal Price { get; set; }
        public string AdvertState { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
    }
}
