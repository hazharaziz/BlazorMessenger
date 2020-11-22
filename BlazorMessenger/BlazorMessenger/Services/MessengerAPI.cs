using BlazorMessenger.Authentication;
using BlazorMessenger.Data;
using BlazorMessenger.Interfaces;
using BlazorMessenger.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessenger.Services
{
    public class MessengerAPI : IMessengerAPI
    {
        private IUnitOfWork _unitOfWork;
        private IFollowerAPI _followerAPI;

        public MessengerAPI(IUnitOfWork unitOfWork, IFollowerAPI followerAPI)
        {
            _unitOfWork = unitOfWork;
            _followerAPI = followerAPI;
        }

        public List<Message> FetchMessages()
            => _unitOfWork.Messages.GetAll().ToList();

        public List<Message> FetchFriendsMessages(int userId)
        {
            List<int> followingsIds = _followerAPI.GetFollowings(userId).Select(f => f.Id).ToList();
            List<Message> allMessages = FetchMessages();
            List<Message> filteredMessages = new List<Message>();
            foreach (var message in allMessages)
            {
                if (followingsIds.Contains(message.ComposerId))
                {
                    filteredMessages.Add(message);  
                }
            }
            return filteredMessages;
        }

        public void AddMessage(Message message)
        {
            if (message == null)
            {
                throw new Exception(Alerts.InvalidMessage);
            }
            _unitOfWork.Messages.Add(message);
            _unitOfWork.Save();
        }

        public void EditMessage(int id, string editedMessage)
        {
            if (editedMessage == string.Empty)
            {
                throw new Exception(Alerts.InvalidMessage);
            }
            Message message = _unitOfWork.Messages.Get(id);
            message.Text = editedMessage;
            _unitOfWork.Save();
        }

        public User GetCurrentUser(string username)
            => _unitOfWork.Users.GetByUsername(username);

    }
}
