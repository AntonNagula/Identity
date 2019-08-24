using InfrustructureInterfaces.Models;
using InfrustructureInterfaces.Repository;
using InfrustuctureData.Repositories;
using System;

namespace InfrustuctureData.Structure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private StudentContext db;
        private LessonRepository LessonRepo;
        private StudentRepository StudentRepo;        
        public UnitOfWork(StudentContext st)
        {
            db = st;
        }
        public IRepositories<RepoLesson> Lessons
        {
            get
            {
                if (LessonRepo == null)
                    LessonRepo = new LessonRepository(db);
                return LessonRepo;
            }
        }

        public IRepositories<RepoStudent> Students
        {
            get
            {
                if (StudentRepo == null)
                    StudentRepo = new StudentRepository(db);
                return StudentRepo;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
