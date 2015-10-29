using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        void CreateExam(int courseId, bool reexam = false);

        [OperationContract]
        List<int> GetCourseStudentIds(int courseId);

        [OperationContract]
        void GradeExam(int examId, int studentId, double grade);

        [OperationContract]
        List<double> GetExamGrades(int courseId, bool reexam = false);

        [OperationContract]
        List<int> GetCourseIds();

        [OperationContract]
        GradeStatistics GetCourseGradeStatistics(int courseId);
    }

    [DataContract]
    public class GradeStatistics
    {
        [DataMember]
        public double AverageGradeExam { get; set; }

        [DataMember]
        public double AverageGradeReexam { get; set; }

        [DataMember]
        public double FailRateExam { get; set; }

        [DataMember]
        public double FailRateReexam { get; set; }
    }
}
