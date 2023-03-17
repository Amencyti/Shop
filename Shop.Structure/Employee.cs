using System.ComponentModel.DataAnnotations;

namespace Shop.Structure
{
    public class Employee
    {
        public int Id { get; set; }
        public int PinCode { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Surname is required")]
		public string SurName { get; set; }
        public DateOnly DateBirth { get; set; }
		[Required(ErrorMessage = "INN is required")]
		public int Inn { get; set; }
        public Gender Gender { get; set; }
    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }
}

