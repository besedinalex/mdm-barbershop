using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    class SuppliersRepository : ISuppliersRepository
    {
        private readonly DataContext _context;

        public SuppliersRepository(DataContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<Supplier> GetSupplier(int supplierId) =>
            _context.Suppliers.FirstOrDefaultAsync(x => x.Id == supplierId);

        /// <inheritdoc />
        public Task<Supplier> GetSupplierByOGRN(ulong supplierOGRN) =>
            _context.Suppliers.FirstOrDefaultAsync(x => x.OGRN == supplierOGRN);

        /// <inheritdoc />
        public Task<List<Supplier>> GetSuppliers() =>
            _context.Suppliers.ToListAsync();

        /// <inheritdoc />
        public async Task<int> CreateSupplier(Supplier supplier)
        {
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync();
            return supplier.Id;
        }

        /// <inheritdoc />
        public Task UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public Task RemoveSupplier(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            return _context.SaveChangesAsync();
        }
    }
}
