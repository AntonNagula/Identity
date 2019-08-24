using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _14._08.Models
{
    public class AppLesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentNumber { get; set; }
        public AppStudent Student { get; set; }
    }
}