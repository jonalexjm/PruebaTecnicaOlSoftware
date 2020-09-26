using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using OLSoftware.Core.Interfaces;

namespace OLSoftware.Core.Entities
{
    public class ProgrammingLanguage :IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set;}
        public string Level { get; set; }

        public virtual ICollection<ProjectLanguage> ProjectLanguages { get; set; }

    }
}
