using System;
using System.Collections.Generic;

namespace OLSoftware.exportFile.Data
{
    public partial class ProjectLanguage
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
        public virtual Project Project { get; set; }
    }
}
