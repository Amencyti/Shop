namespace Shop.Structure
{
    public class Store
    {
        public int Id { get; set; }
        public string Suffix { get; set; }
        public string Name { get; set; }
        public string Edrpou { get; set; }
        public string ActualAdress { get; set; }
        public Organization Organization { get; set; }
        public Warehouse Warehouse { get; set; }
        public Account BankAccount { get; set; }
        public Account CashAccount { get; set; }
        public Account RegistrationAccount { get; set; }
        public List<Employee> Employees { get; set; }
    }
}