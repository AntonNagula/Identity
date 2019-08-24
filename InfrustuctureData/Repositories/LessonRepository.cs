using InfrustructureInterfaces.Models;
using InfrustructureInterfaces.Repository;
using InfrustuctureData.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using InfrustuctureData.Mappers;
using InfrustuctureData.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrustuctureData.Repositories
{
    public class LessonRepository : IRepositories<RepoLesson>
    {
        private StudentContext db;

        public LessonRepository(StudentContext db)
        {
            this.db = db;
        }
        public void Create(RepoLesson item)
        {
            db.Lessons.Add(item.FromRepoLessonToDataLesson());
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            DataLesson Lesson = db.Lessons.Find(id);
            db.Lessons.Remove(Lesson);
            db.SaveChanges();
        }

        public RepoLesson Get(int id)
        {
            RepoLesson obj = db.Lessons.Find(id).FromDataLessonToRepoLesson();
            return obj;
        }

        public IEnumerable<RepoLesson> GetAll()
        {
            return db.Lessons.Select(x => x.FromDataLessonToRepoLesson()).ToList();
        }

        public IEnumerable<RepoLesson> GetAll(int studentId)
        {
            return db.Lessons.Where(x=>x.StudentNumber==studentId).Select(x => x.FromDataLessonToRepoLesson()).ToList();
        }

        public IEnumerable<RepoLesson> GetObjects(int id)
        {
            return db.Lessons.Where(x => x.StudentNumber == id).Select(x => x.FromDataLessonToRepoLesson()).ToList();
        }

        public void Update(RepoLesson item)
        {
            DataLesson st = db.Lessons.Find(item.Id);
            st.Name = item.Name;            
            db.Entry(st).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
