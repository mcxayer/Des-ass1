using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    public class StudentService : IStudentService
    {
        public Schedule GetCourseSchedule(int courseId)
        {
            throw new NotImplementedException();
        }

        public double GetExamGrade(int studentId, int examId)
        {
            return 0d;
        }

        public List<double> GetExamGrades(int studentId)
        {
            throw new NotImplementedException();
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }

        public void RegisterExam(int studentId, int examId)
        {
            throw new NotImplementedException();
        }

        public void RegisterStudent(string name, string familyName, string email)
        {
            throw new NotImplementedException();
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
