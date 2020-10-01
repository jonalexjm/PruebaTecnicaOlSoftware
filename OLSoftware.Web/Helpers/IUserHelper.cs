using Microsoft.AspNetCore.Identity;
using OLSoftware.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLSoftware.Web.Helpers
{
    public interface IUserHelper
    {

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

    }
}
