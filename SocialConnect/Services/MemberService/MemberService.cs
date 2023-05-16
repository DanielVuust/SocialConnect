using Microsoft.AspNetCore.Mvc.TagHelpers;
using SocialConnect.Exceptions;
using SocialConnect.Repository.MemberRepository;
using SocialConnect.Repository.UserRepository;
using SocialConnect.Services.Dtos;
using SocialConnect.Services.MemberService;

namespace SocialConnect.Services.UserService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<int> CreateMember(CreateMemberDto memberDto)
        {
            try
            {
                if (await _memberRepository.IsUsernameAlreadyTaken(memberDto.Username))
                {
                    throw new UsernameAlreadyTakenException();
                }

                int memberId = await _memberRepository.CreateMember(memberDto);

                return memberId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DisplayableMemberDto> GetMember(int id)
        {
            try
            {
                DisplayableMemberDto? member = await this._memberRepository.GetMember(id);

                if (member == null)
                {
                    throw new UserNotFoundException();
                }

                return member;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<DisplayableMemberDto>> GetMembers()
        {
            try
            {
                List<DisplayableMemberDto> members = await this._memberRepository.GetMembers();

                return members;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteMember(int id)
        {
            try
            {
                bool deleted = await this._memberRepository.DeleteMember(id);
                return deleted;
            }
            catch (UserNotFoundException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
