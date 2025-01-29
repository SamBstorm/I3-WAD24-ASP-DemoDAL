using BLL.Entities;
using BLL.Mappers;
using D = DAL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private D.UserService _service;

        public UserService(D.UserService userService)
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
