using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Types;

namespace WcfServices
{
    public class DatabaseFacade
    {
        #region course

        public int CreateCourseInstance(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("course");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.CourseSet.Add(course);
                db.SaveChanges();

                return course.Id;
            }
        }

        public int CreateCourseType(CourseType courseType)
        {
            if (courseType == null)
            {
                throw new ArgumentNullException("courseType");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.CourseTypeSet.Add(courseType);
                db.SaveChanges();

                return courseType.Id;
            }
        }

        public List<int> GetAllCourseIds()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from c in db.CourseSet select c.Id).ToList();
            }
        }

        public List<string> GetCourseInfo(int courseId)
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

                List<string> courseInfo = new List<string>();
                courseInfo.Add(course.Id.ToString());
                courseInfo.Add(course.CourseType.Name);
                courseInfo.Add(course.InstanceName);
                courseInfo.Add(course.CourseType.Description);
                courseInfo.Add(course.Ects);

                if(course.Teacher != null)
                {
                    courseInfo.Add(course.Teacher.Id.ToString());
                    courseInfo.Add(course.Teacher.Name);
                }

                return courseInfo;
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

        #region student

        public int GetStudentId(String email)
        {
            if (String.IsNullOrEmpty(email))
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

        public void RegisterStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException("student");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                //db.Database.Connection.Open();

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


        #endregion

        #region teacher

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

        public int CreateTeacher(Teacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException("teacher");
            }

            using (DatabaseEntities db = new DatabaseEntities())
            {
                db.UserSet.Add(teacher);
                db.SaveChanges();

                return teacher.Id;
            }
        }

        public List<int> GetAllTeacherIds()
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                return (from u in db.UserSet
                        where u is Teacher
                        select u.Id).ToList();
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

        public List<String> GetTeacherInfo(int teacherId)
        {
            if (teacherId < 0)
            {
                throw new ArgumentOutOfRangeException("teacherId", "teacherId can not be less than zero!");
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

                List<String> teacherInfo = new List<String>();
                teacherInfo.Add(teacher.Id.ToString());
                teacherInfo.Add(teacher.Name);
                teacherInfo.Add(teacher.FamilyName);
                teacherInfo.Add(teacher.Email);

                return teacherInfo;
            }
        }

        public List<string> GetStudentInfo(int studentId)
        {
            if (studentId < 0)
            {
                throw new ArgumentOutOfRangeException("studentId", "studentId can not be less than zero!");
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

                List<string> studentInfo = new List<string>();
                studentInfo.Add(student.Id.ToString());
                studentInfo.Add(student.Name);
                studentInfo.Add(student.FamilyName);
                studentInfo.Add(student.Email);

                return studentInfo;
            }
        }

        #endregion

        #region exam 

        public int CreateExam(Exam exam)
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

                return exam.Id;
            }
        }

        public List<double> GetCourseExamGrades(int courseId, bool reexam = false)
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

        public double GetStudentExamGrade(int studentId, int examId)
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

        public List<double> GetStudentExamGrades(int studentId)
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

        #endregion
    }
}