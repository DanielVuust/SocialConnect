using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.MemberService
{
    public interface IMemberService
    {
        public Task<int> CreateMember(CreateMemberDto memberDto);
    }
}
