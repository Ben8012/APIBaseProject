namespace API.Models.Forms.Message
{
    public class AddMessageForm
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
    }
}
