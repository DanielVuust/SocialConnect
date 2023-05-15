using Microsoft.EntityFrameworkCore;
using SocialConnect.Model;

namespace SocialConnect.Repository.UserCommentRepository
{
    public class MemberCommentRepository : IMemberCommentRepository
    {
        private SocialConnectContext _socialConnectContext;

        public MemberCommentRepository(SocialConnectContext socialConnectContext)
        {
            _socialConnectContext = socialConnectContext;
        }

        public Task CreateMemberComment(MemberComment memberCommentEntity)
        {
            _socialConnectContext.UserComments.Add(memberCommentEntity);
            _socialConnectContext.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
