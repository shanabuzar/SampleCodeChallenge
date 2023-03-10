
using Sample.Repositories.DTO;
using Sample.Repositories.Interfaces;
using Sample.Services.Interfaces;
using Sample.Utilities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _repoService;
        public EmployeeService(IEmployeeRepository repoService) => _repoService = repoService;

        public async Task<Guid> Save(UpdateEmployeeDTO dto)
        {
            if (dto.Id == Guid.Empty)
                return await _repoService.Insert(new InsertEmployeeDTO { FirstName = dto.FirstName, LastName = dto.LastName, Age = dto.Age, Gender = dto.Gender });
            else
                await _repoService.Update(dto);
                return dto.Id;
        }

        public async Task<List<GetEmployeeDTO>> GetAll(string FirstName, string LastName, Gender? Gender)
        { 
            var employees = await _repoService.GetAll();
            return employees.Where(x => (x.FirstName == FirstName || FirstName == string.Empty) && 
            (x.LastName == LastName || LastName == string.Empty) &&
            (x.Gender == Gender || Gender == null)).ToList();
        }

    }
}
