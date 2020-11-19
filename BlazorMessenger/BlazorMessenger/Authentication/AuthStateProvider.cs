using BlazorMessenger.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorMessenger.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, "hazhar")
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void AuthenticateUser(User user)
        {
            var userClaims = new List<Claim>()
            {
                new Claim("Username", user.Username),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}")
            };
            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipals = new ClaimsPrincipal(new[] { userIdentity });
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(userPrincipals)));
        }
    }
}
