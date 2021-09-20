using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CountryCodes.Content.Providers
{
  
        public interface IProvider<TEntity>
        {
            Task<TEntity> Get(string predicate);
        }
    }
