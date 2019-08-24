using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainInterface.Models
{
    public class DomainStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<DomainLesson> Lessons { get; set; }
        public DomainStudent()
        {
            Lessons = new List<DomainLesson>();
        }
    }
}
