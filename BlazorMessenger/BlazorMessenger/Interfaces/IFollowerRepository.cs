using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BlazorMessenger.Interfaces
{
    public interface IFollowerRepository
    {
        IEnumerable<Follower> GetFollowers(int userId);
        IEnumerable<Follower> GetAll();
        IEnumerable<Follower> Find(Expression<Func<Follower, bool>> predicate);
        void Add(Follower entity);
        void AddRange(IEnumerable<Follower> entities);
        void Remove(Follower entity);
        void RemoveRange(IEnumerable<Follower> entities);
        bool HasFollower(int userId, int followerId);
        bool HasRequestFrom(int userId, int followerId);
    }
}
