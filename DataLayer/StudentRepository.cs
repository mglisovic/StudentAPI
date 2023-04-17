using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentRepository:IStudentRepository
    {
        public List<Student> GetAllStudents()
        {
            List<Student> result=new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Students";
                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                //Student s = new Student();
                while (sqlDataReader.Read())
                {
                    Student s = new Student();
                    s.Id = sqlDataReader.GetInt32(0);
                    s.StudentName = sqlDataReader.GetString(1);
                    s.IndexNumber=sqlDataReader.GetString(2);
                    s.PointsESPB = sqlDataReader.GetInt32(3);
                    s.StudyYear = sqlDataReader.GetInt32(4);
                    s.AverageMark= sqlDataReader.GetDecimal(5);
                    s.IsBudget=sqlDataReader.GetBoolean(6);
                    result.Add(s);
                }

            }
            return result;
        }
        public int InsertStudent(Student s)
        {
            using(SqlConnection sqlConnection=new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "INSERT INTO Students VALUES ("+
                    "'"+s.StudentName+"'"+","+
                    "'"+s.IndexNumber+"'"+","+
                    s.PointsESPB+","+
                    s.StudyYear+","+
                    s.AverageMark+","+
                     "'" + s.IsBudget + "'" + ")";

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
            
        }
        public int UpdateStudent(Student s)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "UPDATE Students SET " +
                    "StudentName= " + "'" + s.StudentName + "'" + "," +
                    "IndexNumber= "+"'" + s.IndexNumber + "'" + "," +
                    "PointsESPB= " +s.PointsESPB + "," +
                    "StudyYear= "  + s.StudyYear + "," +
                    "AverageMark= "  + s.AverageMark + "," +
                    "IsBudget= " + "'" + s.IsBudget + "'" + "WHERE Id="+s.Id;

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }

        }
        public int DeleteStudent(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connectionString))
            {

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "DELETE FROM Students WHERE Id="+id;
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
