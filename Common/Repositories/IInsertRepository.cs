using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public interface IInsertRepository<TEntity, TId>
    {
        TId Insert(TEntity entity);
    }
}
