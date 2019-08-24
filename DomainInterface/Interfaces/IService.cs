using DomainInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainInterface.Interfaces
{
    public interface IService
    {
        IList<DomainStudent> GetStudents();
        void CreateStudent(DomainStudent Item);
        void Delete_Student(int Id);
        DomainStudent GetStudent(int id);
        void UpdateStudent(DomainStudent Student);

        void Create_Lesson(DomainLesson item);
        void Delete_Lesson(int Id);
        IList<DomainLesson> GetLessons();
        IList<DomainLesson> GetLessons(int StudentId);
        DomainLesson GetLesson(int id);
        void UpdateLesson(DomainLesson Student);
    }
}
