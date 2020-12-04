using ITunes.UrlShortener.Entities.Validation;
using System.ComponentModel.DataAnnotations;


namespace ITunes.UrlShortener.Entities.Dto
{
    public class ShortUrlRequestModel
    {
        [Required]
        [UrlValidation(ErrorMessage = "Url hatalı")]
        public string LongURL { get; set; }
    }
}