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

        public MessengerAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Message> FetchMessages()
            => _unitOfWork.Messages.GetAll().ToList();

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
    }
}
