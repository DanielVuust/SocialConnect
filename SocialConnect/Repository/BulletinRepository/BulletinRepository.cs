using SocialConnect.Model;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Repository.BulletinRepository
{
    public class BulletinRepository : IBulletinRepository
    {
        private SocialConnectContext _socialConnectContext;

        public BulletinRepository(SocialConnectContext socialConnectContext)
        {
            _socialConnectContext = socialConnectContext;
        }

        public Task CreateBulletin(Bulletin bulletinEntity)
        {
            _socialConnectContext.Bulletins.Add(bulletinEntity);
            _socialConnectContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<Bulletin>> GetBulletins()
        {
            var bulletins = _socialConnectContext.Bulletins.ToList();
            var bulletin = bulletins.Select(b => new Bulletin
            {
                Id = b.Id,
                MemberId = b.MemberId,
                Title = b.Title,
                Description = b.Description
            }).AsEnumerable();
            return bulletin;
        }



        //public Task UpdateBulletin(Bulletin bulletinEntity)
        //{
        //    _socialConnectContext.Bulletins.Update(bulletinEntity);
        //    _socialConnectContext.SaveChanges();
        //    return Task.CompletedTask;
        //}


        //public Task DeleteBulletin(Bulletin bulletinEntity)
        //{
        //    _socialConnectContext.Bulletins.Remove(bulletinEntity);
        //    _socialConnectContext.SaveChanges();
        //    return Task.CompletedTask;
        //}


        //public Task<IEnumerable<Bulletin>> GetBulletin(Bulletin bulletinEntity)
        //{
        //    _socialConnectContext.Bulletins.Where(b => b.Id == bulletinEntity.Id);
        //    _socialConnectContext.SaveChanges();
        //    return Task.CompletedTask;
        //    throw new NotImplementedException();
        //}


        //public Task<IEnumerable<Bulletin>> GetBulletins()
        //{
        //    throw new NotImplementedException();
        //}


        //public Task<IEnumerable<Bulletin>> GetBulletinsByAuthorId(string authorId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
