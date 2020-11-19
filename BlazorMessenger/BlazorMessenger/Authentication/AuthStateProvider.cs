using Blazored.SessionStorage;
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
        private ISessionStorageService _sessionStorage;
        public AuthStateProvider(ISessionStorageService sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string username = await _sessionStorage.GetItemAsync<string>("username");
            var identity = (username != null) ? new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username)
            }, "User Identity") : new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void AuthenticateUser(string username)
        {
            var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
            };
            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
            var userPrincipals = new ClaimsPrincipal(new[] { userIdentity });
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(userPrincipals)));
        }

        public void LogoutUser()
        {
            _sessionStorage.RemoveItemAsync("username");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
