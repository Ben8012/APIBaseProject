namespace DAL.Models.Forms.Message
{
    public class AddMessageFormDal
    {
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
        public string Content { get; set; }
    }
}
