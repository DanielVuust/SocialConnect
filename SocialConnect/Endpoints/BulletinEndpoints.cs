using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;
using SocialConnect.Services.BulletinService;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Endpoints
{
    public static class BulletinEndpoints
    {
        public static void MapBulletinsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/bulletin", (IBulletinService bulletinService, int memberId, string title, string description) =>
            {
                var bulletinDto = new BulletinDto
                {
                    MemberId = memberId,
                    Title = title,
                    Description = description
                };

                bulletinService.CreateBulletin(bulletinDto);
            });

            app.MapGet("api/v1/bulletins", async (IBulletinService bulletinService) =>
            {
                List<Bulletin> bulletins = await bulletinService.GetBulletins();
                return Results.Ok(bulletins);
            });
        }
    }
}