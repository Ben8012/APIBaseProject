using BLL.Models.DTO;
using BLL.Models.Forms.Insurance;
using BLL.Models.Forms.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageBll
    {
        IEnumerable<MessageBll> GetAll();

        MessageBll? GetById(int id);

        MessageBll? Insert(AddMessageFormBll form);

        MessageBll? Update(UpdateMessageFormBll form);

        int? Delete(int id);
        int? Enable(int id);

        int? Disable(int id);
    }
}
