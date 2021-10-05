﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        //Province foreign key
        public int ProvinceId { get; set; }
    }
}
