using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICocktailRepository<TCocktail> : ICRUDRepository<TCocktail, Guid>
    {
        IEnumerable<TCocktail> GetFromUser(Guid user_id);
    }
}
