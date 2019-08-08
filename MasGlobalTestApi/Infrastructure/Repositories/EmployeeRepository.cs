using AppInfrastructure.Contracts;
using Infrastrucutre;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AppInfrastructure.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IDependencyFactory _dependencyFactory;
        public EmployeeRepository(IDependencyFactory dependencyFactory)
        {
            _dependencyFactory = dependencyFactory;
        }
        public EmployeeRepository()
        {

        }
        public async Task<List<IEmployee>> GetEmployees()
        {
            List<IEmployee> employees = new List<IEmployee>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = await client.GetAsync("");
                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        var employeesJson = JArray.Parse(jsonString);
                        foreach (var item in employeesJson)
                        {
                            var contractTypeName = item["contractTypeName"].ToString();
                            var employee = _dependencyFactory.Resolve<IEmployee>(contractTypeName);
                            employee.Id = (int)item["id"];
                            employee.Name = item["name"].ToString();
                            employee.ContractTypeName = contractTypeName;
                            employee.RoleId = (int)item["roleId"];
                            employee.RoleName = item["roleName"].ToString();
                            employee.RoleDescription = item["roleDescription"].ToString();
                            employee.HourlySalary = (int)item["hourlySalary"];
                            employee.MonthlySalary = (int)item["monthlySalary"];
                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex )
            {
                   var error = ex;
            }

            return employees;
        }
    }
}
