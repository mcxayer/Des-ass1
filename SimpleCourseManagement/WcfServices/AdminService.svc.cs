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

        public int CreateCourseInstance(int courseTypeId, string instanceName, string ects, Schedule schedule)
        {
            try
            {
                return DomainFacade.Instance.CreateCourseInstance(courseTypeId, instanceName, ects, schedule);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create new course instance!");
            }
        }

        public int CreateCourseType(string name, string description)
        {
            try
            {
                return DomainFacade.Instance.CreateCourseType(name, description);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create new course type!");
            }
        }

        public int CreateTeacher(String name, String familyName, String email)
        {
            try
            {
                return DomainFacade.Instance.CreateTeacher(name, familyName, email);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to create new teacher!");
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

        public List<int> GetAllTeacherIds()
        {
            try
            {
                return DomainFacade.Instance.GetAllTeacherIds();
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get all teacher ids!");
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

        public List<String> GetTeacherInfo(int teacherId)
        {
            try
            {
                return DomainFacade.Instance.GetTeacherInfo(teacherId);
            }
            catch
            {
                throw new FaultException("A problem occurred trying to get teacher info!");
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
