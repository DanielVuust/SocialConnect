using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.ShareService
{
    public interface IShareService
    {
        Task ShareBulletin(ShareDto shareDto);
    }
}
