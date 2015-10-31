using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface IStudentService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void RegisterStudent(String name, String familyName, String email);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void RegisterCourse(int studentId, int courseId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void UnregisterCourse(int studentId, int courseId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Schedule GetCourseSchedule(int courseId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void RegisterExam(int studentId, int examId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        double GetExamGrade(int studentId, int examId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<double> GetExamGrades(int studentId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int GetStudentId(String email);
    }
}
