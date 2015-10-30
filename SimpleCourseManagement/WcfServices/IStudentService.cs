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
        void RegisterStudent(String name, String familyName, String email);

        [OperationContract]
        void RegisterCourse(int studentId, int courseId);

        [OperationContract]
        void UnregisterCourse(int studentId, int courseId);

        [OperationContract]
        Schedule GetCourseSchedule(int courseId);

        [OperationContract]
        void RegisterExam(int studentId, int examId);

        [OperationContract]
        double GetExamGrade(int studentId, int examId);

        [OperationContract]
        List<double> GetExamGrades(int studentId);
    }
}
