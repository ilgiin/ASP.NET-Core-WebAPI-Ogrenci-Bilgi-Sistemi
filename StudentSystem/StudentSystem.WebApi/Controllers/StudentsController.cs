using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentSystem.WebApi.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace StudentSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static private readonly List<Student> _students = new List<Student>()
        {
        new Student{Name="Elif",Surname="Yılmaz", No=1,Id=1},
        new Student{Name="Mete",Surname="Kaya", No=2,Id=2},
        new Student{Name="Kamil",Surname="Koç", No=3,Id=3}
        };

        [HttpPost]
        public IActionResult Post([FromForm] Student student)

        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}


            _students.Add(student);
            return Ok(student);
        }


        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            return Ok(_students);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            if (_students.Any(s => s.No == student.No && s.Id != id))
            {
                return BadRequest("Öğrenci numarası benzersiz olmalıdır.");
            }

            existingStudent.Name = student.Name;
            existingStudent.Surname = student.Surname;
            existingStudent.No = student.No;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public void DeleteStudent(int id)
        {
            var index = _students.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                return;
            }
            _students.RemoveAt(index);
        }












    }
}
