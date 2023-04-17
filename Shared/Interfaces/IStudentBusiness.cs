using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IStudentBusiness
    {
        public List<Student> GetAllStudents();
        public bool InsertStudent(Student s);
        public bool UpdateStudent(Student s);
        public bool DeleteStudent(int id);
        List<Student> GetStudentsWithESPBMoreThan(int espb);
        List<Student> GetStudentByStudyYear(int studyYaer);
        Student GetStudentById(int id);
        
    }
}
