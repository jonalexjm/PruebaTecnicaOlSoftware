using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using OLSoftware.Core.Interfaces;

namespace OLSoftware.Core.Entities
{
    public class UserProject : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }

        //foreign key User C:\Users\desarrollo\source\repos\SolutionOLSoftware\OLSoftware.Core\Entities\ProjectLanguage.cs
        public int UserId { get; set; }
        public User User { get; set; }

        //foreign key Project
        public int ProjectId { get; set; }
        public Project Project { get; set; }


    }
}
