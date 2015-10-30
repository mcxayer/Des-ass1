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
            throw new NotImplementedException();
        }

        public GradeStatistics GetCourseGradeStatistics(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetTeacherCourseIds(int teacherId)
        {
            throw new NotImplementedException();
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            throw new NotImplementedException();
        }

        public List<double> GetExamGrades(int courseId, bool reexam = false)
        {
            throw new NotImplementedException();
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            throw new NotImplementedException();
        }
    }
}
