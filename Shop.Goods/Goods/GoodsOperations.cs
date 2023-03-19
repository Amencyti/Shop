namespace Shop.Goods
{
    public enum OperationsType
    {
        Sold,
        Return,
        Revaluation,
        Moving
    }

    public class Sale
    {
        public int SalesID { get; set; }
        public DateTime SalesDate { get; set; }
        public int ProductID { get; set; }
        public int QuantitySold { get; set; }
        public decimal TotalSalePrice { get; set; }
    }

    public class Return
    {
        public int ReturnID { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ProductID { get; set; }
        public int QuantityReturned { get; set; }
        public decimal TotalReturnPrice { get; set; }
    }

    public class Revaluation
    {
        public int RevaluationID { get; set; }
        public DateTime RevaluationDate { get; set; }
        public int ProductID { get; set; }
        public decimal PreviousPrice { get; set; }
        public decimal NewPrice { get; set; }
    }

    public class Moving
    {
        public int MoveID { get; set; }
        public DateTime MoveDate { get; set; }
        public int ProductID { get; set; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int QuantityMoved { get; set; }
    }
}