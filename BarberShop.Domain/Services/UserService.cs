using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Add(User user)
        {
            user.Code = Guid.NewGuid().ToString();
            user.DateRegister = DateTime.Now;
            user.Administrator = false;

            _userRepository.Add(user);
        }

        public void Delete(User user)
        {
            _userRepository.Delete(user);
        }

        public void Edit(User user)
        {
            _userRepository.Edit(user);
        }

        public IEnumerable<User> Get()
        {
            return _userRepository.Get();
        }

        public User Get(string code)
        {
            return _userRepository.Get(code);
        }

        public User GetByEmailOrPhone(string emailOrPhone)
        {
            return _userRepository.Get().FirstOrDefault(u => u.Email == emailOrPhone || u.Phone == emailOrPhone);
        }
    }
}
