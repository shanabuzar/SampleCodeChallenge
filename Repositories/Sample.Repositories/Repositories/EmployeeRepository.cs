using Sample.Domains.Entities;
using Sample.Repositories.DTO;
using Sample.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Repositories
{
  

    public class EmployeeRepository : IEmployeeRepository
    {
        public SampleDbContext _context { get; set; }
        public EmployeeRepository(SampleDbContext context) => _context = context;
        public async Task<Guid> Insert(InsertEmployeeDTO dto)
        {
            var entity = _context.employees.Add(new Employee
            {
               
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Age = dto.Age,
                gender = dto.gender

            });
            entity.Id = Guid.NewGuid();
            await _context.SaveChangesAsync();
            return entity.Id;
        }
        public async Task<bool> Update(UpdateEmployeeDTO dto)
        { 
            var employee = _context.employees.SingleOrDefault(x => x.Id == dto.Id && x.DeletedDate == null);
            if (employee == null) return false;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Age = dto.Age;
            employee.gender = dto.gender;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(Guid Id)
        {
            var employee = _context.employees.SingleOrDefault(x => x.Id == Id );
            if (employee == null) return false;

            employee.DeletedDate = DateTime.UtcNow;
            
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<List<GetEmployeeDTO>> GetAll()
        {
            

            return await _context.employees.Select(x =>
                 new GetEmployeeDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    gender = x.gender,
                    FullName = $"{x.FirstName} {x.LastName}",
                }
            ).ToListAsync();
        }
    }
}
