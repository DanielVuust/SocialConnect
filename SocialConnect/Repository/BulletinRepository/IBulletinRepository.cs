using SocialConnect.Model;

namespace SocialConnect.Repository.BulletinRepository
{
    public interface IBulletinRepository
    {
        void CreateBulletin(string name, string description, string AuthorId);
        void UpdateBulletin(int id);
        void DeleteBulletin(int id);
        IEnumerable<Bulletin> GetBulletin(int id);
        IEnumerable<Bulletin> GetBulletins();
    }
}
