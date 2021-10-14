using System;
using System.Collections.Generic;
using System.Text;

namespace FullStack.Data.Entities
{
    public class Seller
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
    }
}
