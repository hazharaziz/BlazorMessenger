﻿using BlazorMessenger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class PeopleAPI
    {
        private IUnitOfWork _unitOfWork;

        public PeopleAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
