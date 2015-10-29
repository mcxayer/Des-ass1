using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServices;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost studentHost = new ServiceHost(typeof(StudentService));
            studentHost.Open();
            Console.WriteLine("Hosting student service on localhost:40000/StudentService");

            ServiceHost teacherHost = new ServiceHost(typeof(TeacherService));
            teacherHost.Open();
            Console.WriteLine("Hosting teacher service on localhost:40000/TeacherService");

            ServiceHost adminHost = new ServiceHost(typeof(AdminService));
            adminHost.Open();
            Console.WriteLine("Hosting admin service on localhost:40000/AdminService");

            Console.ReadLine();
        }
    }
}
