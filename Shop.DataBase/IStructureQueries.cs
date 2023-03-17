using Microsoft.EntityFrameworkCore;
using Shop.Structure;

namespace Shop.DataBase
{
    public interface IStructureQueries
    {
        void SetDBContext(StoreDBContext dbContext);
        Task<Organization> OrganizationFromDB(string edrpou);
        Task<List<Organization>> AllOrganizationFromDB();
        Task<List<Warehouse>> AllWarehousesFromDB();
        Task<List<Store>> AllStoresFromDB();
		Task<List<Account>> AllAccountsFromDB();
		Task<List<Employee>> AllEmployeesFromDB();

	}

    public class StructureQueries : IStructureQueries
    {
        private StoreDBContext _dbContext;

        public virtual Task<Organization> OrganizationFromDB(string edrpou)
        {
            return _dbContext.Organizations.FirstOrDefaultAsync(x => x.Edrpou == edrpou);
        }

        public virtual Task<List<Organization>> AllOrganizationFromDB()
        {
            return _dbContext.Organizations.
            Include(x => x.MainAccount).
            Include(x => x.Ceo).
            Include(x => x.CashierCentral).ToListAsync<Organization>();
        }

        public virtual Task<List<Store>> AllStoresFromDB()
        {
            return _dbContext.Stores.ToListAsync<Store>();
        }

        public virtual Task<List<Warehouse>> AllWarehousesFromDB()
        {
            return _dbContext.Warehouses.ToListAsync<Warehouse>();
        }
		public virtual Task<List<Account>> AllAccountsFromDB()
		{
			return _dbContext.Accounts.ToListAsync<Account>();
		}
		public virtual Task<List<Employee>> AllEmployeesFromDB()
		{
			return _dbContext.Employees.ToListAsync<Employee>();
		}

		public void SetDBContext(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}