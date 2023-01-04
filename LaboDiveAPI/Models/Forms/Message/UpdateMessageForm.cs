namespace API.Models.Forms.Message
{
    public class UpdateMessageForm
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
    }
}
