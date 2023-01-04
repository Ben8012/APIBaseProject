namespace DAL.Models.Forms.Message
{
    public class UpdateMessageFormDal
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
    }
}
