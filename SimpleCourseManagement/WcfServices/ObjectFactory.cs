using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types;

namespace WcfServices
{
    sealed class ObjectFactory
    {
        private static readonly ObjectFactory instance = new ObjectFactory();
        public static ObjectFactory Instance { get { return instance; } }

        private ObjectFactory()
        {
        }

        public CourseType CreateCourseType(String name, String description)
        {
            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name can not be null or empty!");
            }

            if (String.IsNullOrEmpty(description))
            {
                throw new ArgumentException("description can not be null or empty!");
            }

            return new CourseType()
            {
                Name = name,
                Description = description
            };
        }

        public Course CreateCourse(int courseTypeId, String instanceName, String ects, Schedule schedule)
        {
            if (String.IsNullOrEmpty(instanceName))
            {
                throw new ArgumentException("instanceName can not be null or empty!");
            }

            if (String.IsNullOrEmpty(ects))
            {
                throw new ArgumentException("ects can not be null or empty!");
            }

            return new Course()
            {
                CourseTypeId = courseTypeId,
                InstanceName = instanceName,
                Ects = ects,
                Schedule = CreateDateTime(schedule)
            };
        }

        public DateTime CreateDateTime(Schedule schedule)
        {
            if (schedule == null)
            {
                return DateTime.MaxValue;
            }

            return new DateTime(schedule.Year, schedule.Month, schedule.Day, schedule.Hour, schedule.Minute, 0);
        }

        public Schedule CreateSchedule(DateTime dateTime)
        {
            return new Schedule()
            {
                Year = dateTime.Year,
                Month = dateTime.Month,
                Day = dateTime.Day,
                Hour = dateTime.Hour,
                Minute = dateTime.Minute
            };
        }

        public Student CreateStudent(String name, String familyName, String email)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name can not be null or empty!");
            }

            if (String.IsNullOrEmpty(familyName))
            {
                throw new ArgumentException("familyName can not be null or empty!");
            }

            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentException("email can not be null or empty!");
            }

            return new Student()
            {
                Name = name,
                FamilyName = familyName,
                Email = email
            };
        }

        public Exam CreateExam(int courseId, WcfServices.ExamType type)
        {
            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            return new Exam()
            {
                CourseId = courseId,
                Type = (Types.ExamType)type
            };
        }

        public Teacher CreateTeacher(String name, String familyName, String email)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name can not be null or empty!");
            }

            if (String.IsNullOrEmpty(familyName))
            {
                throw new ArgumentException("familyName can not be null or empty!");
            }

            if (String.IsNullOrEmpty(email))
            {
                throw new ArgumentException("email can not be null or empty!");
            }

            return new Teacher()
            {
                Name = name,
                FamilyName = familyName,
                Email = email
            };
        }
    }
}