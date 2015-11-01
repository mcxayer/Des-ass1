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
            try
            {
                return DomainFacade.Instance.GetCourseSchedule(courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get course schedule!");
            }
        }

        public double GetExamGrade(int studentId, int examId)
        {
            try
            {
                return DomainFacade.Instance.GetStudentExamGrade(studentId, examId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get student exam grade!");
            }
        }

        public List<double> GetStudentExamGrades(int studentId)
        {
            try
            {
                return DomainFacade.Instance.GetStudentExamGrades(studentId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get student exam grades!");
            }
        }

        public int GetStudentId(String email)
        {
            try
            {
                return DomainFacade.Instance.GetStudentId(email);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get student id!");
            }
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            try
            {
                DomainFacade.Instance.RegisterCourse(studentId, courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to register student to course!");
            }
        }

        public void RegisterExam(int studentId, int examId)
        {
            try
            {
                DomainFacade.Instance.RegisterExam(studentId, examId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to register student to exam!");
            }
        }

        public void RegisterStudent(string name, string familyName, string email)
        {
            try
            {
                DomainFacade.Instance.RegisterStudent(name, familyName, email);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to register student!");
            }
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            try
            {
                DomainFacade.Instance.UnregisterCourse(studentId, courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to unregister student!");
            }
        }
    }
}
