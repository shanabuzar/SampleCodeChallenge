using Sample.Repositories.DTO;
using Sample.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Guid> Save(UpdateEmployeeDTO dto);
        Task<List<GetEmployeeDTO>> GetAll(string FirstName, string LastName, Gender? gender);
    }
}
