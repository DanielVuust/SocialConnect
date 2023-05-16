using SocialConnect.Model;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.BulletinService
{
    public interface IBulletinService
    {
        Task CreateBulletin(BulletinDto bulletinDto);

        //Task UpdateBulletin(BulletinDto bulletinDto);


        //void UpdateBulletin(int id);
        //void DeleteBulletin(int id);
        //IEnumerable<Bulletin> GetBulletin(int id);
        //IEnumerable<Bulletin> GetBulletins();
    }
}
