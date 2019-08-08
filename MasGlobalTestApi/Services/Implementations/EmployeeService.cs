using System.Collections.Generic;
using Infrastrucutre;
using AppServices.Contracts;

using AppInfrastructure.Contracts;
using System.Threading.Tasks;

namespace AppServices.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<List<IEmployee>> GetAllEmployees()
        {
            return  await _employeeRepository.GetEmployees();
        }

        public async Task<IEmployee> GetEmployeeById(int emplpoyeeId)
        {
            var employees = await _employeeRepository.GetEmployees();
            return  employees.Find(x => x.Id == emplpoyeeId);
        }
    }
}
