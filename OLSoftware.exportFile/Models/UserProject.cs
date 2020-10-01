using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLSoftware.exportFile.Models
{
    public class UserProject
    {
        public int Id { get; set; }
        public string Status { get; set; }
        
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
