using System.Collections.Generic;
using System.ServiceModel;
using WcfServices;

namespace AdminGUI.Facade
{
    class ServiceFacade
    {
        ChannelFactory<IAdminService> channelFactory = new ChannelFactory<IAdminService>("AdminServiceEndpoint");
        IAdminService proxy;

        public ServiceFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public void AssignCourseTeacher(int teacherId, int courseId)
        {
            proxy.AssignCourseTeacher(teacherId, courseId);
        }

        public List<string> GetCourseInfo(int id)
        {
            return proxy.GetCourseInfo(id);
        }

        public List<int> GetListOfCourseId()
        {
            return proxy.GetAllCourseIds();
        }

        public int CreateCourse(string name, int instance, int instanceYear, string description, int ects)
        {
            int courseTypeId = proxy.CreateCourseType(name, description);
            return proxy.CreateCourseInstance(courseTypeId, instance == 1 ? "Spring" : "Fall" + " " + instanceYear.ToString(), ects.ToString());
        }

        public List<int> GetListOfTeacherId()
        {
            return proxy.GetAllTeacherIds();
        }

        public List<string> GetTeacherInfo(int id)
        {
            return proxy.GetTeacherInfo(id);
        }

        public void CreateTeacher(string name, string familyName, string email)
        {
            proxy.CreateTeacher(name, familyName, email);
        }
    }
}
