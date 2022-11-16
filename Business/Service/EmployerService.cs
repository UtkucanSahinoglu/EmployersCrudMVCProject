using Business.Interface;
using DataAccess.Interface;
using Entity.Domain;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository employerRepository;
        public EmployerService(IEmployerRepository _employerRepository)
        {
            employerRepository = _employerRepository;
        }

        public async Task<AddEmployersDTO> AddEmployer(AddEmployersDTO addEmployerRequest)
        {
            return await employerRepository.AddEmployer(addEmployerRequest);
        }

        public async Task<UpdateEmployersDTO> UpdateByEmployerId(Guid Id)
        {
            return await employerRepository.UpdateByEmployerId(Id);
        }

        public async Task<List<Employer>> GetEmployer()
        {
            return await employerRepository.GetEmployer();
        }
    }
}
