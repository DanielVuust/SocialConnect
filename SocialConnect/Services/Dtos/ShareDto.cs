namespace SocialConnect.Services.Dtos
{
    public class ShareDto
    {
        public virtual int MemberId { get; set; }
        public virtual int SharedMemberId { get; set; }
        public virtual int BulletinId { get; set; }
    }
}
