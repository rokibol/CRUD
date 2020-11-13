using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            List<StudentInfoModel> studentInfoModels = new StudentInfoModel().GetStudentList();
            if (studentInfoModels != null && studentInfoModels.Count > 0)
                return View(studentInfoModels);
            else
                return View(new List<StudentInfoModel>());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            StudentInfoModel model = new StudentInfoModel().GetStudentDetails(id);
            return View(model);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            StudentInfoModel model = new StudentInfoModel();
            return View(model);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentInfoModel model)
        {
            try
            {
                // TODO: Add insert logic here
                model.InsertStudent(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentInfoModel model = new StudentInfoModel().GetStudentDetails(id);
            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentInfoModel model)
        {
            try
            {
                // TODO: Add update logic here
                model.UpdateStudent(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentInfoModel model = new StudentInfoModel().GetStudentDetails(id);
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(StudentInfoModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model.DeleteStudent(model.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
