using SocialConnect.Model;
using SocialConnect.Services.Dtos;
using SocialConnect.Repository.ShareRepository;

namespace SocialConnect.Services.ShareService
{
    public class ShareService : IShareService
    {
        private readonly IShareRepository _shareRepository;

        public ShareService(IShareRepository shareRepository)
        {
            _shareRepository = shareRepository;
        }

        public async Task ShareBulletin(ShareDto shareDto)
        {
            try
            {
                if (shareDto == null)
                {
                    throw new Exception();
                }

                var shareEntity = new ShareEntity
                {
                    MemberId = shareDto.MemberId,
                    SharedMemberId = shareDto.SharedMemberId,
                    BulletinId = shareDto.BulletinId
                };

                await _shareRepository.ShareBulletin(shareEntity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
