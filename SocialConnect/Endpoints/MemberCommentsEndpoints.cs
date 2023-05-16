using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;
using SocialConnect.Repository.BulletinRepository;
using System.Runtime.CompilerServices;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberCommentService;
using SocialConnect.Services.Exceptions;

namespace SocialConnect.Endpoints
{
    public static class MemberCommentsEndpoints
    {

        public static void CreateMemberComment(this WebApplication app)
        {
           app.MapPost("api/create-member-comment", async (IMemberCommentService memberCommentService, int authorId, string body) =>
            {
                try
                {
                    var memberCommentDto = new MemberCommentDto
                    {
                        AuthorId = authorId,
                        Body = body,
                    };

                    await memberCommentService.CreateMemberComment(memberCommentDto);
                    return Results.Ok();
                }
                catch (MemberCommentServiceException)
                {
                    return Results.Problem("An error occured. Please try again later :)");
                }
            });
        }
    }
}
