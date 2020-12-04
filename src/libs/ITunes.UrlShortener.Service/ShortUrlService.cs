using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ITunes.UrlShortener.DataUnit;
using ITunes.UrlShortener.Entities.Dto;
using ITunes.UrlShortener.Entities.Entities;
using ITunes.UrlShortener.Entities.Mapping;
using ITunes.UrlShortener.Entities.ResponseModel;

namespace ITunes.UrlShortener.Service
{
    public interface IShortUrlService
    {
        ShortUrlResponseModel Get(string shorturl);

        IList<ShortUrlResponseModel> List();

        ShortUrlResponseModel Add(ShortUrlRequestModel shortUrlRequestModel);
    }

    public class ShortUrlService : IShortUrlService
    {
        private readonly IShortUrlDataUnit _shortUrlDataUnit;

        public ShortUrlService(IShortUrlDataUnit shortUrlDataUnit)
        {
            _shortUrlDataUnit = shortUrlDataUnit;
        }


        public IList<ShortUrlResponseModel> List()
        {
            var shortUrlList = _shortUrlDataUnit.List().ToList();

            var responseList = shortUrlList.Select(shortUrl => UrlShortMapper.Map(shortUrl)).ToList();

            return responseList;
        }

        public ShortUrlResponseModel Add(ShortUrlRequestModel shortUrlRequestModel)
        {
            var shortUrlEntity = new ShortUrl
            {
                CreateDate = DateTime.Now,
                LongURL = WebUtility.UrlEncode(shortUrlRequestModel.LongURL),
                ShortURL = GetShortUrl()
            };

            _shortUrlDataUnit.Add(shortUrlEntity);

            return UrlShortMapper.Map(shortUrlEntity);
        }

        public ShortUrlResponseModel Get(string shortUrl)
        {
            var encodeUrl = WebUtility.UrlEncode(shortUrl);

            var entityShortUrl = _shortUrlDataUnit.Get(url => url.ShortURL.Equals(encodeUrl));

            return entityShortUrl == null
                ? null
                : UrlShortMapper.Map(entityShortUrl);
        }

        private string GetShortUrl()
        {
            var generateShortUrl = ShortUrlGenerator.Generate();
            var isValid = _shortUrlDataUnit.Get(url => url.ShortURL.Equals(generateShortUrl));

            if (isValid != null)
            {
                GetShortUrl();
            }

            return generateShortUrl;
        }
    }
}