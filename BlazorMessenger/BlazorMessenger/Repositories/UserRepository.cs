using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BlazorMessenger.DataContext;
using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;

namespace BlazorMessenger.Repositories
{
    public class UserRepository : IUserRepository
    {
        public MessengerContext Context;

        public UserRepository(MessengerContext messengerContext)
        {
            this.Context = messengerContext;
        }

        public User Get(int id)
            => Context.Set<User>().Find(id);

        public IEnumerable<User> GetAll()
            => Context.Set<User>().ToList();

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
            => Context.Set<User>().Where(predicate);

        public void Add(User entity)
            => Context.Set<User>().Add(entity);

        public void AddRange(IEnumerable<User> entities)
            => Context.Set<User>().AddRange(entities);

        public void Remove(User entity)
            => Context.Set<User>().Remove(entity);

        public void RemoveRange(IEnumerable<User> entities)
            => Context.Set<User>().RemoveRange(entities);

        public User GetByUsername(string username)
            => Find(u => u.Username == username).FirstOrDefault();
    }
}
