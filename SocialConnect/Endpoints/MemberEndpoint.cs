using Microsoft.AspNetCore.Mvc;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserService;
using System.Net;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using SocialConnect.Exceptions;
using Microsoft.Extensions.Logging;

namespace SocialConnect.Endpoints
{
    public static class MemberEndpoint
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapGet("api/v1/members", async (ILoggerFactory iLoggerFactory, IMemberService service) =>
            {
                var logger = iLoggerFactory.CreateLogger(typeof(MemberEndpoint));
                try
                {
                    List<DisplayableMemberDto> members = await service.GetMembers();

                    return Results.Ok(members);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while getting members");
                    return Results.Problem();
                }
            });
            app.MapGet("api/v1/member/{id}", async (ILoggerFactory iLoggerFactory, IMemberService service, [FromRoute] int id) =>
            {
                var logger = iLoggerFactory.CreateLogger(typeof(MemberEndpoint));

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
                    logger.LogError(ex, "An error occurred while getting member");
                    return Results.Problem();
                }
            });
            app.MapPost("api/v1/member", async (ILoggerFactory iLoggerFactory, IMemberService service, [FromBody] CreateMemberDto memberDto) =>
            {
                var logger = iLoggerFactory.CreateLogger(typeof(MemberEndpoint));

                try
                {
                    int memberId = await service.CreateMember(memberDto);
                    return Results.Created("api/v1/member", memberId);
                }
                catch (UsernameAlreadyTakenException ex)
                {
                    logger.LogInformation(ex, "Username has already been taken");

                    return Results.BadRequest("Username already taken");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while creating member");
                    return Results.Problem();
                }
            });
            app.MapDelete("api/v1/member/{id}", async (ILoggerFactory iLoggerFactory, IMemberService service, [FromRoute] int id) =>
            {
                var logger = iLoggerFactory.CreateLogger(typeof(MemberEndpoint));

                try
                {
                    await service.DeleteMember(id);
                    return Results.NoContent();
                }
                catch (UserNotFoundException ex)
                {
                    logger.LogInformation(ex, $"Could not find user by id: {id}");
                    return Results.BadRequest("User not found");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while deleting member");
                    return Results.Problem();
                }
            });
        }
    }
}
