namespace Shop.Structure
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Employee> Employees { get; set; }
        public Store Store { get; set; }
    }
}