namespace SocialConnect.Model
{
    public class ShareEntity
    {
        public int Id { get; set; }
        public virtual int MemberId { get; set; }
        public virtual int SharedMemberId { get; set; }
        public virtual int BulletinId { get; set; }
    }
}
