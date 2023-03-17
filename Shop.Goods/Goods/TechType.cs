namespace Shop.Goods
{
    public class TechType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }

        public TechType(string name, string uid)
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