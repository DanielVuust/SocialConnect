using SocialConnect.Model;

namespace SocialConnect.Repository.UserCommentRepository
{
    public interface IMemberCommentRepository
    {
        public Task CreateMemberComment(MemberComment  memberCommentEntity);
    }
}
