﻿namespace BLL.Models.DTO
{
    public class MessageBll
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public UserBll? Sender { get; set; }
        public UserBll? Reciever { get; set; }

        public bool IsRead { get; set; }
    }
}
