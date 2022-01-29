using AdServiceCore.Filters;
using AdServiceCore.Models;
using AdServiceCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdServiceData.Repository
{
    public class SqlServerAdsRepository : IAdRepository
    {
        private readonly AppDbContext _dbContext;

        public SqlServerAdsRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Ad>> GetAll()
        {
            return await _dbContext.Ads.Include(ad => ad.LinksForPhotos).ToListAsync();
        }

        public async Task<IEnumerable<Ad>> GetAllPaginated(PaginationFilter validFilter)
        {
            var queryable = _dbContext.Ads
                .Include(ad => ad.LinksForPhotos);
            IOrderedQueryable<Ad> newQueryable;
            if (validFilter.OrderBy.Equals("price"))
            {
                if (validFilter.OrderAsc) newQueryable = queryable.OrderBy(ad => ad.Price);
                else newQueryable = queryable.OrderByDescending(ad => ad.Price);
            }
            else
            {
                if (validFilter.OrderAsc) newQueryable = queryable.OrderBy(ad => ad.CreatedDate);
                else newQueryable = queryable.OrderByDescending(ad => ad.CreatedDate);
            }

            return await newQueryable
                .Skip((validFilter.PageNumber - 1)*validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Ad> GetById(int Id)
        {
            return await _dbContext.Ads.Include(ad => ad.LinksForPhotos).FirstOrDefaultAsync(ad => ad.ID == Id);
        }

        public async Task CreateAd(Ad ad)
        {
           await _dbContext.Ads.AddAsync(ad);
           await _dbContext.SaveChangesAsync();
        }
    }
}
