using Microsoft.AspNetCore.Mvc;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserService;
using System.Net;

namespace SocialConnect.Endpoints
{
    public static class MemberEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/members", async (IMemberService service) =>
            {
                List<DisplayableMemberDto> members = await service.GetMembers();

                return Results.Ok(members);
            });
            app.MapGet("api/v1/member/{id}", async (IMemberService service, [FromRoute] int id) =>
            {
                DisplayableMemberDto member = await service.GetMember(id);

                return Results.Ok(member);
            });
            app.MapPost("api/v1/member", async (IMemberService service, [FromBody] CreateMemberDto memberDto) =>
            {
                int memberId = await service.CreateMember(memberDto);
                if (memberId == -1)
                {

                }
                return Results.Created("api/v1/member", memberId);
            });
            app.MapDelete("api/v1/member/{id}", async (IMemberService service, [FromRoute] int id) =>
            {

                await service.DeleteMember(id);
                Results.NoContent();
            });
        }
    }
}
