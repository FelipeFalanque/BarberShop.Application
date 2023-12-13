using BarberShop.Application.BarberShop.Domain.Entities;

namespace BarberShop.Application.BarberShop.Domain.Interfaces
{
    public interface IService <TEntity> where TEntity : class
    {
        void Add(TEntity user);
        void Delete(TEntity user);
        void Edit(TEntity user);
        IEnumerable<TEntity> Get();
        TEntity Get(string code);
    }
}
