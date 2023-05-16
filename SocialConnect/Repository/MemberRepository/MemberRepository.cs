using SocialConnect.Exceptions;
using SocialConnect.Model;
using SocialConnect.Repository.UserRepository;
using SocialConnect.Services.Dtos;
using System.Security.Cryptography;

namespace SocialConnect.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly SocialConnectContext _context;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<MemberRepository> _logger;

        public MemberRepository(SocialConnectContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<MemberRepository>();
        }
        public async Task<int> CreateMember(Member member)
        {
            this._logger.LogDebug("Calling CreateMember");

            this._context.Members.Add(member);
            await this._context.SaveChangesAsync();

            return member.Id;
        }

        public async Task<bool> IsUsernameAlreadyTaken(string username)
        {
            this._logger.LogDebug("Calling IsUsernameAlreadyTaken");

            return this._context.Members.Any(x => x.Username == username);
        }

        public async Task<List<DisplayableMemberDto>> GetMembers()
        {
            this._logger.LogDebug("Calling GetMembers");

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
            this._logger.LogDebug("Calling GetMember");

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
            this._logger.LogDebug("Calling DeleteMember");

            Member? member = this._context.Members.FirstOrDefault(x => x.Id == id);

            if (member == null)
            {
                throw new UserNotFoundException();
            }

            this._context.Members.Remove(member);
            await this._context.SaveChangesAsync();

            return true;
        }
    }
}
