using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TeacherGUI.Facade
{
    class NetworkFacade
    {
        ChannelFactory<ITeacherService> channelFactory = new ChannelFactory<ITeacherService>("TeacherServiceEndpoint");
        ITeacherService proxy;

        public NetworkFacade()
        {
            proxy = channelFactory.CreateChannel();
        }

        public List<int> GetListOfCourseId()
        {
            return proxy.GetListOfCourseId();
        }

        public List<string> GetCourseInfo(int id)
        {
            return proxy.GetCourseInfo(id);
        }

        public List<int> GetStudentIdsForCourse(int courseId)
        {
            return proxy.GetStudentIdsForCourse(courseId);
        }

        public List<string> GetStudentInfo(int id)
        {
            return proxy.GetStudentInfo(id);
        }
    }
}
