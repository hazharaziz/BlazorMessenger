using BlazorMessenger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Interfaces
{
    public interface IMessengerAPI
    {
        List<Message> FetchMessages();
        List<Message> FetchFriendsMessages(int userId);
        void AddMessage(Message message);
        void EditMessage(int id, Message message);
        User GetCurrentUser(string username);
    }
}
