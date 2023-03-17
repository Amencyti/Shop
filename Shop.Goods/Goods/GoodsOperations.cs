namespace Shop.Goods
{
    public enum OperationsType
    {
        Sold,
        Return,
        Revaluation,
        Moving
    }

    public class GoodsOperation
    {
        public OperationsType operationsType;
        public Item item;
        public int quantity;
        public double price;

    }
}