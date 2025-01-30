using BLL.Entities;
using BLL.Mappers;
using D = DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Repositories;

namespace BLL.Services
{
    public class UserService : IUserRepository<User>
    {
        private IUserRepository<DAL.Entities.User> _service;

        public UserService(IUserRepository<DAL.Entities.User> userService)
        {
            _service = userService;    
        }

        public IEnumerable<User> Get()
        {
            return _service.Get().Select(dal => dal.ToBLL());
        }

        public User Get(Guid user_id) { 
            return _service.Get(user_id).ToBLL();
        }

        public Guid Insert(User user)
        {
            return _service.Insert(user.ToDAL());
        }

        public void Update(Guid user_id, User user)
        {
            _service.Update(user_id, user.ToDAL());
        }

        public void Delete(Guid user_id) {
            _service.Delete(user_id);
        }

        public Guid CheckPassword(string email, string password)
        {
            return _service.CheckPassword(email, password);
        }
    }
}
