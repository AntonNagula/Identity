using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureInterfaces.Models
{
    public class RepoStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<RepoLesson> Lessons { get; set; }
        public RepoStudent()
        {
            Lessons = new List<RepoLesson>();
        }
    }
}
