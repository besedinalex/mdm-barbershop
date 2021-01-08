using System.Collections.Generic;
using System.Threading.Tasks;
using BarbershopMDM.Models;

namespace BarbershopMDM.Data.Repositories
{
    public interface ISuppliersRepository
    {
        /// <summary>Gets supplier.</summary>
        /// <param name="supplierId">Id of the supplier.</param>
        /// <returns>Returns supplier.</returns>
        Task<Supplier> GetSupplier(int supplierId);

        /// <summary>Gets supplier.</summary>
        /// <param name="supplierOGRN">Supplier's ORGN.</param>
        /// <returns>Returns supplier.</returns>
        Task<Supplier> GetSupplierByOGRN(ulong supplierOGRN);

        /// <summary>Gets all suppliers.</summary>
        /// <returns>Returns all suppliers.</returns>
        Task<List<Supplier>> GetSuppliers();

        /// <summary>Creates supplier.</summary>
        /// <param name="supplier">Supplier data.</param>
        /// <returns>Returns id of the new supplier.</returns>
        Task<int> CreateSupplier(Supplier supplier);

        /// <summary>Updates supplier.</summary>
        /// <param name="supplier">Supplier data.</param>
        Task UpdateSupplier(Supplier supplier);

        /// <summary>Removes supplier.</summary>
        /// <param name="supplier">Supplier data.</param>
        Task RemoveSupplier(Supplier supplier);
    }
}
