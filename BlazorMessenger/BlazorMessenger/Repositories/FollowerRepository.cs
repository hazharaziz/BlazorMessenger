using BlazorMessenger.DataContext;
using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BlazorMessenger.Repositories
{
    public class FollowerRepository : IFollowerRepository
    {
        public MessengerContext Context;
        public FollowerRepository(MessengerContext messengerContext)
        {
            Context = messengerContext;
        }
        public IEnumerable<Follower> GetFollowers(int userId)
            => Find(f => f.UserId == userId);
        public IEnumerable<Follower> GetAll()
            => Context.Set<Follower>().ToList();

        public IEnumerable<Follower> Find(Expression<Func<Follower, bool>> predicate)
            => Context.Set<Follower>().Where(predicate);

        public void Add(Follower entity)
            => Context.Set<Follower>().Add(entity);

        public void AddRange(IEnumerable<Follower> entities)
            => Context.Set<Follower>().AddRange(entities);

        public void Remove(Follower entity)
            => Context.Set<Follower>().Remove(entity);

        public void RemoveRange(IEnumerable<Follower> entities)
            => Context.Set<Follower>().RemoveRange(entities);

        public bool HasFollower(int currentUserId, int targetUserId)
        {
            Follower follower = Find(f => ((f.UserId == currentUserId) && (f.FollowerId == targetUserId)))
                .FirstOrDefault();
            return (follower != null);
        }
    }
}
