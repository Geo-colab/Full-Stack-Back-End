using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class AdvertSearch
    {
        public int ProvinceId { get; set; }
        public int? CityId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string? Keyword { get; set; }

    }
}
