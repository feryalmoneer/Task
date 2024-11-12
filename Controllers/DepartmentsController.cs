using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Data;
using Task.Dot_s;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DepartmentsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var Department = context.Departments.Select(
                
               DepDto  => new DepGetAll()
              {
                   Id = DepDto.Id ,
                   Name = DepDto.Name ,

              }

                );
            return Ok(Department);
        }

        [HttpGet("Details")]
        public IActionResult GetById(int id)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("Department not found");
            }

            // Manual mapping to DepDetails
            var depDetails = new DepDetails
            {
                Name = department.Name
            };

            return Ok(depDetails);
        }


        [HttpPost("Create")]
        public IActionResult Create(DepCreate d)
        {
            Department dep = new Department()
            {
                Name = d.Name
            };
            context.Departments.Add(dep);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut("Edit")]
        public IActionResult Edit(int id, DepEdit dep)
        {
            var department = context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("Department not found");
            }

            // Update the properties of the existing entity
            department.Name = dep.Name;

            // Save changes
            context.SaveChanges();

            return Ok();
        }


        [HttpDelete("Remove")]
        public IActionResult Remove(DepDelete dto)
        {
            var department = context.Departments.Find(dto.Id);
            if (department == null)
            {
                return NotFound("Department not found");
            }

            context.Departments.Remove(department);
            context.SaveChanges();
            return Ok();
        }










    }
}
