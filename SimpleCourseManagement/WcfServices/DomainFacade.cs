using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Types;

namespace WcfServices
{
    public class DomainFacade
    {
        private static readonly DomainFacade instance = new DomainFacade();
        public static DomainFacade Instance { get { return instance; } }

        private DatabaseFacade dbFacade;

        private DomainFacade()
        {
            dbFacade = new DatabaseFacade();
        }

        #region course

        public int CreateCourseInstance(int courseTypeId, String instanceName, String ects, Schedule schedule)
        {
            return dbFacade.CreateCourseInstance(ObjectFactory.Instance.CreateCourse(courseTypeId, instanceName, ects, schedule));
        }

        public int CreateCourseType(String name, String description)
        {
            return dbFacade.CreateCourseType(ObjectFactory.Instance.CreateCourseType(name, description));
        }

        public List<int> GetAllCourseIds()
        {
            return dbFacade.GetAllCourseIds();
        }

        public List<string> GetCourseInfo(int courseId)
        {
            return dbFacade.GetCourseInfo(courseId);
        }

        public Schedule GetCourseSchedule(int courseId)
        {
            return ObjectFactory.Instance.CreateSchedule(dbFacade.GetCourseSchedule(courseId));
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            return dbFacade.GetCourseStudentIds(courseId);
        }

        public void SetCourseSchedule(int courseId, Schedule schedule)
        {
            dbFacade.SetCourseSchedule(courseId, ObjectFactory.Instance.CreateDateTime(schedule));
        }

        #endregion

        #region student

        public int GetStudentId(String email)
        {
            return dbFacade.GetStudentId(email);
        }

        public void RegisterStudent(String name, String familyName, String email)
        {
            dbFacade.RegisterStudent(ObjectFactory.Instance.CreateStudent(name, familyName, email));
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            dbFacade.RegisterCourse(studentId, courseId);
        }

        public void RegisterExam(int studentId, int examId)
        {
            dbFacade.RegisterExam(studentId, examId);
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            dbFacade.UnregisterCourse(studentId, courseId);
        }


        #endregion

        #region teacher

        public void AssignCourseTeacher(int teacherId, int courseId)
        {
            dbFacade.AssignCourseTeacher(teacherId, courseId);
        }

        public int CreateTeacher(String name, String familyName, String email)
        {
            return dbFacade.CreateTeacher(ObjectFactory.Instance.CreateTeacher(name, familyName, email));
        }

        public List<int> GetAllTeacherIds()
        {
            return dbFacade.GetAllTeacherIds();
        }

        public List<int> GetTeacherCourseIds(int teacherId)
        {
            return dbFacade.GetTeacherCourseIds(teacherId);
        }

        public List<String> GetTeacherInfo(int teacherId)
        {
            return dbFacade.GetTeacherInfo(teacherId);
        }

        public List<string> GetStudentInfo(int studentId)
        {
            return dbFacade.GetStudentInfo(studentId);
        }

        #endregion

        #region exam

        public int CreateExam(int courseId, WcfServices.ExamType type)
        {
            return dbFacade.CreateExam(ObjectFactory.Instance.CreateExam(courseId, type));
        }

        public List<double> GetCourseExamGrades(int courseId, bool reexam = false)
        {
            return dbFacade.GetCourseExamGrades(courseId, reexam);
        }

        public double GetStudentExamGrade(int studentId, int examId)
        {
            return dbFacade.GetStudentExamGrade(studentId, examId);
        }

        public List<double> GetStudentExamGrades(int studentId)
        {
            return dbFacade.GetStudentExamGrades(studentId);
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            dbFacade.GradeExam(examAttemptId, grade);
        }


        #endregion
    }
}