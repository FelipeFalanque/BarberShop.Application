using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;

namespace BarberShop.Application.BarberShop.Data.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        public PackageRepository()
        {
        }

        public void Add(Package package)
        {
            PackageDataBase.Packages.Add(package);
        }

        public void Delete(Package package)
        {
            PackageDataBase.Packages.RemoveAll(x => x.Code == package.Code);
        }

        public void Edit(Package package)
        {
            PackageDataBase.Packages.RemoveAll(x => x.Code == package.Code);
            PackageDataBase.Packages.Add(package);
        }

        public IEnumerable<Package> Get()
        {
            return PackageDataBase.Packages;
        }

        public Package Get(string code)
        {
            return PackageDataBase.Packages.FirstOrDefault(x => x.Code == code);
        }
    }
}
