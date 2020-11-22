using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface IFollowerAPI
    {
        List<User> GetFollowers(int id);
        List<User> GetFollowers(string username);
        void Follow(int userId, int followerId);
        void Unfollow(int userId, int followerId);
        bool IsFollowing(int userId, int followerId);
    }
}
