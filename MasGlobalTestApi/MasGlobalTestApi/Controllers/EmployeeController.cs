using AppServices.Contracts;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace MasGlobalTestApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController()
        {

        }
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [Authorize]
        [HttpGet]
        [Route("GetEmployeeById/Id/{emplpoyeeId}")]
        public async Task<IHttpActionResult> GetEmployeeById(int emplpoyeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(emplpoyeeId);
                    if (employee != null)
                        return Ok(employee);
                    else
                        return NotFound();

            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError,"Unexpected error");
            }
       }
        [Authorize]
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IHttpActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeService.GetAllEmployees();
                if (employees.Count > 0)
                {
                    return Ok(employees);
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return Content(HttpStatusCode.InternalServerError, "Unexpected error");
            }
        }
    }
}
