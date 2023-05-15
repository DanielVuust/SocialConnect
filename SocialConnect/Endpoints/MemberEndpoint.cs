using Microsoft.AspNetCore.Mvc;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserService;

namespace SocialConnect.Endpoints
{
    public static class MemberEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/members", (int id) =>
            {

            });
            app.MapPost("api/v1/member", (IMemberService service, [FromBody] CreateMemberDto memberDto) =>
            {
                service.CreateMember(memberDto);
            });
        }
    }
}
