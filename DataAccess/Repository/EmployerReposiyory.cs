using DataAccess.ApiDbContext;
using DataAccess.Interface;
using Entity.Domain;
using Entity.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public async Task<UpdateEmployersDTO> UpdateByEmployerId(Guid Id)
        {
            var employers = await ApiDbContext.Set<Employer>().FirstOrDefaultAsync(x => x.Id == Id);

            if(employers != null)
            {
                var ViewModel = new UpdateEmployersDTO()
                {
                    Id = employers.Id,
                    Name = employers.Name,
                    Email = employers.Email,
                    Salary = employers.Salary,
                    Department = employers.Department,
                    DateOfBirth = employers.DateOfBirth,
                };
                return ViewModel;
            }
            return null;
        }

        public async Task<List<Employer>> GetEmployer()
        {
            return await ApiDbContext.Set<Employer>().ToListAsync();
        }
    }
}
