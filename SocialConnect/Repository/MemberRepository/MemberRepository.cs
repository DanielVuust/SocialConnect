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

        public async Task<List<DisplayableMemberDto>> GetMembers()
        {
            List<DisplayableMemberDto> members = this._context.Members.Select(x => new DisplayableMemberDto()
            {
                id = x.Id,
                Email = x.Email,
                Username = x.Username,

            }).ToList();

            return members;
        }

        public async Task<DisplayableMemberDto?> GetMember(int id)
        {
            DisplayableMemberDto? member = this._context.Members.Select(x => new DisplayableMemberDto()
            {
                id = x.Id,
                Email = x.Email,
                Username = x.Username,

            }).FirstOrDefault(x => x.id == id);
            return member;
        }

        public async Task<bool> DeleteMember(int id)
        {
            Member? member = this._context.Members.FirstOrDefault(x => x.Id == id);

            if(member == null)
                return false;

            this._context.Members.Remove(member);
            await this._context.SaveChangesAsync();

            return true;
        }
    }
}
