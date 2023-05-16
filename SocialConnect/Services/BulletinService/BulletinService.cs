using SocialConnect.Model;
using SocialConnect.Repository.BulletinRepository;
using SocialConnect.Services.Dtos;

namespace SocialConnect.Services.BulletinService
{
    public class BulletinService : IBulletinService
    {

        private readonly IBulletinRepository _bulletinRepository;

        public BulletinService(IBulletinRepository bulletinRepository)
        {
            _bulletinRepository = bulletinRepository;
        }

        public async Task CreateBulletin(BulletinDto bulletinDto)
        {
            try
            {
                if (bulletinDto == null)
                {
                    throw new Exception();
                }

                var bulletinEntity = new Bulletin
                {
                    MemberId = bulletinDto.MemberId,
                    Title = bulletinDto.Title,
                    Description = bulletinDto.Description
                };

                await _bulletinRepository.CreateBulletin(bulletinEntity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Bulletin>> GetBulletins()
        {
            try
            {
                var bulletins = await _bulletinRepository.GetBulletins();
                return bulletins.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public async Task UpdateBulletin(BulletinDto bulletinDto)
        //{
        //    try
        //    {
        //        if (bulletinDto == null)
        //        {
        //            throw new Exception();
        //        }
        //        var bulletinEntity = new Bulletin
        //        {
        //            // Id = bulletinDto.Id,
        //            AuthorId = bulletinDto.AuthorId,
        //            Name = bulletinDto.Name,
        //            Description = bulletinDto.Description
        //        };
        //        await _bulletinRepository.UpdateBulletin(bulletinEntity);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
