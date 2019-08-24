using _14._08.Filters;
using _14._08.Models;
using DomainInterface.Interfaces;
using _14._08.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _14._08.Controllers
{
    [Authorize(Roles = "admin,user")]
    public class HomeController : Controller
    {
        public readonly IService service;
        public HomeController(IService s)
        {
            service = s;
        }

        public ActionResult Index()
        {            
            return View(service.GetStudents().Select(x=>x.FromDomainStudentToAppStudent()).ToList());
        }

        public ActionResult GetLessons(int id)
        {
            var lessons = service.GetLessons(id).Select(x=>x.FromDomainLessonToAppLesson()).ToList();
            return View(lessons);
        }
        [HttpPost, CustomAuth]
        public ActionResult DeleteStudent(int id)
        {
            service.Delete_Student(id);
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

        [HttpGet, CustomAuth]
        public ActionResult UpdateLesson(int id)
        {
            AppLesson lesson = service.GetLesson(id).FromDomainLessonToAppLesson();
            return View(lesson);
        }

        [HttpPost, CustomAuth]
        public ActionResult UpdateLesson(AppLesson value)
        {
            service.UpdateLesson(value.FromAppLessonToDomainLesson());
            return View("Contact");
        }


        [HttpPost, CustomAuth]
        public ActionResult DeleteLesson(int id)
        {
            service.Delete_Lesson(id);
            return View("Contact");
        }

        [HttpGet, CustomAuth]
        public ActionResult CreateLesson(int id)
        {
            ViewBag.StudentId = id;
            return View();
        }

        [HttpPost, CustomAuth]
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