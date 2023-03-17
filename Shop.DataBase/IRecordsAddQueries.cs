
using Shop.Structure;

namespace Shop.DataBase
{
    public interface IRecordsAddQueries
    {
        void SetDBContext(StoreDBContext dbContext);
        public Task AddStoreToDB(Store store);
        public Task AddOrganizationToDB(Organization organization);
        public Task AddWarehouseToDB(Warehouse warehouse);
    }

    public class RecordsAddQueries : IRecordsAddQueries
    {
        private StoreDBContext _dbContext;
        public async Task AddStoreToDB(Store store)
        {
            await _dbContext.Stores.AddAsync(store);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddOrganizationToDB(Organization organization)
        {
            await _dbContext.Organizations.AddAsync(organization);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddWarehouseToDB(Warehouse warehouse)
        {
            await _dbContext.Warehouses.AddAsync(warehouse);
            await _dbContext.SaveChangesAsync();
        }
        public async Task AddEmployeeToDB(Employee employee)
        {
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }
        public void SetDBContext(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}