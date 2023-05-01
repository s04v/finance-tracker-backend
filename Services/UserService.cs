using BCrypt.Net;
using BCryptNet = BCrypt.Net.BCrypt;
using FinanceTracker.Models;
using System.Collections;
using System.Security.Claims;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using FinanceTracker.Services.Interfaces;
using FinanceTracker.Data.Interfaces;
using FinanceTracker.Providers;

namespace FinanceTracker.Services
{
    public class UserService : IUserService
    {
        private readonly IUserProvider _userProvider;
        private readonly IUserRepository _userRepository;
        
        public UserService(IUserProvider userProvider, IUserRepository userRepository)
        {
            this._userProvider = userProvider;
            this._userRepository = userRepository;
        }
        
        public User GetOne()
        {
            int userId = this._userProvider.GetId();
            return this._userRepository.GetUserById(userId);
        }

        public User? Create(User user) 
        {
            if (this._userRepository.CheckIfUserExist(user))
            {
                return null;
            }

            string passwordHash = BCryptNet.HashPassword(user.Password, workFactor: 10);
            user.Password = passwordHash;
            
            return this._userRepository.Create(user);
        }

        public string? Login(User user)
        {
            var candidate = this._userRepository.GetUserByLogin(user.Login);
            if (candidate == null)
            {
                return null;
            }

            bool passwordVerify = BCryptNet.Verify(user.Password, candidate.Password);
            if(!passwordVerify)
            {
                return null;
            }

            var token = this.CreateJWT(candidate);

            return token;
        }

        private string? CreateJWT(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: DateTime.UtcNow,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
        
    }
}
