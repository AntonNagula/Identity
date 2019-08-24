using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustuctureData.Models
{
    public class DataStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<DataLesson> Lessons { get; set; }
        public DataStudent()
        {
            Lessons = new List<DataLesson>();
        }
    }
}
