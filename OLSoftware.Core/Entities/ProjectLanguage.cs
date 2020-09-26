using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using OLSoftware.Core.Interfaces;

namespace OLSoftware.Core.Entities
{
    public class ProjectLanguage : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }


        public int ProgrammingLanguageId { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
    }
}
