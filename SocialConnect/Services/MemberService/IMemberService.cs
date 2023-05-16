using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.MemberService
{
    public interface IMemberService
    {
        public Task<int> CreateMember(CreateMemberDto memberDto);
        public Task<DisplayableMemberDto> GetMember(int id);
        public Task<List<DisplayableMemberDto>> GetMembers();
        public Task<bool> DeleteMember(int id);
    }
}
