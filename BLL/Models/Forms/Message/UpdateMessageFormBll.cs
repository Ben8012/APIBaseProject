namespace BLL.Models.Forms.Message
{
    public class UpdateMessageFormBll
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
    }
}
