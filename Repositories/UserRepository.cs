using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public UserRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public async Task<User> UpdateUser(User user)
        {
            try
            {
                var result = _entitiesContext.Update(user);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Error while updating changes: " + e);
                return null;
            }
        }

        public User DeleteUser(int userId)
        {
            var userDel = _entitiesContext.User.FirstOrDefault(a => a.UsuarioId == userId);
            _entitiesContext.Remove(userDel);
            _entitiesContext.SaveChangesAsync();
            return userDel;
        }
    }
}
