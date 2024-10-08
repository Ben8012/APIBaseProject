﻿using DAL.Models.DTO;
using DAL.Models.Forms.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMessageDal
    {
        IEnumerable<MessageDal> GetAll();
        MessageDal? GetById(int id);
        MessageDal? Insert(AddMessageFormDal form);
        MessageDal? Update(UpdateMessageFormDal form);
        int? Delete(int id);
        int? Enable(int id);
        int? Disable(int id);
        IEnumerable<MessageDal>? GetMessagesBySenderId(int id); 
        IEnumerable<MessageDal>? GetMessagesByRecieverId(int id);

        IEnumerable<MessageDal>? GetMessagesBetween(int sender, int reciever);

        void IsRead(int friendId, int userId);
    }
}
