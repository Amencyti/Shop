using System.ComponentModel.DataAnnotations;

namespace Shop.Structure
{
    public class Organization
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
        public string FullName { get; set; }
        public string LegalAdress { get; set; }
        public string ActualAdress { get; set; }
        public string Phone { get; set; }
        public string Edrpou { get; set; }
        public string Inn { get; set; }
        public string CertificateNumber { get; set; }
        public Account MainAccount { get; set; }
        public Employee Ceo { get; set; }
        public Employee CashierCentral { get; set; }

        public Organization() { }
        
    }
}
