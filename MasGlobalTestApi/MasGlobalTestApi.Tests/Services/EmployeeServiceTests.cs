
using AppInfrastructure.Contracts;
using AppServices.Implementations;
using Infrastructure.Implementations;
using Infrastrucutre;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTestApi.Tests.Services
{
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService;
        private Mock<IEmployeeRepository> _employeeRepository;
        [SetUp]
        public void Setup()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();

            var hourlyEmp = new HourlyEmployee();
            hourlyEmp.Id = 1;
            hourlyEmp.Name = "Juan";
            hourlyEmp.ContractTypeName = "HourlySalaryEmployee";
            hourlyEmp.RoleId = 1;
            hourlyEmp.RoleName = "Administrator";
            hourlyEmp.RoleDescription = "";
            hourlyEmp.HourlySalary = 60000;
            hourlyEmp.MonthlySalary = 80000;

            var monthlyEmp = new MonthlyEmployee();
            monthlyEmp.Id = 2;
            monthlyEmp.Name = "Sebastian";
            monthlyEmp.ContractTypeName = "MonthlySalaryEmployee";
            monthlyEmp.RoleId = 2;
            monthlyEmp.RoleName = "Contractor";
            monthlyEmp.RoleDescription = "";
            monthlyEmp.HourlySalary = 60000;
            monthlyEmp.MonthlySalary = 80000;

            var employees = new List<IEmployee>();
            employees.Add(hourlyEmp);
            employees.Add(monthlyEmp);

            _employeeRepository.Setup(er => er.GetEmployees()).Returns(Task.FromResult(employees));
            _employeeService = new EmployeeService(_employeeRepository.Object);
        }

        [Test]
        public void GetAnualSalaryForHourlyEmployee_ShouldReturnTrue_WhenReturnsRightValue()
        {
            var employee = _employeeService.GetEmployeeById(1);
            Assert.AreEqual(86400000,employee.Result.AnualSalary);
        }

        [Test]
        public void GetAnualSalaryForMonthlyEmployee_ShouldReturnTrue_WhenReturnsRightValue()
        {
            var employee = _employeeService.GetEmployeeById(2);
            Assert.AreEqual(960000, employee.Result.AnualSalary);
        }
    }
}
