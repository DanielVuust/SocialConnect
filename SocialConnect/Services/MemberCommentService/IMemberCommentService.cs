using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.MemberCommentService
{
    public interface IMemberCommentService
    {
        public Task CreateMemberComment(MemberCommentDto memberCommentDto);

    }
}
