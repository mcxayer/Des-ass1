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
        public void CreateExam(int courseId, ExamType type)
        {
            DomainFacade.Instance.CreateExam(courseId, type);
        }

        public GradeStatistics GetCourseGradeStatistics(int courseId)
        {
            List<double> examGrades = DomainFacade.Instance.GetExamGrades(courseId,false);
            List<double> reexamGrades = DomainFacade.Instance.GetExamGrades(courseId, true);

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
            return DomainFacade.Instance.GetTeacherCourseIds(teacherId);
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            return DomainFacade.Instance.GetCourseStudentIds(courseId);
        }

        public List<double> GetExamGrades(int courseId, bool reexam = false)
        {
            return DomainFacade.Instance.GetExamGrades(courseId, reexam);
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            DomainFacade.Instance.GradeExam(examAttemptId, grade);
        }
    }
}
