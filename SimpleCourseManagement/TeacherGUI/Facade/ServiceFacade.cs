using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServices;

namespace TeacherGUI.Facade
{
    class ServiceFacade
    {
        ChannelFactory<ITeacherService> channelFactory = new ChannelFactory<ITeacherService>("TeacherServiceEndpoint");
        ITeacherService proxy;

        public ServiceFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public List<int> GetListOfCourseId()
        {
            return proxy.GetAllCourseIds();
        }

        public List<string> GetCourseInfo(int courseId)
        {
            return proxy.GetCourseInfo(courseId);
        }

        public List<int> GetStudentIdsForCourse(int courseId)
        {
            return proxy.GetCourseStudentIds(courseId);
        }

        public List<string> GetStudentInfo(int studentId)
        {
            return proxy.GetStudentInfo(studentId);
        }
    }
}
