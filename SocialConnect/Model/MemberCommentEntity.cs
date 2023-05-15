namespace SocialConnect.Model
{
    public class MemberComment
    {
        public int Id { get; set; }
        public Member Author { get; set; }
        public string Body { get; set; }
        public virtual string AuthorId { get; set; }
    }
}
