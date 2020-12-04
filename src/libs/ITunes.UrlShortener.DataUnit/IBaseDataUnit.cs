using System;
using System.Collections.Generic;

namespace ITunes.UrlShortener.DataUnit
{
    public interface IBaseDataUnit<T> where T: class
    {
        T Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        
        public IList<T> List();
        
        public void Add(T entity);
    }
}