using _14._08.Models;
using DomainInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14._08.Mappers
{
    public static class Mapping
    {
        public static DomainLesson FromAppLessonToDomainLesson(this AppLesson item)
        {
            return new DomainLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber = item.StudentNumber
            };
        }

        public static AppLesson FromDomainLessonToAppLesson(this DomainLesson item)
        {
            return new AppLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber = item.StudentNumber
            };
        }

        public static DomainLesson FromViewLessonToDomainLesson(this ViewLesson item)
        {
            return new DomainLesson
            {                
                Name = item.Name,
                StudentNumber = item.StudentNumber,
                
            };
        }

        public static DomainStudent FromAppStudentToDomainStudent(this AppStudent item)
        {
            return new DomainStudent
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
            };
        }

        public static AppStudent FromDomainStudentToAppStudent(this DomainStudent item)
        {
            return new AppStudent
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
            };
        }
    }
}