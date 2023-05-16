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
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<MemberService> _logger;

        public MemberService(IMemberRepository memberRepository, ILoggerFactory loggerFactory)
        {
            _memberRepository = memberRepository;
            _loggerFactory = loggerFactory;
            _logger = loggerFactory.CreateLogger<MemberService>();
        }
        public async Task<int> CreateMember(CreateMemberDto memberDto)
        {
            this._logger.LogDebug("Calling CreateMember");

            if (await _memberRepository.IsUsernameAlreadyTaken(memberDto.Username))
            {
                throw new UsernameAlreadyTakenException();
            }

            int memberId = await _memberRepository.CreateMember(memberDto);

            return memberId;
        }

        public async Task<DisplayableMemberDto?> GetMember(int id)
        {
            this._logger.LogDebug("Calling GetMember");

            DisplayableMemberDto? member = await this._memberRepository.GetMember(id);

            return member;

        }

        public async Task<List<DisplayableMemberDto>> GetMembers()
        {
            this._logger.LogDebug("Calling GetMembers");

            List<DisplayableMemberDto> members = await this._memberRepository.GetMembers();

            return members;
        }

        public async Task<bool> DeleteMember(int id)
        {
            this._logger.LogDebug("Calling DeleteMember");

            bool deleted = await this._memberRepository.DeleteMember(id);
            return deleted;
        }
    }
}
