using BLL.Entities;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CocktailService : ICocktailRepository<Cocktail>
    {
        private ICocktailRepository<DAL.Entities.Cocktail> _service;

        public CocktailService()
        {
            _service = new DAL.Services.CocktailService();
        }
        public void Delete(Guid cocktail_id)
        {
            _service.Delete(cocktail_id);
        }

        public IEnumerable<Cocktail> Get()
        {
            return _service.Get().Select(dal => dal.ToBLL());
        }

        public Cocktail Get(Guid cocktail_id)
        {
            return _service.Get(cocktail_id).ToBLL();
        }

        public Guid Insert(Cocktail cocktail)
        {
            return _service.Insert(cocktail.ToDAL());
        }

        public void Update(Guid cocktail_id, Cocktail cocktail)
        {
            _service.Update(cocktail_id, cocktail.ToDAL());
        }
    }
}
