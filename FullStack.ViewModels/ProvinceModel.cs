using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.ViewModels
{
    public class ProvinceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CityModel> Cities { get; set; }

    }
}
