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
            try
            {
                DomainFacade.Instance.AssignCourseTeacher(teacherId, courseId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to assign a teacher to a course!");
            }
        }

        public void CreateCourseInstance(int courseTypeId, string instanceName, string ects, Schedule schedule)
        {
            try
            {
                DomainFacade.Instance.CreateCourseInstance(courseTypeId, instanceName, ects, schedule);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create new course instance!");
            }
        }

        public void CreateCourseType(string name, string description)
        {
            try
            {
                DomainFacade.Instance.CreateCourseType(name, description);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create new course type!");
            }
        }

        public void SetCourseSchedule(int courseId, Schedule schedule)
        {
            try
            {
                DomainFacade.Instance.SetCourseSchedule(courseId, schedule);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to set course schedule!");
            }
        }
    }
}
