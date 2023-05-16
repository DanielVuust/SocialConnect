using SocialConnect.Model;

namespace SocialConnect.Repository.BulletinRepository
{
    public interface IBulletinRepository
    {
        public Task CreateBulletin(Bulletin bulletinEntity);

        public Task<IEnumerable<Bulletin>> GetBulletins();

        //public Task UpdateBulletin(Bulletin bulletinEntity);
        //public Task DeleteBulletin(Bulletin bulletinEntity);
        //public Task<IEnumerable<Bulletin>> GetBulletin(Bulletin bulletinEntity);
        //public Task<IEnumerable<Bulletin>> GetBulletinsByAuthorId(string authorId);
    }
}
