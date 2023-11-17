using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using social_network_platform_server.Application.Contracts.Accounts.Dtos;
using social_network_platform_server.Application.Contracts.Accounts.Interfaces;
using social_network_platform_server.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace social_network_platform_server.Application.Accounts
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> SignUp(SignUpDto signInDto)
        {
            var user = new ApplicationUser()
            {
                UserName = signInDto.Username,
                FirstName = signInDto.FirstName,
                LastName = signInDto.LastName,
                Email = signInDto.Email,
                PhoneNumber = signInDto.PhoneNumber,
                DateOfBirth = signInDto.DateOfBirth
            };

            var resutl = await _userManager.CreateAsync(user, signInDto.Password);
            return (resutl != null && resutl.Succeeded);
        }

        public async Task<string> SignIn(SignInDto signInDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInDto.UserName, signInDto.Password, signInDto.RememberMe, false);

            if (result == null || !result.Succeeded)
                throw new Exception("SignIn faild!");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, signInDto.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            return GenerateToken("secretKey", "issuer", "audience", 1, claims);
        }

        public string GenerateToken(string secretKey, string issuer, string audience, int expirationDays, List<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddDays(expirationDays),
                signingCredentials: credentials);

           return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
