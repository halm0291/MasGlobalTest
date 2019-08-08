
using Infrastrucutre;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppServices.Contracts
{
    public interface IEmployeeService
    {
        Task<List<IEmployee>> GetAllEmployees();
        Task<IEmployee> GetEmployeeById(int emplpoyeeId);
    }
}
