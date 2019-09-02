using DomainInterface.Interfaces;
using DomainInterface.Models;
using InfrustructureInterfaces.Repository;
using DomainService.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Services
{
    public class Service : IService
    {
        public readonly IUnitOfWork _studentRepository;

        public Service(IUnitOfWork studentRepository)
        {
            _studentRepository = studentRepository;
        }
        

        public IList<DomainStudent> GetStudents()
        {
            return _studentRepository.Students.GetAll().Select(x => x.FromRepoStudentToDomainStudent()).ToList();
        }

        public void CreateStudent(DomainStudent Item)
        {
            _studentRepository.Students.Create(Item.FromDomainStudentToRepoStudent());
        }

        public void Delete_Student(int Id)
        {
            _studentRepository.Students.Delete(Id);
        }

        public DomainStudent GetStudent(int id)
        {
            return _studentRepository.Students.Get(id).FromRepoStudentToDomainStudent();
        }

        public DomainStudent GetStudent(string name)
        {
            return _studentRepository.Students.GetAll().FirstOrDefault(x=>x.Name==name).FromRepoStudentToDomainStudent();
        }

        public void UpdateStudent(DomainStudent Student)
        {
            _studentRepository.Students.Update(Student.FromDomainStudentToRepoStudent());
        }




        public void Create_Lesson(DomainLesson item)
        {
            _studentRepository.Lessons.Create(item.FromDomainLessonToRepoLesson());
        }

        public void Delete_Lesson(int Id)
        {
            _studentRepository.Lessons.Delete(Id);
        }

        public DomainLesson Get_Lesson(int Id)
        {
            return _studentRepository.Lessons.Get(Id).FromRepoLessonToDomainLesson();
        }
        public IList<DomainLesson> GetLessons()
        {
            return _studentRepository.Lessons.GetAll().Select(x => x.FromRepoLessonToDomainLesson()).ToList();
        }
        public IList<DomainLesson> GetLessons(int StudentId)
        {
            return _studentRepository.Lessons.GetObjects(StudentId).Select(x => x.FromRepoLessonToDomainLesson()).ToList();
        }

        public DomainLesson GetLesson(int id)
        {
            return _studentRepository.Lessons.Get(id).FromRepoLessonToDomainLesson();
        }
        public void UpdateLesson(DomainLesson lesson)
        {
            _studentRepository.Lessons.Update(lesson.FromDomainLessonToRepoLesson());
        }        
    }
}
