using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServices;

namespace GUI.Facade
{
    sealed class ServiceFacade
    {
        private static readonly ServiceFacade instance = new ServiceFacade();
        public static ServiceFacade Instance { get { return instance; } }

        private ChannelFactory<IStudentService> serviceChannelFactory;
        private IStudentService serviceProxy;

        private ServiceFacade()
        {
            serviceChannelFactory = new ChannelFactory<IStudentService>("StudentServiceEndpoint");
            serviceProxy = serviceChannelFactory.CreateChannel();
        }

        public void RegisterStudent(String name, String familyName, String email)
        {
            serviceProxy.RegisterStudent(name, familyName, email);
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            serviceProxy.RegisterCourse(studentId, courseId);
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            serviceProxy.UnregisterCourse(studentId, courseId);
        }

        public Schedule GetCourseSchedule(int courseId)
        {
            return serviceProxy.GetCourseSchedule(courseId);
        }

        public void RegisterExam(int studentId, int examId)
        {
            serviceProxy.RegisterExam(studentId, examId);
        }

        public double GetExamGrade(int studentId, int courseId)
        {
            return serviceProxy.GetExamGrade(studentId, courseId);
        }

        public List<double> GetExamGrades(int studentId)
        {
            return serviceProxy.GetExamGrades(studentId);
        }
    }
}
