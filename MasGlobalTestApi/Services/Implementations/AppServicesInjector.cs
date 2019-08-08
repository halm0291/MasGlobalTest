using Infrastrucutre;
using AppServices.Contracts;
using Infrastructure.Implementations;
using AppInfrastructure.Contracts;
using AppInfrastructure.Repositories;

namespace AppServices.Implementations
{
    public class AppServicesInjector
    {
        public void RegisterComponents(IDependencyFactory dependencyFactory)
        {
            dependencyFactory.RegisterType<IEmployeeRepository, EmployeeRepository>();
            dependencyFactory.RegisterType<IEmployeeService, EmployeeService>();
            dependencyFactory.RegisterType<IEmployee, MonthlyEmployee>("MonthlySalaryEmployee");
            dependencyFactory.RegisterType<IEmployee, HourlyEmployee>("HourlySalaryEmployee");
        }
    }
}
