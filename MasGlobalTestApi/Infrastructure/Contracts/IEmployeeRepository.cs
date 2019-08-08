using Infrastrucutre;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppInfrastructure.Contracts
{
    public interface IEmployeeRepository
    {
        Task<List<IEmployee>> GetEmployees();
    }
}
