using BlazorMessenger.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class FollowerAPI
    {
        private IUnitOfWork _unitOfWork;

        public FollowerAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
