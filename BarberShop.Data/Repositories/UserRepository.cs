using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public void Add(User user)
        {
            UserDataBase.Users.Add(user);
        }

        public void Delete(User user)
        {
            UserDataBase.Users.RemoveAll(x => x.Code == user.Code);
        }

        public void Edit(User user)
        {
            UserDataBase.Users.RemoveAll(x => x.Code == user.Code);
            UserDataBase.Users.Add(user);
        }

        public IEnumerable<User> Get()
        {
            return UserDataBase.Users;
        }

        public User Get(string code)
        {
            return UserDataBase.Users.First(x => x.Code == code);
        }
    }
}
