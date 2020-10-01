using Microsoft.AspNetCore.Identity;
using OLSoftware.FrontEnd.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLSoftware.FrontEnd.Helpers
{
    public interface IUserHelper
    {
        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
    }
}
