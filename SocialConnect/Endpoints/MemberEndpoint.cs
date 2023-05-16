using Microsoft.AspNetCore.Mvc;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserService;
using System.Net;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SocialConnect.Exceptions;

namespace SocialConnect.Endpoints
{
    public static class MemberEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/members", async (IMemberService service) =>
            {
                try
                {
                    List<DisplayableMemberDto> members = await service.GetMembers();

                    return Results.Ok(members);
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });
            app.MapGet("api/v1/member/{id}", async (IMemberService service, [FromRoute] int id) =>
            {
                try
                {
                    DisplayableMemberDto? member = await service.GetMember(id);
                    if (member == null)
                    {
                        return Results.BadRequest("User not found");
                    }
                    return Results.Ok(member);
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });
            app.MapPost("api/v1/member", async (IMemberService service, [FromBody] CreateMemberDto memberDto) =>
            {
                try
                {
                    int memberId = await service.CreateMember(memberDto);
                    return Results.Created("api/v1/member", memberId);
                }
                catch (UsernameAlreadyTakenException ex)
                {
                    return Results.BadRequest("Username already taken");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });
            app.MapDelete("api/v1/member/{id}", async (IMemberService service, [FromRoute] int id) =>
            {
                try
                {
                    await service.DeleteMember(id);
                    return Results.NoContent();
                }
                catch (UserNotFoundException ex)
                {
                    return Results.BadRequest("User not found");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });
        }
    }
}
