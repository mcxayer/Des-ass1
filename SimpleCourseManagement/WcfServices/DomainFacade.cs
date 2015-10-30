using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types;

namespace WcfServices
{
    public class DomainFacade
    {
        private DatabaseFacade dbFacade;

        public DomainFacade()
        {
            dbFacade = new DatabaseFacade();
        }

        #region admin services

        public void CreateCourseType(String name, String description)
        {
            dbFacade.CreateCourseType(ObjectFactory.Instance.CreateCourseType(name, description));
        }

        public void CreateCourseInstance(int courseTypeId, String instanceName, String ects, Schedule schedule)
        {
            dbFacade.CreateCourseInstance(ObjectFactory.Instance.CreateCourse(courseTypeId,instanceName, ects, schedule));
        }

        public void AssignCourseTeacher(int teacherId, int courseId)
        {
            dbFacade.AssignCourseTeacher(teacherId, courseId);
        }

        public void SetCourseSchedule(int courseId, Schedule schedule)
        {
            dbFacade.SetCourseSchedule(courseId, ObjectFactory.Instance.CreateDateTime(schedule));
        }

        #endregion

        #region student services

        public void RegisterStudent(String name, String familyName, String email)
        {
            dbFacade.RegisterStudent(ObjectFactory.Instance.CreateStudent(name, familyName, email));
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            dbFacade.RegisterCourse(studentId, courseId);
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            dbFacade.UnregisterCourse(studentId, courseId);
        }

        public Schedule GetCourseSchedule(int courseId)
        {
            return ObjectFactory.Instance.CreateSchedule(dbFacade.GetCourseSchedule(courseId));
        }

        public void RegisterExam(int studentId, int examId)
        {
            dbFacade.RegisterExam(studentId, examId);
        }

        public double GetExamGrade(int studentId, int examId)
        {
            return dbFacade.GetExamGrade(studentId, examId);
        }

        public List<double> GetExamGrades(int studentId)
        {
            return dbFacade.GetExamGrades(studentId);
        }

        #endregion

        #region teacher services

        public void CreateExam(int courseId, WcfServices.ExamType type)
        {
            dbFacade.CreateExam(ObjectFactory.Instance.CreateExam(courseId,type));
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            return dbFacade.GetCourseStudentIds(courseId);
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            dbFacade.GradeExam(examAttemptId, grade);
        }

        public List<double> GetExamGrades(int courseId, bool reexam = false)
        {
            return dbFacade.GetExamGrades(courseId, reexam);
        }

        public List<int> GetTeacherCourseIds(int teacherId)
        {
            return dbFacade.GetTeacherCourseIds(teacherId);
        }

        #endregion
    }
}