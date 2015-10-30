﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfServices
{
    [ServiceContract]
    public interface ITeacherService
    {
        [OperationContract]
        void CreateExam(int courseId, ExamType type);

        [OperationContract]
        List<int> GetCourseStudentIds(int courseId);

        [OperationContract]
        void GradeExam(int examAttemptId, double grade);

        [OperationContract]
        List<double> GetExamGrades(int courseId, bool reexam = false);

        [OperationContract]
        List<int> GetTeacherCourseIds(int teacherId);

        [OperationContract]
        GradeStatistics GetCourseGradeStatistics(int courseId);
    }

    [DataContract]
    public class GradeStatistics // DTO
    {
        [DataMember]
        public double AverageGradeExam { get; set; }

        [DataMember]
        public double AverageGradeReexam { get; set; }

        [DataMember]
        public double FailRateExam { get; set; }

        [DataMember]
        public double FailRateReexam { get; set; }
    }

    [DataContract]
    public enum ExamType : int
    {
        [EnumMember]
        Oral = 0,

        [EnumMember]
        Written,

        [EnumMember]
        EssayReport
    }
}
