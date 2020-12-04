using ITunes.UrlShortener.DataUnit;
using ITunes.UrlShortener.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITunes.UrlShortener.Api.Startups
{
    public  static class DIConfiguration
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
            var mongoDbSetting = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();

            services.AddTransient<IShortUrlDataUnit>(s => new ShortUrlDataUnit(mongoDbSetting.ConnectionString, mongoDbSetting.DBName, mongoDbSetting.CollectionName));

            services.AddTransient<IShortUrlService, ShortUrlService>();
        }
    }
}