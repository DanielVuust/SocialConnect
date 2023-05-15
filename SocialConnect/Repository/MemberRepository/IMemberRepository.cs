using SocialConnect.Services.Dtos;

namespace SocialConnect.Repository.UserRepository
{
    public interface IMemberRepository
    {
        public Task<int> CreateMember(CreateMemberDto memberDto);
        public Task<bool> IsUsernameAlreadyTaken(string username);
    }
}
