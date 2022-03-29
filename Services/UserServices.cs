using Group3.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Group3.Repositories;

namespace Group3.Services
{
    public class UserServices
    {
        private readonly UserRepository _userRepository;

        public UserServices()
        {
            _userRepository = new UserRepository();
        }

        public User Get(string email, string password)
        {            
            try
            {
                return _userRepository.Get(email, password);
            }
            catch (Exception)
            {
                return new();
            }
        }

        public List<User> Get()
        {
            return _userRepository.Get();
        }

        public async Task<ActionResult<User>> Add(User User)
        {
            return await _userRepository.Add(User);

        }

        public async Task<User> Update(User user)
        {
            return await _userRepository.Update(user);
        }

        public User Delete(Guid id)
        {

            return _userRepository.Delete(id);
        }

        public bool UserExists(Guid id)
        {
            return _userRepository.Get().Any(e => e.UserId == id);
        }
    }
}
