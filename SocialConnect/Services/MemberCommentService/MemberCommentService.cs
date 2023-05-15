using SocialConnect.Model;
using SocialConnect.Repository;
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
                //if (memberCommentDto == null)
                //{
                //    //Throw MemberCommentServiceException
                //    throw new MemberCommentServiceException("Could not create member comment. Please try again later");
                //}

                var memberCommentEntity = new MemberComment
                {
                    Id = Convert.ToInt32(memberCommentDto.AuthorId),
                    Body = memberCommentDto.Body,
                };

                //Catch exception that comes from repo
                await _memberCommentRepository.CreateMemberComment(memberCommentEntity);

            }
            catch (MemberCommentRepositoryException e)
            {
                throw new MemberCommentServiceException("Something went wrong", e);
            }
        }
    }
}
