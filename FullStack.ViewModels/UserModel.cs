
using System.Collections.Generic;

namespace FullStack.ViewModels
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }

        public List<AdvertModel> Adverts {get; set;}
       

    }
}
