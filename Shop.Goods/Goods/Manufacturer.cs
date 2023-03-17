
namespace Shop.Goods
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }

        public Manufacturer() { }
        
        public Manufacturer(string name, string uid)
        {
            this.Name = name;
            this.Uid = uid;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}