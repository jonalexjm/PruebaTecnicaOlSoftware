using OLSoftware.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OLSoftware.Core.Entities
{
    public class Project : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
        public float NumberHours { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }
        public virtual ICollection<ProjectLanguage> ProjectLanguages { get; set; }

    }
}
