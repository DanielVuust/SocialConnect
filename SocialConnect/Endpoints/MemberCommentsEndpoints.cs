using Microsoft.AspNetCore.Mvc;
using SocialConnect.Model;
using SocialConnect.Repository.BulletinRepository;
using System.Runtime.CompilerServices;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberCommentService;

namespace SocialConnect.Endpoints
{
    public static class MemberCommentsEndpoints
    {

        public static async Task CreateMemberComment(this WebApplication app)
        {
            app.MapPost("api/create-member-comment", (IMemberCommentService memberCommentService, int authorId, string body) =>
            {
                var memberCommentDto = new MemberCommentDto 
                {
                    AuthorId = authorId,
                    Body = body,
                };

                memberCommentService.CreateMemberComment(memberCommentDto);


            });
        }
    }
}
