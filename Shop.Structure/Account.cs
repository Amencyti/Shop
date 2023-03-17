using System.ComponentModel.DataAnnotations;

namespace Shop.Structure
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountNubmer { get; set; }
    }
}