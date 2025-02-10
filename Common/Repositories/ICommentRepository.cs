using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface ICommentRepository<TComment> :
        IInsertRepository<TComment, Guid>,
        IUpdateRepository<TComment, Guid>,
        IDeleteRepository<TComment, Guid>
    {
        TComment Get(Guid id);
        IEnumerable<TComment> GetByUserId(Guid user_id);
        IEnumerable<TComment> GetByCocktailId(Guid cocktail_id);
    }
}
