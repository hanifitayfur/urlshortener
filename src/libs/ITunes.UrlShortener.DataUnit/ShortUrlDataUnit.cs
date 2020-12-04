using ITunes.UrlShortener.Entities.Entities;

namespace ITunes.UrlShortener.DataUnit
{
    public interface IShortUrlDataUnit: IBaseDataUnit<ShortUrl>
    {
    }

    public class ShortUrlDataUnit : MongoDbBaseDataUnit<ShortUrl>, IShortUrlDataUnit
    {
        public ShortUrlDataUnit(string mongoDbConnectionString, string dbName, string collectionName) 
            : base(mongoDbConnectionString, dbName, collectionName)
        {
        }
    }
}