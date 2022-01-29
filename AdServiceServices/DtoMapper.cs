using AdServiceCore.Dtos;
using AdServiceCore.Models;
using System.Linq;

namespace AdServiceServices
{
    public static class DtoMapper
    {
        public static AdMainInfo AdToMainInfoDto(this Ad ad) => ad != null ? new AdMainInfo
        {
            Title = ad.Title,
            Price = ad.Price,
            MainPhotoUrl = (ad.LinksForPhotos != null && ad.LinksForPhotos.Any()) ? ad.LinksForPhotos[0].Url : null
        } : null;
        
        public static AdAllInfo AdToAllInfoDto(this Ad ad) => ad != null ? new AdAllInfo
        {
            Title = ad.Title,
            Price = ad.Price,
            Description = ad.Description,
            LinksForPhotos = (ad.LinksForPhotos != null && ad.LinksForPhotos.Any()) ? ad.LinksForPhotos.ConvertAll(link => link.Url) : null
        } : null;

        public static AdMainInfo AdAllInfoToMainInfo(this AdAllInfo adAllInfo) => adAllInfo != null ? new AdMainInfo
        {
            Title = adAllInfo.Title,
            Price = adAllInfo.Price,
            MainPhotoUrl = (adAllInfo.LinksForPhotos != null && adAllInfo.LinksForPhotos.Any()) ? adAllInfo.LinksForPhotos[0] : null 
        } : null;

        public static Ad CreateInfoToAd(this AdCreateInfo adCreateInfo)
        {
            return new Ad
            {
                Title = adCreateInfo.Title,
                Description = adCreateInfo.Description,
                Price = adCreateInfo.Price,
                LinksForPhotos = adCreateInfo.LinksForPhotos.ConvertAll( data => new Link { Url = data })
            };
        }
    }
}
