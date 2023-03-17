namespace Shop.Goods
{
    public class TechItem : Item
    {
        public TechModel Model { get; set; }
        public TechType Type { get; set; }
        public Manufacturer Manufacturer { get; set; }

        public TechItem(){}
    }
}