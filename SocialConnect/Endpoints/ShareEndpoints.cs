using SocialConnect.Services.BulletinService;
using SocialConnect.Services.ShareService;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Endpoints
{
    public static class ShareEndpoints
    {
        public static void MapBulletinsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/bulletin", (IShareService shareService, int bulletId, int memberId, int sharedMemberId) =>
            {
                var shareDto = new ShareDto
                {
                    BulletinId = bulletId,
                    MemberId = memberId,
                    SharedMemberId = sharedMemberId
                };

                shareService.ShareBulletin(shareDto);
            });
        }
    }
}
