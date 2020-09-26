using System;
using System.Collections.Generic;

namespace OLSoftware.exportFile.Data
{
    public partial class ProgrammingLanguage
    {
        public ProgrammingLanguage()
        {
            ProjectLanguage = new HashSet<ProjectLanguage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }

        public virtual ICollection<ProjectLanguage> ProjectLanguage { get; set; }
    }
}
