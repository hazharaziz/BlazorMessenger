using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class PeopleAPI : ISearchable<User>
    {
        private IUnitOfWork _unitOfWork;

        public PeopleAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> Search(string query)
            => _unitOfWork.Users.Find(u => u.Username.Contains(query)).ToList();
    }
}
