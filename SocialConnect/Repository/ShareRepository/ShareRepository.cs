using SocialConnect.Model;

namespace SocialConnect.Repository.ShareRepository
{
    public class ShareRepository : IShareRepository
    {
        private SocialConnectContext _socialConnectContext;

        public ShareRepository(SocialConnectContext socialConnectContext)
        {
            _socialConnectContext = socialConnectContext;
        }

        public Task ShareBulletin(ShareEntity shareEntity)
        {
            _socialConnectContext.Shares.Add(shareEntity);
            _socialConnectContext.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
