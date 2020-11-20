using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface IAuthenticationAPI
    {
        void LoginUser(User user);
        void SignUpUser(User user);
        void LogoutUser(User user);
    }
}
