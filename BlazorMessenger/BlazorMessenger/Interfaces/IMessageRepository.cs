using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface IMessageRepository
    {
        Message Get(int id);
        IEnumerable<Message> GetAll();
        IEnumerable<Message> Find(Expression<Func<Message, bool>> predicate);
        void Add(Message entity);
        void AddRange(IEnumerable<Message> entities);
        void Remove(Message entity);
        void RemoveRange(IEnumerable<Message> entities);
    }
}
