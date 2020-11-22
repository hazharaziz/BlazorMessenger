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

        public List<User> GetFollowers(string username)
        {
            User user = _unitOfWork.Users.GetByUsername(username);
            return GetFollowers(user.Id);
        }

        public void Follow(int userId, int followerId)
        {
            if (!_unitOfWork.Followers.HasFollower(userId, followerId))
            {
                Follower follower = new Follower() { UserId = userId, FollowerId = followerId };
                _unitOfWork.Followers.Add(follower);
                _unitOfWork.Save();
            }
        }

        public bool IsFollowing(int userId, int followerId)
            => _unitOfWork.Followers.HasFollower(userId, followerId);

        public void Unfollow(int userId, int followerId)
        {
            if (_unitOfWork.Followers.HasFollower(userId, followerId))
            {
                Follower follower = _unitOfWork.Followers.Find(f => f.UserId == userId && f.FollowerId == followerId).First();
                _unitOfWork.Followers.Remove(follower);
                _unitOfWork.Save();
            }
        }
    }
}
