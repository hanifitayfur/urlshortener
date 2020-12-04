using ITunes.UrlShortener.Entities.Dto;
using ITunes.UrlShortener.Service;
using Microsoft.AspNetCore.Mvc;

namespace ITunes.UrlShortener.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShortUrlController : ControllerBase
    {
        readonly IShortUrlService _shortUrlService;

        public ShortUrlController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ShortUrlRequestModel shortUrlRequestModel)
        {
            if (ModelState.IsValid)
            {
                _shortUrlService.Add(shortUrlRequestModel);
                return Ok();
            }

            return BadRequest(ModelState.Values);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult ListAll()
        {
            var shortUrls = _shortUrlService.List();
            return Ok(shortUrls);
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get(string shortUrl)
        {
            if (string.IsNullOrEmpty(shortUrl))
                return NotFound();

            var urlItem = _shortUrlService.Get(shortUrl);

            if (urlItem == null)
                return NotFound();

            return Ok(urlItem);
        }
    }
}