using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class StudentBusiness:IStudentBusiness
    {
        private readonly IStudentRepository studentRepository;
        public StudentBusiness(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        public List<Student> GetStudentByStudyYear(int studyYear)
        {
            List<Student> students=this.studentRepository.GetAllStudents();
            if (students.Count > 0)
            {
                return students.FindAll(s=>s.StudyYear==studyYear).ToList();
            }
            else
            {
                return null;
            }
        }
        public Student GetStudentById(int id)
        {
            List<Student> students = this.studentRepository.GetAllStudents();
            return (students.Count > 0) ? students.Find(s => s.Id >= id): null;
        }
        public List<Student> GetStudentsWithESPBMoreThan(int espb)
        {
            List<Student> students = this.studentRepository.GetAllStudents();
            return (students.Count > 0) ? students.FindAll(s => s.PointsESPB >= espb).ToList() : null;
        }
        public List<Student> GetAllStudents()
        {
            return this.studentRepository.GetAllStudents();
        }
        public bool InsertStudent(Student s)
        {
            return this.studentRepository.InsertStudent(s)>0;
        }
        public bool UpdateStudent(Student s)
        {
            return this.studentRepository.UpdateStudent(s) > 0;
        }
        public bool DeleteStudent(int id)
        {
            bool result = false;
            if(id!=0 && this.studentRepository.DeleteStudent(id) > 0)
            {
                result= true;
            };
            return result;
        }
    }
}
