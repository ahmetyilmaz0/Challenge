using AutoMapper;
using Challenge.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(t => t.studentPaid, t => t.MapFrom(src => src.StudentPaids.AsQueryable().Include(x => x.Student).ToList().Select(t => new StudentPaidViewModel()
                {
                    studentPaidID = t.StudentPaidID,
                    studentID = t.StudentID,
                    studentPaidDetail = t.StudentPaidDetail,
                    studentPaidDate = t.StudentPaidDate
                }).ToList()));
            CreateMap<StudentViewModel, Student>()
                .ForMember(t => t.StudentPaids, p => p.MapFrom(src => src.studentPaid.Select(t => new StudentPaid()
                {
                    StudentPaidID = t.studentPaidID,
                    StudentID = t.studentID,
                    StudentPaidDetail = t.studentPaidDetail,
                    StudentPaidDate = t.studentPaidDate
                }).ToList().ToEntityCollection()));
            CreateMap<StudentPaid, StudentPaidViewModel>();
            CreateMap<StudentPaidViewModel, StudentPaid>();
        }
    }
    public static class ListExtension
    {
        public static ICollection<T> ToEntityCollection<T>(this List<T> list) where T : class
        {
            ICollection<T> entityCollection = new List<T>();
            list.ForEach(entityCollection.Add);
            return entityCollection;
        }
    }
}
