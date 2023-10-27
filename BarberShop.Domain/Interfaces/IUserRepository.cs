using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Delete(User user);
        void Edit(User user);
        IEnumerable<User> Get();
        User Get(string code);
    }
}
