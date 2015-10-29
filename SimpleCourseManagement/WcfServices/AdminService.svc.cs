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
            throw new NotImplementedException();
        }

        public void CreateCourseInstance(int courseTypeId, string instanceName, string ects, Schedule schedule)
        {
            throw new NotImplementedException();
        }

        public void CreateCourseType(string name, string description)
        {
            throw new NotImplementedException();
        }

        public void SetCourseSchedule(int courseId, Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
