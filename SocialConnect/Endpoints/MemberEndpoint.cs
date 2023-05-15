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
            app.MapPost("api/v1/member", async (IMemberService service, [FromBody] CreateMemberDto memberDto) =>
            {
                int memberId = await service.CreateMember(memberDto);
                if (memberId == -1)
                {

                }
                return Results.Created("api/v1/member", memberId);
            });
        }
    }
}
