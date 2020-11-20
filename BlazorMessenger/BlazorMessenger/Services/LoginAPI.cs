﻿using BlazorMessenger.Authentication;
using BlazorMessenger.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class LoginAPI
    {
        private AuthStateProvider _authStateProvider;
        private IUnitOfWork _unitOfWork;
        public LoginAPI(AuthenticationStateProvider authenticationStateProvider,
            IUnitOfWork unitOfWork)
        {
            _authStateProvider = authenticationStateProvider as AuthStateProvider;
            _unitOfWork = unitOfWork;
        }
    }
}
