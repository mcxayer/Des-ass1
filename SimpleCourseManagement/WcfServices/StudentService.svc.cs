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
            return DomainFacade.Instance.GetCourseSchedule(courseId);
        }

        public double GetExamGrade(int studentId, int examId)
        {
            return DomainFacade.Instance.GetStudentExamGrade(studentId, examId);
        }

        public List<double> GetExamGrades(int studentId)
        {
            return DomainFacade.Instance.GetStudentExamGrades(studentId);
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            DomainFacade.Instance.RegisterCourse(studentId, courseId);
        }

        public void RegisterExam(int studentId, int examId)
        {
            DomainFacade.Instance.RegisterExam(studentId, examId);
        }

        public void RegisterStudent(string name, string familyName, string email)
        {
            DomainFacade.Instance.RegisterStudent(name, familyName, email);
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            DomainFacade.Instance.UnregisterCourse(studentId, courseId);
        }
    }
}
