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
    public class StudentRepository : IRepositories<RepoStudent>
    {
        private StudentContext db;

        public StudentRepository(StudentContext db)
        {
            this.db = db;
        }
        public void Create(RepoStudent item)
        {
            db.Students.Add(item.FromRepoStudentToDataStudent());
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            DataStudent Student = db.Students.Find(id);
            db.Students.Remove(Student);
            db.SaveChanges();
        }

        public RepoStudent Get(int id)
        {
            RepoStudent obj = db.Students.Find(id).FromDataStudentToRepoStudent();
            return obj;
        }

        public IEnumerable<RepoStudent> GetAll()
        {
            return db.Students.Select(x => x.FromDataStudentToRepoStudent()).ToList();
        }

        public IEnumerable<RepoStudent> GetObjects(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RepoStudent item)
        {
            DataStudent student = db.Students.Find(item.Id);
            student.Name = item.Name;
            db.Entry(student).State = EntityState.Modified;            
            db.SaveChanges();
        }
    }
}
