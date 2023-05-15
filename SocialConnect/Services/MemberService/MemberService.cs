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

            if (await _memberRepository.IsUsernameAlreadyTaken(memberDto.Username))
            {
                return -1;
            }

            int memberId = await _memberRepository.CreateMember(memberDto);

            return memberId;
        }
    }
}
