using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models.DTO;
using BLL.Models.Forms.Insurance;
using BLL.Models.Forms.Message;
using DAL.Interfaces;
using DAL.Models.DTO;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MessageBllService : IMessageBll
    {

        private readonly ILogger _logger;
        private readonly IMessageDal _messageDal;
        private readonly IUserBll _userBll;
        private readonly IUserDal _userDal;

        public MessageBllService(ILogger<MessageBllService> logger, IMessageDal messageDal, IUserBll userBll, IUserDal userDal)
        {
            _messageDal = messageDal;
            _logger = logger;
            _userBll = userBll;
            _userDal = userDal;
        }

        public int? Delete(int id)
        {
            return _messageDal.Delete(id);
        }

        public IEnumerable<MessageBll> GetAll()
        {
            List<MessageBll> messages = _messageDal.GetAll().Select(u => u.ToMessageBll()).ToList();
            foreach (var message in messages)
            {
                message.Sender = message.SenderId == 0 ? null : _userDal.GetById(message.SenderId).ToUserBll();
                message.Reciever = message.RecieverId == 0 ? null : _userDal.GetById(message.RecieverId).ToUserBll();
            }
            return messages;
        }
    

        public MessageBll? GetById(int id)
        {
            MessageBll message = _messageDal.GetById(id)?.ToMessageBll();
            message.Sender = message.SenderId == 0 ? null : _userDal.GetById(message.SenderId).ToUserBll();
            message.Reciever = message.RecieverId == 0 ? null : _userDal.GetById(message.RecieverId).ToUserBll();
            return message;
        }

        public MessageBll? Insert(AddMessageFormBll form)
        {
            return _messageDal.Insert(form.ToAddMessageFromDal())?.ToMessageBll();
        }

        public MessageBll? Update(UpdateMessageFormBll form)
        {
            return _messageDal.Update(form.ToUpdateMessageFormDal())?.ToMessageBll();
        }

        public int? Disable(int id)
        {
            return _messageDal.Disable(id);
        }

        public int? Enable(int id)
        {
            return _messageDal.Enable(id); ;
        }

        public IEnumerable<MessageBll>? GetMessagesBySenderId(int id)
        {
            List<MessageBll> messages = _messageDal.GetMessagesBySenderId(id).Select(u => u.ToMessageBll()).ToList();
            foreach (var message in messages)
            {
                //message.Sender = message.SenderId == 0 ? null : _userDal.GetById(message.SenderId).ToUserBll();
                message.Reciever = message.RecieverId == 0 ? null : _userDal.GetById(message.RecieverId).ToUserBll();
            }
            return messages;
        }

        public IEnumerable<MessageBll>? GetMessagesByRecieverId(int id)
        {
            List<MessageBll> messages = _messageDal.GetMessagesByRecieverId(id).Select(u => u.ToMessageBll()).ToList();
            foreach (var message in messages)
            {
                message.Sender = message.SenderId == 0 ? null : _userDal.GetById(message.SenderId).ToUserBll();
                //message.Reciever = message.RecieverId == 0 ? null : _userDal.GetById(message.RecieverId).ToUserBll();
            }

            return messages;
        }

        public IEnumerable<MessageBll>? GetMessagesBetween(int sender, int reciever)
        {
            List<MessageBll> messages = _messageDal.GetMessagesBetween(sender, reciever).Select(u => u.ToMessageBll()).ToList();
            foreach (var message in messages)
            {
                message.Reciever = _userDal.GetById(message.RecieverId).ToUserBll();
                message.Sender = _userDal.GetById(message.SenderId).ToUserBll();
            }
            return messages;
        }



    }
}
