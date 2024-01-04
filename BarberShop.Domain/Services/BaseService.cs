using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class BaseService<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> repository;

        public BaseService(IRepository<TEntity> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Add(TEntity entity)
        {
            repository.Add(entity);
            // Lógica adicional, se necessário
        }

        public void Delete(TEntity entity)
        {
            repository.Delete(entity);
            // Lógica adicional, se necessário
        }

        public void Edit(TEntity entity)
        {
            repository.Edit(entity);
            // Lógica adicional, se necessário
        }

        public IEnumerable<TEntity> Get()
        {
            return repository.Get();
            // Lógica adicional, se necessário
        }

        public TEntity Get(string code)
        {
            return repository.Get(code);
            // Lógica adicional, se necessário
        }
    }
}
