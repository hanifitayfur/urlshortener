using System;

namespace ITunes.UrlShortener.WebUI.Models
{
    public class ShortUrlResponseModel
    {
        public string LongUrl { get; set; }
        public string ShortUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}