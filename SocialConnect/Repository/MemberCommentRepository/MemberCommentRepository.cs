using Microsoft.Data.SqlClient;
using SocialConnect.Model;
using SocialConnect.Repository.Exceptions;

namespace SocialConnect.Repository.UserCommentRepository
{
    public class MemberCommentRepository : IMemberCommentRepository
    {
        private readonly SocialConnectContext _socialConnectContext;
        private ILogger<MemberCommentRepository> _logger;

        public MemberCommentRepository(SocialConnectContext socialConnectContext, ILogger<MemberCommentRepository> logger)
        {
            _socialConnectContext = socialConnectContext;
            _logger = logger;
        }

        public async Task CreateMemberComment(MemberComment memberCommentEntity)
        {
            try
            {
                _socialConnectContext.UserComments.Add(memberCommentEntity);
                await _socialConnectContext.SaveChangesAsync();
            }
            catch (SqlException e)
            {
                _logger.LogError(e, e.Message);
                throw new MemberCommentRepositoryException(e.Message, e);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                throw new MemberCommentRepositoryException(e.Message, e);
            }
        }
    }
}
