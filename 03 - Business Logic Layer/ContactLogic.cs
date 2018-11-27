using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonMogendorff
{
    public class ContactLogic : BaseLogic
    {
        public MessageModel GetOneMessage(int id) // Gets a single message by ID and returns it.
        {
            return DB.Messages.Where(m => m.MsgID == id).Select(m => new MessageModel
            {
                msg = m.Msg,
                msgID = m.MsgID,
                DateHour = m.DateHour,
                email = m.Email,
                phoneNumber = m.Phone
            }).SingleOrDefault();
        }

        public List<MessageModel> GetAllMessages() // Gets all messages from the DB and returns them as a list
        {
            return DB.Messages.Select(f => new MessageModel
            {
                DateHour = f.DateHour,
                msgID = f.MsgID,
                msg = f.Msg,
                email = f.Email,
                phoneNumber = f.Phone
            }).ToList();
        }

        public MessageModel AddMessage(MessageModel messageModel) // Adds a single message.
        {
            Message message = new Message
            {
                Msg = messageModel.msg,
                Email = messageModel.email,
                DateHour = messageModel.DateHour,
                Phone = messageModel.phoneNumber
            };
            DB.Messages.Add(message);
            DB.SaveChanges();

            messageModel.msgID = message.MsgID;
            return GetOneMessage(messageModel.msgID);
        }
    }
}
