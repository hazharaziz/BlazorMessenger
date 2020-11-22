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
        List<User> GetFollowings(int id);
        List<User> GetFollowings(string username);
        void SendFollowRequest(int userId, int followerId);
        void AcceptFollowRequest(int userId, int followerId);
        void RejectFollowRequest(int userId, int followerId);
        void CancelRequest(int userId, int followerId);
        void Unfollow(int userId, int followerId);
        bool HasFollower(int userId, int followerId);
        bool HasRequestFrom(int userId, int followerid);
    }
}
