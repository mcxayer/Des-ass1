using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void AssignCourseTeacher(int teacherId, int courseId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int CreateCourseInstance(int courseTypeId, String instanceName, String ects, Schedule schedule = null);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int CreateCourseType(String name, String description);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        int CreateTeacher(String name, String familyName, String email);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<int> GetAllCourseIds();

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<int> GetAllTeacherIds();

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<String> GetCourseInfo(int courseId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<String> GetTeacherInfo(int teacherId);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void SetCourseSchedule(int courseId, Schedule schedule);
    }

    [DataContract]
    public class Schedule // DTO
    {
        [DataMember]
        public int Year { get; set; }
        
        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public int Day { get; set; }

        [DataMember]
        public int Hour { get; set; }

        [DataMember]
        public int Minute { get; set; }
    }
}
