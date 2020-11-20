using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface ILoginAPI
    {
        User FetchUser(string username);
        bool ValidateUserLoginRequest(User user);
        void AuthenticateUser(User user);
    }
}
