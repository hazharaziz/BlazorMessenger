using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class FollowerAPI : IFollowerAPI
    {
        private IUnitOfWork _unitOfWork;

        public FollowerAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetFollowers(int userId)
        {
            List<int> followerIds = _unitOfWork.Followers.GetFollowers(userId).Select(f => f.FollowerId).ToList();
            List<User> followers = new List<User>();
            foreach (int id in followerIds)
            {
                var user = _unitOfWork.Users.Get(id);
                followers.Add(user);
            }
            return followers;
        }
    }
}
