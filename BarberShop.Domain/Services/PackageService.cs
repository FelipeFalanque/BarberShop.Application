using BarberShop.Application.BarberShop.Data.Repositories;
using BarberShop.Application.BarberShop.Domain.Entities;
using BarberShop.Application.BarberShop.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace BarberShop.Application.BarberShop.Domain.Services
{
    public class PackageService : BaseService<Package>, IPackageService
    {
        private readonly IPackageRepository packageRepository;

        public PackageService(IPackageRepository packageRepository)
            : base(packageRepository)
        {
            this.packageRepository = packageRepository ?? throw new ArgumentNullException(nameof(packageRepository));
        }
    }
}
