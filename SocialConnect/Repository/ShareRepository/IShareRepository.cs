using SocialConnect.Model;

namespace SocialConnect.Repository.ShareRepository
{
    public interface IShareRepository
    {
        Task ShareBulletin(ShareEntity shareEntity);
    }
}
