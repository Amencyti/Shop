using Shop.Structure;

namespace Shop.Goods
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Article { get; set; }
        public string Uid { get; set; }
        public string Name { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool Available { get; set; }
        public decimal Cost { get; set; }
        public ItemType ItemType { get; set; }
        public decimal SelfCost { get; set; }
        public int Count { get; set; }
        public Store Store { get; set; }
        public Warehouse Warehouse { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public enum ItemType
    {
        Tech,
        Gold
    }
}









