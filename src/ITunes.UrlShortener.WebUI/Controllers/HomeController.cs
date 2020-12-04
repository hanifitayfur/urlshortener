using System.Diagnostics;
using ITunes.UrlShortener.WebUI.Helper;
using Microsoft.AspNetCore.Mvc;
using ITunes.UrlShortener.WebUI.Models;

namespace ITunes.UrlShortener.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static readonly string ApiBaseUrl = "http://localhost:5001/ShortUrl";

        public IActionResult Index(string shortUrl)
        {
            var restUri = $"{ApiBaseUrl}/get?shortUrl={shortUrl}";
            var result = RestHelper.GetMethod<ShortUrlResponseModel>(restUri);
            if (result != null && !string.IsNullOrEmpty(result.LongUrl))
            {
                Response.Redirect(result.LongUrl);
            }
            
            return Error();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}