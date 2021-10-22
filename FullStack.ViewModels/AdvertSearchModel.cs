using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.ViewModels
{
    public class AdvertSearchModel
    {
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Keyword { get; set; }

    }
}
