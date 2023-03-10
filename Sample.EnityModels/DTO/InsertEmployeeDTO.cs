
using Sample.Utilities.Enums;

namespace Sample.Repositories.DTO
{
    public class InsertEmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Gender gender { get; set; }
    }
}
