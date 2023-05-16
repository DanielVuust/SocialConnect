using SocialConnect.Model;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Repository.UserRepository
{
    public interface IMemberRepository
    {
        public Task<int> CreateMember(Member member);
        public Task<bool> IsUsernameAlreadyTaken(string username);
        public Task<List<DisplayableMemberDto>> GetMembers();
        public Task<DisplayableMemberDto?> GetMember(int id);
        public Task<bool> DeleteMember(int id);

    }
}
