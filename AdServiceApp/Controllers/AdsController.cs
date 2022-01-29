using AdServiceCore.Dtos;
using AdServiceCore.Filters;
using AdServiceCore.Models;
using AdServiceCore.Services;
using AdServiceServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdService _adService;

        public AdsController(IAdService adService)
        {
            _adService = adService;
        }

        // GET: api/<AdsController>
        [HttpGet]
        public async Task<IEnumerable<AdMainInfo>> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            PaginationFilter validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, filter.OrderBy, filter.OrderAsc);
            return await _adService.GetAllAsync(validFilter);
        }

        // GET api/<AdsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, [FromQuery(Name ="allData")] bool allData = false)
        {
            var adAllInfo = await _adService.GetByIdAsync(id);
            if(adAllInfo == null)
            {
                return NotFound();
            }
            if (allData)
            {
                return Ok(adAllInfo);
            }
            else
            {
                return Ok(adAllInfo.AdAllInfoToMainInfo());
            }
        }

        // POST api/<AdsController>
        [HttpPost]
        public async Task<ActionResult<Ad>> CreateAsync([FromBody] AdCreateInfo adCreateInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Ad newAd = adCreateInfo.CreateInfoToAd();
            await _adService.CreateAdAsync(newAd);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = newAd.ID }, newAd);
        }
    }
}
