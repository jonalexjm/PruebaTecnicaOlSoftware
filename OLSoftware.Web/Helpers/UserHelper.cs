using Microsoft.AspNetCore.Identity;
using OLSoftware.Core.Entities;
using OLSoftware.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OLSoftware.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<UserEnti> userManager;
        private readonly SignInManager<UserEnti> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserHelper(
           UserManager<UserEnti> userManager,
           SignInManager<UserEnti> signInManager,
           RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }
    }
}
