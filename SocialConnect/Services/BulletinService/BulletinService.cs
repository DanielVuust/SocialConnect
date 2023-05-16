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
                    MemberId = bulletinDto.AuthorId,
                    Name = bulletinDto.Name,
                    Description = bulletinDto.Description
                };

                await _bulletinRepository.CreateBulletin(bulletinEntity);

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
