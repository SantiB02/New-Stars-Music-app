using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Merchanmusic.Services.Implementations
{
    public class MessageBoardService : IMessageBoardService
    {
        private readonly MerchContext _context;

        public MessageBoardService(MerchContext context)
        {
            _context = context;
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public Message CreateMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public Message UpdateMessage(string newMessage, int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (message != null)
            {
                message.MessageBody = newMessage;
                _context.Messages.Update(message);
                _context.SaveChanges();
            }
            return message;
        }

        public void DeleteMessage(int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.Id == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
        }
    }
}
