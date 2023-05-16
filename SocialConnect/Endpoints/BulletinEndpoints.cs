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
            app.MapPost("api/v1/CreateBulletin", (IBulletinService bulletinService, int authorId, string name, string description) =>
            {
                var bulletinDto = new BulletinDto
                {
                    AuthorId = authorId,
                    Name = name,
                    Description = description
                };

                bulletinService.CreateBulletin(bulletinDto);
            });
        }
    }
}
