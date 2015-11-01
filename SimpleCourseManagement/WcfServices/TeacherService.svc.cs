using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    public class TeacherService : ITeacherService
    {
        public int CreateExam(int courseId, ExamType type)
        {
            try
            {
                return DomainFacade.Instance.CreateExam(courseId, type);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create exam!");
            }
        }

        public List<int> GetAllCourseIds()
        {
            try
            {
                return DomainFacade.Instance.GetAllCourseIds();
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get all course ids!");
            }
        }

        public GradeStatistics GetCourseGradeStatistics(int courseId)
        {
            List<double> examGrades = null; 
            List<double> reexamGrades = null; 
            try
            {
                examGrades = DomainFacade.Instance.GetCourseExamGrades(courseId, false);
                reexamGrades = DomainFacade.Instance.GetCourseExamGrades(courseId, true);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get course grade statistics!");
            }

            double totalExamGrade = 0;
            int failCountExam = 0;
            for (int i = 0; i < examGrades.Count; i++)
            {
                totalExamGrade += examGrades[i];

                if (examGrades[i] < 40d)
                {
                    failCountExam++;
                }
            }

            double totalReexamGrade = 0;
            int failCountReexam = 0;
            for (int i = 0; i < reexamGrades.Count; i++)
            {
                totalReexamGrade += reexamGrades[i];

                if (reexamGrades[i] < 40d)
                {
                    failCountReexam++;
                }
            }

            GradeStatistics gs = new GradeStatistics();
            if(examGrades.Count > 0)
            {
                gs.AverageGradeExam = totalExamGrade / examGrades.Count;
                gs.FailRateExam = (double)failCountExam / (double)examGrades.Count;
            }
            else
            {
                gs.AverageGradeExam = -1d;
                gs.FailRateExam = -1d;
            }

            if(reexamGrades.Count > 0)
            {
                gs.AverageGradeReexam = totalReexamGrade / reexamGrades.Count;
                gs.FailRateReexam = (double)failCountReexam / (double)reexamGrades.Count;
            }
            else
            {
                gs.AverageGradeReexam = -1d;
                gs.FailRateReexam = -1d;
            }

            return gs;
        }

        public List<int> GetTeacherCourseIds(int teacherId)
        {
            try
            {
                return DomainFacade.Instance.GetTeacherCourseIds(teacherId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get teacher course ids!");
            }
        }

        public List<String> GetCourseInfo(int courseId)
        {
            try
            {
                return DomainFacade.Instance.GetCourseInfo(courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get course info!");
            }
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            try
            {
                return DomainFacade.Instance.GetCourseStudentIds(courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get course student ids!");
            }
        }

        public List<double> GetCourseExamGrades(int courseId, bool reexam = false)
        {
            try
            {
                return DomainFacade.Instance.GetCourseExamGrades(courseId, reexam);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get course exam grades!");
            }
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            try
            {
                DomainFacade.Instance.GradeExam(examAttemptId, grade);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to grade exam!");
            }
        }

        public List<string> GetStudentInfo(int studentId)
        {
            try
            {
                return DomainFacade.Instance.GetStudentInfo(studentId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get student info!");
            }
        }
    }
}
