using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServices
{
    public class AdminService : IAdminService
    {
        public void AssignCourseTeacher(int teacherId, int courseId)
        {
            DomainFacade.Instance.AssignCourseTeacher(teacherId, courseId);
        }

        public void CreateCourseInstance(int courseTypeId, string instanceName, string ects, Schedule schedule)
        {
            DomainFacade.Instance.CreateCourseInstance(courseTypeId, instanceName, ects, schedule);
        }

        public void CreateCourseType(string name, string description)
        {
            DomainFacade.Instance.CreateCourseType(name, description);
        }

        public void SetCourseSchedule(int courseId, Schedule schedule)
        {
            DomainFacade.Instance.SetCourseSchedule(courseId, schedule);
        }
    }
}
