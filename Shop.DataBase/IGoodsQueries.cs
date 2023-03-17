using Microsoft.EntityFrameworkCore;
using Shop.Goods;

namespace Shop.DataBase
{
    public interface IGoodsQueries
    {
        void SetDBContext(StoreDBContext dbContext);
        TechModel TechModelFromDB(string uid);
        TechType TechTypeFromDB(string uid);
        UnitOfMeasurement UnitOfMeasurementromDB(string name);
        Manufacturer ManufacturerFromDB(string uid);
        List<TechItem> GetAllTechItems();
        TechItem GetTechItemFromDB(string article);

        void SoldItems(List<TechItem> itemsList);
    }

    public class GoodsQueries : IGoodsQueries
    {
        private StoreDBContext _dbContext;

        public virtual TechModel TechModelFromDB(string uid)
        {
            return _dbContext.TechModels.FirstOrDefault(x => x.Uid == uid);
        }
        public virtual TechType TechTypeFromDB(string uid)
        {
            return _dbContext.TechTypes.FirstOrDefault(x => x.Uid == uid);
        }
        public virtual UnitOfMeasurement UnitOfMeasurementromDB(string name)
        {
            return _dbContext.UnitOfMeasurements.FirstOrDefault(x => x.Name == name);
        }
        public virtual Manufacturer ManufacturerFromDB(string uid)
        {
            return _dbContext.Manufacturers.FirstOrDefault(x => x.Uid == uid);
        }
        public List<TechItem> GetAllTechItems()
        {
            return _dbContext.TechItems.
            Include(m => m.Model).
            Include(t => t.Type).
            Include(m => m.Manufacturer).ToList();
        }

        public TechItem GetTechItemFromDB(string article)
        {
            return _dbContext.TechItems.
            Include(m => m.Model).
            Include(t => t.Type).
            Include(m => m.Manufacturer).FirstOrDefault(x => x.Article == article);
        }

        public void SoldItems(List<TechItem> itemsList)
        {
            foreach (TechItem item in itemsList)
            {
                TechItem itemDB = _dbContext.TechItems.Find(item.Id);
                itemDB.Count = itemDB.Count - 1;
            }
            _dbContext.SaveChanges();
        }

        public void SetDBContext(StoreDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}