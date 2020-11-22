using BlazorMessenger.Authentication;
using BlazorMessenger.Data;
using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;

namespace BlazorMessenger.Services
{
    public class AuthenticationAPI : IAuthenticationAPI
    {
        private AuthStateProvider _authStateProvider;
        private IUnitOfWork _unitOfWork;
        public AuthenticationAPI(AuthenticationStateProvider authenticationStateProvider,
            IUnitOfWork unitOfWork)
        {
            _authStateProvider = authenticationStateProvider as AuthStateProvider;
            _unitOfWork = unitOfWork;
        }

        public void LoginUser(User user)
        {
            User fetchedUser = FetchUser(user.Username);
            if (fetchedUser == null)
            {
                throw new Exception(Alerts.InvalidLoginInfo);
            }
            user.Id = fetchedUser.Id;
            bool validUser = ValidateUserLoginRequest(user, fetchedUser);
            string name = $"{fetchedUser.FirstName} {fetchedUser.LastName}";

            if (validUser)
            {
                _authStateProvider.AuthenticateUser(name, user.Username);
            }
            else
            {
                throw new Exception(Alerts.InvalidLoginInfo);
            }
        }

        public void SignUpUser(User user)
        {
            User fetchedUser = FetchUser(user.Username);
            if (fetchedUser != null)
            {
                throw new Exception(Alerts.InvalidUsername);
            }
            _unitOfWork.Users.Add(user);
            _unitOfWork.Save();
            string name = $"{user.FirstName} {user.LastName}";
            _authStateProvider.AuthenticateUser(name, user.Username);
        }

        public void LogoutUser()
        {
            _authStateProvider.LogoutUser();
        }

        private User FetchUser(string username)
            => _unitOfWork.Users.GetByUsername(username);

        private bool ValidateUserLoginRequest(User inputUser, User fetchedUser)
            => (inputUser.Password == fetchedUser.Password);
    }
}
