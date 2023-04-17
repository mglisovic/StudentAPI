using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly IStudentBusiness studentBusiness;
        public StudentControler(IStudentBusiness studentBusiness)
        {
            this.studentBusiness = studentBusiness;
        }
        // GET: api/<StudentControler>
        [HttpGet]
        public List<Student> GetAllStudents()
        {
            return this.studentBusiness.GetAllStudents();
        }
        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            return this.studentBusiness.GetStudentById(id);
        }
        // GET api/<StudentControler>/filter/5
        [HttpGet("filter/year/{studyYear}")]
        public List<Student> GetStudentByStudyYear(int studyYear)
        {
            return this.studentBusiness.GetStudentByStudyYear(studyYear);
        }
        // GET api/<StudentControler>/filter/espb/5
        [HttpGet("filter/espb/{espb}")]
        public List<Student> GetStudentsWithESPBMoreThan(int espb)
        {
            return this.studentBusiness.GetStudentsWithESPBMoreThan(espb);
        }

        // POST api/<StudentControler>
        [HttpPost]
        public bool InsertStudent([FromBody] Student s)
        {
            return this.studentBusiness.InsertStudent(s);
        }

        // PUT api/<StudentControler>/5
        [HttpPut("{id}")]
        public bool UpdateStudent([FromBody] Student s)
        {
            return this.studentBusiness.UpdateStudent(s);
        }

        // DELETE api/<StudentControler>/5
        [HttpDelete("{id}/delete")]
        public bool DeleteStudent(int id)
        {
            return this.studentBusiness.DeleteStudent(id);
        }
    }
}
