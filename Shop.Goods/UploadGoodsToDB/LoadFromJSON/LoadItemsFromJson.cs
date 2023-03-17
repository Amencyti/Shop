using Newtonsoft.Json;
using System.Globalization;
using Shop.Goods;
using Shop.DataBase;

public class LoadItemsFromJson
{
    //string path = "/Users/a1111/Projects/shopBlazor/Shop.Goods/UploadGoodsToDB/LoadFromJSON/testItems.json";
    string path = "E:/VisualStudioProjects/Shop/Shop.Goods/UploadGoodsToDB/LoadFromJSON/testItems.json";

    public void LoadFromFile()
    {

        using (StreamReader reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            Root goods = JsonConvert.DeserializeObject<Root>(json); 
            Task uploadTask = UploadItemsAsync(goods);
            if (uploadTask.Status == TaskStatus.Faulted)
            {
                System.Console.WriteLine(uploadTask.Exception.Message);
            }
            else
            {
                System.Console.WriteLine("upload done");
            }
        }

    }

    private static async Task UploadItemsAsync(Root goods) //роботу з дб я б виніс в окремий клас і інтерфейс до нього
    {
        using (StoreDBContext db = new StoreDBContext())
        {
            foreach (var item in goods.rows)
            {
                TechItem techItem = new TechItem();
                techItem.Article = item.art;
                techItem.Available = true;
                techItem.SelfCost = GetDouble(item.income);
                techItem.Cost = GetDouble(item.price);
                techItem.ItemType = ItemType.Tech;
                techItem.Name = item.name;
                techItem.Uid = item.itemUID;
                techItem.UnitOfMeasurement = GetUnitOfMeasurement(item.model, db);
                Manufacturer manufacturer = GetMnufacturer(item.model, db);
                techItem.Manufacturer = manufacturer;
                techItem.Model = GetTechModel(item.model, db, manufacturer);
                techItem.Type = GetTechType(item.model, db);
                techItem.Count = 1;

                db.Add(techItem);
                //saving changes in the database in a cycle is not the best option, need to rewrite as time goes by
                await db.SaveChangesAsync();
            }
        }
    }

    private static double GetDouble(string chars)
    {
        string onlyNums =  new string((from c in chars
                                           where c!=' '
                                           select c).ToArray());
        return Convert.ToDouble(onlyNums, CultureInfo.InvariantCulture);
    }

    private static UnitOfMeasurement GetUnitOfMeasurement(Model model, StoreDBContext db)
    {
        UnitOfMeasurement unitOfMeasurementfromDB = db.GoodsQueries.UnitOfMeasurementromDB("шт.");
        if (unitOfMeasurementfromDB == null)
        {
            return new UnitOfMeasurement("шт.");
        }
        else
        {
            return unitOfMeasurementfromDB;
        }
    }

    private static Manufacturer GetMnufacturer(Model model, StoreDBContext db)
    {
        Manufacturer manufacturerFromDB = db.GoodsQueries.ManufacturerFromDB(model.brandUID);
        if (manufacturerFromDB == null)
        {
            return new Manufacturer(model.brand, model.brandUID);
        }
        else
        {
            return manufacturerFromDB;
        }
    }

    private static TechType GetTechType(Model model, StoreDBContext db)
    {
        TechType techTypeFromDB = db.GoodsQueries.TechTypeFromDB(model.typeUID);
        if (techTypeFromDB == null)
        {
            return new TechType(model.type, model.typeUID);
        }
        else
        {
            return techTypeFromDB;
        }
    }

    private static TechModel GetTechModel(Model model, StoreDBContext db, Manufacturer manufacturer)
    {
        TechModel techModelFromDB = db.GoodsQueries.TechModelFromDB(model.labelUID);
        if (techModelFromDB == null)
        {
            return new TechModel(model.label, model.labelUID, manufacturer);
        }
        else
        {
            return techModelFromDB;
        }
    }

}
