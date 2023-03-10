
using Sample.Utilities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sample.Domains.Entities
{
    public class Employee : BaseModel
    {

        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public int Age { get; set; }
        public Gender gender { get; set; }
        [NotMapped]
        public string FullName { get; }

        public Employee() => FullName = $"{FirstName} {LastName}";
    }
}
