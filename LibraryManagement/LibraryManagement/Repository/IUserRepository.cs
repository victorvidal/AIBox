using LibraryManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Repository
{
    public interface IUserRepository
    {
        int Add(User user);
        List<User> GetUsers();
        User Get(int id);
        int Edit(User user);
        int Delete(int id);

    }
}