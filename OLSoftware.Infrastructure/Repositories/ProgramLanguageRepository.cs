using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OLSoftware.Infrastructure.Repositories
{
    public class ProgramLanguageRepository : RepositoryBase<ProgrammingLanguage>, IProgramLanguageRepository
    {

        private readonly OlsoftwareContext context;

        public ProgramLanguageRepository(OlsoftwareContext context) : base(context)
        {
            this.context = context;
        }
    }
}
