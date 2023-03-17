using Shop.Goods;

namespace Shop.Transactions
{
    public class SalesList
    {
        public TechItem item{ get; set; }
        public int count { get; set; }
        public double priseSell { get; set; }
        public DateTime dateSell { get; set; }
        public double discount { get; set; }
        public int id { get; set; }
        public int orderId { get; set; }
        public string client { get; set; }
    }
}