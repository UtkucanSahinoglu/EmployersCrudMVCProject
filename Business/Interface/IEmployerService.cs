using Entity.Domain;
using Entity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEmployerService
    {
        Task <AddEmployersDTO> AddEmployer(AddEmployersDTO addEmployerRequest);
    }
}
