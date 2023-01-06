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

        public MessageBllService(ILogger<MessageBllService> logger, IMessageDal messageDal)
        {
            _messageDal = messageDal;
            _logger = logger;
        }

        public int? Delete(int id)
        {
            return _messageDal.Delete(id);
        }

        public IEnumerable<MessageBll> GetAll()
        {
            return _messageDal.GetAll().Select(u => u.ToMessageBll());
        }

        public MessageBll? GetById(int id)
        {
            return _messageDal.GetById(id)?.ToMessageBll();
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
    }
}
