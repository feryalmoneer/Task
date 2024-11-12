using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Dot_s.EmpDto;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmployeesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var employees = context.Employees.ToList();
            var result = employees.Adapt<IEnumerable<EmpGetAll>>();
            return Ok(result);
        }

        [HttpGet("Details")]
        public IActionResult GetById(int id)
        {
            var employee = context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            var e = employee.Adapt<EmpGetAll>();
            return Ok(e);
        }
        [HttpPost("Create")]
        public IActionResult Create(CreateEmpDto employee)
        {
            var result = employee.Adapt<Employee>();

            context.Employees.Add(result);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut("Edit")]
        public IActionResult Edit(int id, CreateEmpDto employee)
        {
            var current = context.Employees.Find(id);
            if (current == null)
            {
                return NotFound("Employee not found");
            }

            employee.Adapt(current);

            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Remove")]
        public IActionResult Remove(int EmpId)
        {
            var employee = context.Employees.Find(EmpId);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            context.Employees.Remove(employee);
            context.SaveChanges();

            var empRemoveDto = employee.Adapt<EmpRemove>();
            return Ok();
        }





    }
}
