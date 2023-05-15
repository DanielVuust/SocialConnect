namespace SocialConnect.Model
{
    public class Bulletin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public virtual string AuthorId { get; set; }

    }
}
