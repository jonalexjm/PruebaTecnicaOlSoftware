using System;
using System.Collections.Generic;

namespace OLSoftware.exportFile.Data
{
    public partial class User
    {
        public User()
        {
            UserProject = new HashSet<UserProject>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<UserProject> UserProject { get; set; }
    }
}
