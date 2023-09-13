using JsonWebApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace JsonWebApplication2.Controllers
{
    public class StudentController : Controller
    {

        MvcDataEntities db = new MvcDataEntities();
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        public JsonResult GetStudent()
        {
            List<stdinfo> temp = db.stdinfoes.ToList();
            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        public string AddStudent(stdinfo s)
        {
            db.stdinfoes.Add(s);
            db.SaveChanges();
            return "Student Added Successfully!!!!";
        }

        public JsonResult GetStudentById(int id)
        {
            stdinfo s = db.stdinfoes.Find(id);
            return Json(s, JsonRequestBehavior.AllowGet);
        }

        public string UpdateStudent(stdinfo s)
        {
            db.Entry<stdinfo>(s).State = EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully!!!!";
        }

        public string DeleteStudent(int id)
        {
            stdinfo s = db.stdinfoes.Find(id);
            db.stdinfoes.Remove(s);
            db.SaveChanges();
            return "Student Deleted Successfully!!!!";
        }
    }
}