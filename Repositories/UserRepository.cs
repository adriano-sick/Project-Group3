using Group3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Repositories
{
    public class UserRepository
    {
        private readonly EntitiesContext _entitiesContext;

        public UserRepository()
        {
            _entitiesContext = new EntitiesContext();
        }

        public User Get(string email, string password)
        {
            var users = _entitiesContext.User.ToList();
            return users.Where(x => x.Email.ToLower() == email.ToLower() && x.Password == password).FirstOrDefault();
        }

        public List<User> Get(string role)
        {
            var users = _entitiesContext.User.ToList();
            return users.Where(x => x.Role.ToLower() == role.ToLower()).ToList();
        }

        public List<User> Get()
        {
            return _entitiesContext.User.ToList();
        }

        public async Task<User> Add(User user)
        {
            try
            {
                var result = await _entitiesContext.AddAsync(user);
                await _entitiesContext.SaveChangesAsync();

                return result.Entity;
            }
            catch (Exception e)
            {
                Console.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                var result = _entitiesContext.Update(user);
                await _entitiesContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Deu Ruim! -> Erro while trying to save changes. Error: " + e);
                return null;
            }
        }

        public User Delete(Guid id)
        {
            var userDel = _entitiesContext.User.FirstOrDefault(a => a.UserId == id);
            _entitiesContext.Remove(userDel);
            _entitiesContext.SaveChangesAsync();
            return userDel;
        }
    }
}
