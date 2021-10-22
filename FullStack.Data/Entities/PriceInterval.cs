using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class PriceInterval
    {
        public int Id { get; set; }
        public decimal PriceIntervalValue { get; set; }
        public string PriceIntervalDisplay { get; set; }
    }
}
