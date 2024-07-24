using Merchanmusic.Data.Entities;
using System.Collections.Generic;

namespace Merchanmusic.Services.Interfaces
{
    public interface IMessageBoardService
    {
        List<Message> GetAllMessages();
        Message CreateMessage(Message message);
        Message UpdateMessage(string newMessage, int id);
        void DeleteMessage(int id);
    }
}
