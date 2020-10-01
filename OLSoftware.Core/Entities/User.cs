using OLSoftware.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace OLSoftware.Core.Entities
{
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }


        

    }
}
