using Sample.Repositories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<Guid> Insert(InsertEmployeeDTO dto);
        Task<bool> Update(UpdateEmployeeDTO dto);
        Task<bool> Delete(Guid Id);
        Task<List<GetEmployeeDTO>> GetAll();
    }
}
