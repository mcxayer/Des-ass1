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
        void CreateCourseType(String name, String description);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void CreateCourseInstance(int courseTypeId, String instanceName, String ects, Schedule schedule);

        [OperationContract]
        [FaultContract(typeof(FaultException))]
        void AssignCourseTeacher(int teacherId, int courseId);

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
