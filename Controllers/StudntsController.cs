using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Dot_s;
using Task.Dot_s.StudentDot_s;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudntsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public StudntsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Stu =  await context.Students.Select(

               StudentDto => new GetAllStudentDots()
               {
                 Id=StudentDto.Id ,
                   StudentName = StudentDto.StudntName,
                   Price= StudentDto.Price ,
                   Description = StudentDto.Description ,

               }

                ).ToArrayAsync();
            return Ok(Stu);
        }

        [HttpGet("Details")]
        public async  Task <IActionResult> GetById(int id)
        {
            var s = await context.Students.FindAsync(id);
            if (s == null)
            {
                return NotFound();
            }

            // Manual mapping to DepDetails
            var StuDetails = new GetAllStudentDots
            {
                Id = s.Id ,
                StudentName = s.StudntName,
                Price = s.Price,
                Description = s.Description,
            };

            return Ok(StuDetails);
        }


        [HttpPost("Create")]
        public async  Task <IActionResult >Create(GetAllStudentDots student)
        {
            Student s = new Student()
            {
                StudntName = student.StudentName,
                Price = student.Price,
                Description = student.Description,
            };
           await context.Students.AddAsync(s);
          await  context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("Edit")]
        public async  Task <IActionResult >Edit(int id, EditStudentDto student)
        {
            var ss = await context.Students.FindAsync(id);
            if (ss == null)
            {
                return NotFound("Department not found");
            }

            // Update the properties 
            ss.StudntName = student.StudentName;
            ss.Price = student.Price;
            ss.Description = student.Description;

            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync(); 
            return Ok();
        }











    }
}
