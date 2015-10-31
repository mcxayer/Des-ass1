using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types;

namespace WcfServices
{
    public class DatabaseFacade
    {
        #region admin services

        public void CreateCourseType(CourseType courseType)
        {
            if (courseType == null)
            {
                throw new ArgumentNullException("courseType");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.CourseTypeSet.Add(courseType);
                db.SaveChanges();
            }
        }

        public void CreateCourseInstance(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.CourseSet.Add(course);
                db.SaveChanges();
            }
        }

        public void AssignCourseTeacher(int teacherId, int courseId)
        {
            if (teacherId < 0)
            {
                throw new ArgumentOutOfRangeException("teacherId", "teacherId can not be less than zero!");
            }

            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Teacher teacher = (from u in db.UserSet
                                   where u.Id == teacherId
                                   select u).FirstOrDefault() as Teacher;

                if (teacher == null)
                {
                    throw new ArgumentException("teacherId is not a valid id!");
                }

                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                course.Teacher = teacher;
                db.SaveChanges();
            }
        }

        public void SetCourseSchedule(int courseId, DateTime schedule)
        {
            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                course.Schedule = schedule;
                db.SaveChanges();
            }
        }

        #endregion

        #region student services

        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.Database.Connection.Open();

                Console.WriteLine(db.Database.Connection.ConnectionString);

                db.UserSet.Add(student);
                db.SaveChanges();
            }
        }

        public void RegisterCourse(int studentId, int courseId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
            }

            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Student student = (from u in db.UserSet
                                   where u.Id == studentId
                                   select u).FirstOrDefault() as Student;

                if(student == null)
                {
                    throw new ArgumentException("studentId is not a valid id!");
                }

                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                if(course.Students.Contains(student))
                {
                    throw new ArgumentException("student is already registered!");
                }

                course.Students.Add(student);
                db.SaveChanges();
            }
        }

        public void UnregisterCourse(int studentId, int courseId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
            }

            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Student student = (from u in db.UserSet
                                   where u.Id == studentId
                                   select u).FirstOrDefault() as Student;

                if (student == null)
                {
                    throw new ArgumentException("studentId is not a valid id!");
                }

                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                if (!course.Students.Contains(student))
                {
                    throw new ArgumentException("student is already not registered!");
                }

                course.Students.Remove(student);
                db.SaveChanges();
            }
        }

        public DateTime GetCourseSchedule(int courseId)
        {
            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                return course.Schedule;
            }
        }

        public void RegisterExam(int studentId, int examId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
            }

            if (examId < 0)
            {
                throw new ArgumentOutOfRangeException("examId", "examId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Student student = (from u in db.UserSet
                                   where u.Id == studentId
                                   select u).FirstOrDefault() as Student;

                if (student == null)
                {
                    throw new ArgumentException("studentId is not a valid id!");
                }

                Exam exam = (from e in db.ExamSet
                             where e.Id == examId
                             select e).FirstOrDefault();

                if (exam == null)
                {
                    throw new ArgumentException("examId is not a valid id!");
                }

                if (exam.Students.Contains(student))
                {
                    throw new ArgumentException("student is already registered!");
                }

                exam.Students.Add(student);
                db.SaveChanges();
            }
        }

        public double GetExamGrade(int studentId, int examId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
            }

            if (examId < 0)
            {
                throw new ArgumentOutOfRangeException("examId", "examId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from ea in db.ExamAttemptSet
                        where ea.ExamId == examId
                        where ea.Student.Id == studentId
                        select ea.Grade).FirstOrDefault();
            }
        }

        public List<double> GetExamGrades(int studentId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from ea in db.ExamAttemptSet
                        where ea.Student.Id == studentId
                        select ea.Grade).ToList();
            }
        }

        public int GetStudentId(String email)
        {
            if(String.IsNullOrEmpty(email))
            {
                throw new ArgumentException("email can not be null or empty!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from u in db.UserSet
                        where u.Email.Equals(email)
                        select u.Id).FirstOrDefault();
            }
        }

        #endregion

        #region teacher services

        public void CreateExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException("exam");
            }

            if (exam.CourseId < 0)
            {
                throw new ArgumentOutOfRangeException("exam.CourseId", "CourseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Course course = (from c in db.CourseSet
                                 where c.Id == exam.CourseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                if (course.Exams.Count > 0)
                {
                    throw new Exception("Exam already exists!");
                }

                db.ExamSet.Add(exam);
                db.SaveChanges();
            }
        }

        public List<int> GetCourseStudentIds(int courseId)
        {
            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                var queryResults = (from c in db.CourseSet
                                    where c.Id == courseId
                                    select (from s in c.Students
                                            select s.Id));

                List<int> studentIds = new List<int>();
                foreach (var queryResult in queryResults)
                {
                    studentIds.AddRange(queryResult);
                }

                return studentIds;
            }
        }

        public void GradeExam(int examAttemptId, double grade)
        {
            if (examAttemptId < 0)
            {
                throw new ArgumentOutOfRangeException("examAttemptId", "examAttemptId can not be less than zero!");
            }

            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException("grade", "grade can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                ExamAttempt examAttempt = (from ea in db.ExamAttemptSet
                                           where ea.Id == examAttemptId
                                           select ea).FirstOrDefault();

                if (examAttempt == null)
                {
                    throw new ArgumentException("examAttemptId is not a valid id!");
                }

                examAttempt.Grade = grade;
                db.SaveChanges();
            }
        }

        public List<double> GetExamGrades(int courseId, bool reexam = false)
        {
            if (courseId < 0)
            {
                throw new ArgumentOutOfRangeException("courseId", "courseId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                Course course = (from c in db.CourseSet
                                 where c.Id == courseId
                                 select c).FirstOrDefault();

                if (course == null)
                {
                    throw new ArgumentException("courseId is not a valid id!");
                }

                if (course.Exams.Count == 0)
                {
                    throw new ArgumentException("Course has no registered exams!");
                }

                if (reexam && course.Exams.Count == 1)
                {
                    throw new ArgumentException("Course has no registered reexams!");
                }

                Exam exam = reexam ? course.Exams.ElementAt(1) : course.Exams.ElementAt(0);

                return (from ea in exam.ExamAttempts select ea.Grade).ToList();
            }
        }

        public List<int> GetTeacherCourseIds(int teacherId)
        {
            if (teacherId < 0)
            {
                throw new ArgumentOutOfRangeException("teacherId", "teacherId can not be less than zero!");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from c in db.CourseSet
                        where c.Teacher.Id == teacherId
                        select c.Id).ToList();
            }
        }

        #endregion

        #region other service

        public List<int> GetAllCourseIds()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from c in db.CourseSet select c.Id).ToList();
            }
        }

        #endregion
    }
}