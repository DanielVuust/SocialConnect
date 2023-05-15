using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;

namespace SocialConnect.Endpoints
{
    public static class BulletinEndpoints
    {
        public static void MapBulletinsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/userBulletins",
                (HttpContext httpContext, SocialConnectContext t) =>
                {
                    
                });

        }
    }
}
