using System;
using System.Collections.Generic;
using UserApi.Models;

namespace UserApi.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void UpdateUser(User user);
        IEnumerable<User> ListUsers();
        User GetById(Guid Id);
        void RemoveUser(User user);
    }
}