namespace Shop.Goods
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UnitOfMeasurement(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}