using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface IService <TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Edit(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity Get(string code);
    }
}
