using SocialConnect.Model;
using SocialConnect.Repository.Exceptions;
using SocialConnect.Repository.UserCommentRepository;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.Exceptions;
using SocialConnect.Services.MemberCommentService;

namespace SocialConnect.Services.UserCommentService
{
    public class MemberCommentService : IMemberCommentService
    {
        private readonly IMemberCommentRepository _memberCommentRepository;

        public MemberCommentService(IMemberCommentRepository memberCommentRepository)
        {
            _memberCommentRepository = memberCommentRepository;
        }

        public async Task CreateMemberComment(MemberCommentDto memberCommentDto)
        {
            try
            {
                var memberCommentEntity = new MemberComment
                {
                    MemberId = memberCommentDto.AuthorId,
                    Body = memberCommentDto.Body,
                };

                await _memberCommentRepository.CreateMemberComment(memberCommentEntity);
            }
            catch (MemberCommentRepositoryException MCRE)
            {
                throw new MemberCommentServiceException(MCRE.Message, MCRE);
            }
        }
    }
}
