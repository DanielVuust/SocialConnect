using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;
using SocialConnect.Repository.BulletinRepository;

namespace SocialConnect.Endpoints
{
    public static class MemberCommentsEndpoints
    {
        public static void MapUserCommentsEndpoints(this WebApplication app)
        {
            app.MapPost("api/v1/userComments",
                (HttpContext httpContext, SocialConnectContext t) =>
                {
                    t.Users.Add(new User() {Email = "test", Password = "test", Username = "test"});
                    t.SaveChanges();
                });
            
        }
    }
}
