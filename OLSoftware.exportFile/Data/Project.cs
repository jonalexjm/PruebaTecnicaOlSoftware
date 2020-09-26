using System;
using System.Collections.Generic;

namespace OLSoftware.exportFile.Data
{
    public partial class Project
    {
        public Project()
        {
            ProjectLanguage = new HashSet<ProjectLanguage>();
            UserProject = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
        public float NumberHours { get; set; }

        public virtual ICollection<ProjectLanguage> ProjectLanguage { get; set; }
        public virtual ICollection<UserProject> UserProject { get; set; }
    }
}
