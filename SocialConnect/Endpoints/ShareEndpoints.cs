using SocialConnect.Services.BulletinService;
using SocialConnect.Services.ShareService;
using SocialConnect.Services.Dtos;
using SocialConnect.Exceptions;

namespace SocialConnect.Endpoints
{
    public static class ShareEndpoints
    {
        public static void MapBulletinsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/bulletin", (ILoggerFactory loggerFactory, IShareService shareService, int bulletId, int memberId, int sharedMemberId) =>
            {
                var logger = loggerFactory.CreateLogger(typeof(BulletinEndpoints));
                try
                {
                    var shareDto = new ShareDto
                    {
                        BulletinId = bulletId,
                        MemberId = memberId,
                        SharedMemberId = sharedMemberId
                    };

                    shareService.ShareBulletin(shareDto);
                    return Results.Ok();
                
                }catch (ShareExceptions ex)
                {
                    logger.LogError(ex, "A problem occurred while sharing a post");
                    return Results.Problem("Sry! Could not share the post :1(");
                }
            });
        }
    }
}
