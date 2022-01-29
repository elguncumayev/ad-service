using AdServiceCore.Dtos;
using AdServiceCore.Repositories;
using AdServiceCore.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AdServiceCore.Models;
using AdServiceCore.Filters;

namespace AdServiceServices.Services
{
    public class AdService : IAdService
    {
        private readonly IAdRepository _repository;

        public AdService(IAdRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AdMainInfo>> GetAllAsync(PaginationFilter validFilter)
        {

            return (await _repository.GetAllPaginated(validFilter)).Select(ad => ad.AdToMainInfoDto());
        }

        public async Task<AdAllInfo> GetByIdAsync(int Id)
        {
            return (await _repository.GetById(Id)).AdToAllInfoDto();
        }

        public async Task CreateAdAsync(Ad ad)
        {
            await _repository.CreateAd(ad);
        }
    }
}
