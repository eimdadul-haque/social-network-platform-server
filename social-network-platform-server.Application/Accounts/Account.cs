using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using social_network_platform_server.Application.Contracts.Accounts.Dtos;
using social_network_platform_server.Application.Contracts.Accounts.Interfaces;
using social_network_platform_server.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Accounts
{
    public class Account : IAccount
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public Account(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<bool> SignUp()
        {
            return true;
        }

        [HttpPost]
        public async Task<bool> SignIn(SignInDto input)
        {
            return true;
        }
    }
}
