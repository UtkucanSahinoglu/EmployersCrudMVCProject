using DataAccess.ApiDbContext;
using DataAccess.Interface;
using Entity.Domain;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class EmployerReposiyory : IEmployerRepository
    {
        private readonly EmployersDbContext ApiDbContext;
        public EmployerReposiyory(EmployersDbContext _ApiContext)
        {
            ApiDbContext = _ApiContext;
        }
        public async Task<AddEmployersDTO> AddEmployer(AddEmployersDTO addEmployerRequest)
        {
            var employers = new Employer()
            {
                Id = Guid.NewGuid(),
                Name = addEmployerRequest.Name,
                Email = addEmployerRequest.Email,
                Salary = addEmployerRequest.Salary,
                Department = addEmployerRequest.Department,
                DateOfBirth = addEmployerRequest.DateOfBirth,
            };
            await ApiDbContext.Set<Employer>().AddAsync(employers);
            await ApiDbContext.SaveChangesAsync();
            return addEmployerRequest;
        }
    }
}
