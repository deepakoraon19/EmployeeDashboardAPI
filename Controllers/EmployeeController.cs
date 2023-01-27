using EmployeeDashboard.Models;
using EmployeeDashboard.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Collections;
using System.Threading.Tasks;

namespace EmployeeDashboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private EmployeeService svc;

        //static List<Employee> Employees = new List<Employee>();
        public EmployeeController(EmployeeService svc) => this.svc = svc;

        #region Retrieve
        [HttpGet]
        public IEnumerable<Employee> GetAll() => svc._GetAll();

        [HttpGet("{id}")]
        public Employee GetById(int id) => svc._GetById(id);
        #endregion

        #region Create
        [HttpPost]
        public bool Create([FromBody] Employee employee) => svc._AddEmployee(employee);
        #endregion


        [HttpDelete("{id}")]
        public void Delete(int id) => svc._DeleteEmployee(id);

        [HttpPut]

        public bool EditEmployee([FromBody] Employee employee) => svc._EditEmployee(employee);


    



}
}
