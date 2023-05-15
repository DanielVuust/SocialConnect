using Microsoft.AspNetCore.Mvc;
using SocialConnect.Repository.BulletinRepository;

namespace SocialConnect.Endpoints
{
    public static class UserCommentsEndpoints
    {
        public static void MapUserCommentsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/userComments",
                (HttpContext httpContext) => { });
            
        }
    }
}
