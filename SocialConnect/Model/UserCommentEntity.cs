namespace SocialConnect.Model
{
    public class UserComment
    {
        public int Id { get; set; }
        public User Author { get; set; }
        public string Body { get; set; }
        public virtual string AuthorId { get; set;  }
    }
}
