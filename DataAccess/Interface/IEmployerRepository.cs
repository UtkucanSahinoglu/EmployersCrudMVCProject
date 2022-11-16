using Entity.Domain;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IEmployerRepository
    {
        Task <AddEmployersDTO> AddEmployer(AddEmployersDTO addEmployerRequest);
    }
}
