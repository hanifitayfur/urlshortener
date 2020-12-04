using System.Net;
using ITunes.UrlShortener.Entities.Entities;
using ITunes.UrlShortener.Entities.ResponseModel;

namespace ITunes.UrlShortener.Entities.Mapping
{
    public static class UrlShortMapper
    {
        public static ShortUrlResponseModel Map(ShortUrl shortUrl)
        {
            return new ShortUrlResponseModel
            {
                CreateDate = shortUrl.CreateDate,
                LongUrl = WebUtility.UrlDecode(shortUrl.LongURL),
                ShortUrl =WebUtility.UrlDecode(shortUrl.ShortURL)
            };

        }
    }
}