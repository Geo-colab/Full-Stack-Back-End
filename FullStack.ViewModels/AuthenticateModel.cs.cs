﻿
using System.ComponentModel.DataAnnotations;


namespace FullStack.ViewModels
{
   public  class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

