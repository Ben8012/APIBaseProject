using System.Reflection.Metadata.Ecma335;

namespace API.Models.Forms.UserAPI
{
    public class LikeForm
    {
        public int LikerId { get; set; }
        public int LikedId { get; set; }
    }
}
