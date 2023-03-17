namespace Shop.Goods
{
    public class TechModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public TechModel() { }

        public TechModel(string name, string uid, Manufacturer manufacturer)
        {
            this.Name = name;
            this.Uid = uid;
            this.Manufacturer = manufacturer;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}