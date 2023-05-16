using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;
using SocialConnect.Services.BulletinService;
using SocialConnect.Services.Dtos;
using SocialConnect.Exceptions;
using Microsoft.Extensions.Logging;

namespace SocialConnect.Endpoints
{
    public static class BulletinEndpoints
    {
        public static void MapBulletinEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/bulletin", (ILoggerFactory loggerFactory, IBulletinService bulletinService, int memberId, string title, string description) =>
            {
                var logger = loggerFactory.CreateLogger(typeof(BulletinEndpoints));
                try
                {
                    var bulletinDto = new BulletinDto
                    {
                        MemberId = memberId,
                        Title = title,
                        Description = description
                    };

                    bulletinService.CreateBulletin(bulletinDto);
                    return Results.Ok();
                }
                catch (BulletinExceptions ex)
                {
                    logger.LogError(ex, "An error occurred while creating post");
                    return Results.Problem("Something went wrong creating a post! :(");
                }
            });

            app.MapGet("api/v1/bulletins", async (ILoggerFactory loggerFactory, IBulletinService bulletinService) =>
            {
                var logger = loggerFactory.CreateLogger(typeof(BulletinEndpoints));
                try
                {
                List<Bulletin> bulletins = await bulletinService.GetBulletins();
                return Results.Ok(bulletins);
                }catch (BulletinExceptions ex)
                {
                    logger.LogError(ex, "An error occurred while fetching posts");
                    return Results.Problem("Very nice problem! Couldn't fetch any posts :(");
                }
            });
        }
    }
}