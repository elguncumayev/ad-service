using AdServiceCore.Dtos;
using AdServiceCore.Filters;
using AdServiceCore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdServiceCore.Services
{
    public interface IAdService
    {
        Task<IEnumerable<AdMainInfo>> GetAllAsync(PaginationFilter validFilter);
        Task<AdAllInfo> GetByIdAsync(int Id);
        Task CreateAdAsync(Ad ad);
    }
}
