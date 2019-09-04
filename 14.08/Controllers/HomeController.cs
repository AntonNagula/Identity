using _14._08.Filters;
using _14._08.Models;
using DomainInterface.Interfaces;
using _14._08.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _14._08.Controllers;

namespace _14._08.Controllers
{
    [Authorize(Roles = "admin,user,moderator")]
    public class HomeController : Controller
    {
        public readonly IService service;
        public HomeController(IService s)
        {
            service = s;
        }

        

        public ActionResult Index()
        {
            bool flag=HttpContext.User.IsInRole("user");
            if(flag==true)
            {
                AppStudent student = service.GetStudent(HttpContext.User.Identity.Name).FromDomainStudentToAppStudent();
                List<AppStudent> st=new List<AppStudent>();
                st.Add(student);
                return View(st);
            }
            else
                return View(service.GetStudents().Select(x => x.FromDomainStudentToAppStudent()).ToList());
        }

        public ActionResult GetLessons(int id)
        {
            var lessons = service.GetLessons(id).Select(x=>x.FromDomainLessonToAppLesson()).ToList();
            return View(lessons);
        }
        [HttpPost, CustomAuth]
        public ActionResult DeleteStudent(int id)
        {            
            return View("Contact");
        }

        [HttpGet, CustomAuth]
        public ActionResult UpdateStudent(int id)
        {
            return View(service.GetStudent(id).FromDomainStudentToAppStudent());
        }

        [HttpPost, CustomAuth]
        public ActionResult UpdateStudent(AppStudent value)
        {
            service.UpdateStudent(value.FromAppStudentToDomainStudent());
            return View("Contact");
        }

        [HttpGet, CustomAuth]
        public ActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost, CustomAuth]
        public ActionResult CreateStudent(AppStudent st)
        {
            service.CreateStudent(st.FromAppStudentToDomainStudent());
            return View("Contact");
        }

        [HttpGet, User]
        public ActionResult UpdateLesson(int id)
        {
            AppLesson lesson = service.GetLesson(id).FromDomainLessonToAppLesson();
            return View(lesson);
        }

        [HttpPost, User]
        public ActionResult UpdateLesson(AppLesson value)
        {
            service.UpdateLesson(value.FromAppLessonToDomainLesson());
            return View("Contact");
        }


        [HttpPost, Authorize(Roles = "admin,user")]
        public ActionResult DeleteLesson(int id)
        {
            service.Delete_Lesson(id);
            return View("Contact");
        }

        [HttpGet, User]
        public ActionResult CreateLesson(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }

        [HttpPost, User]
        public ActionResult CreateLesson(ViewLesson lesson)
        {
            service.Create_Lesson(lesson.FromViewLessonToDomainLesson());
            return View("Contact");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}