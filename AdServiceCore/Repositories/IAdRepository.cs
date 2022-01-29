using AdServiceCore.Filters;
using AdServiceCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdServiceCore.Repositories
{
    public interface IAdRepository
    {
        Task<IEnumerable<Ad>> GetAll();
        Task<IEnumerable<Ad>> GetAllPaginated(PaginationFilter validFilter);
        Task<Ad> GetById(int Id);
        Task CreateAd(Ad ad);
    }
}
