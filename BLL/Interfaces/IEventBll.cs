using BLL.Models.DTO;
using BLL.Models.Forms.Diveplace;
using BLL.Models.Forms.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IEventBll
    {
        IEnumerable<EventBll> GetAll();

        EventBll? GetById(int id);

        EventBll? Insert(AddEventFormBll form);

        EventBll? Update(UpdateEventFormBll form);

        int? Delete(int id);
    }
}
