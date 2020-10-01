using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OLSoftware.Core.Entities
{
    public class UserEnti : IdentityUser
    {
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public bool IsAdmin { get; set; }
    }
}
