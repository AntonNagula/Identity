using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14._08.Models
{
    public class AppStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<AppLesson> Lessons { get; set; }
        public AppStudent()
        {
            Lessons = new List<AppLesson>();
        }
    }
}