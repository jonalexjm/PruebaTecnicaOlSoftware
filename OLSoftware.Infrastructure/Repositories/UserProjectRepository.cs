using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Infrastructure.Repositories
{
    public class UserProjectRepository : RepositoryBase<UserProject>, IUserProjectRepository
    {
        private readonly OlsoftwareContext context;
        public UserProjectRepository(OlsoftwareContext context)  : base(context)
        {
            this.context = context;
        }
    }
}
