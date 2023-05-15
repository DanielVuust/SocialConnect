using SocialConnect.Model;
using SocialConnect.Repository.UserRepository;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SocialConnectContext _context;

        public MemberRepository(SocialConnectContext context)
        {
            _context = context;
        }
        public async Task<int> CreateMember(CreateMemberDto memberDto)
        {
            Member newMember = new Member()
                {Email = memberDto.Email, Username = memberDto.Username, Password = memberDto.Password};
            this._context.Members.Add(newMember);
            await this._context.SaveChangesAsync();
            return newMember.Id;
        }

        public async Task<bool> IsUsernameAlreadyTaken(string username)
        {
            return this._context.Members.Any(x => x.Username == username);
        }
    }
}
