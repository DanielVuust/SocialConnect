namespace SocialConnect.Model
{
    public class Bulletin
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Member Author { get; set; }
        public virtual int MemberId { get; set; }

    }
}
