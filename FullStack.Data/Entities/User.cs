

using System.Collections.Generic;

namespace FullStack.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        //User advert list
        public List<Advert> Adverts { get; set; }
        
        //USer seller
        public Seller Seller { get; set; }

  
                  
    }
}
