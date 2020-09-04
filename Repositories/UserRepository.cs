using System;
using System.Collections.Generic;
using UserApi.Models;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _storage;

        public UserRepository()
        {
            _storage = new List<User>();
        }

        public void AddUser(User user)
        {
            _storage.Add(user);
        }

        public User GetById(Guid Id)
        {
            return _storage.Find(user => user.Id == Id);
        }

        public IEnumerable<User> ListUsers()
        {
            return _storage;
        }

        public void RemoveUser(User user)
        {
            _storage.Remove(user);
        }

        public void UpdateUser(User user)
        {
            var userFoundIndex = _storage.FindIndex(0, 1, userFound => userFound.Id == user.Id);
            _storage[userFoundIndex] = user;
        }
    }
}