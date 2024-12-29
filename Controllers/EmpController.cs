using crud.Models;
using crud.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace crud.Controllers
{
    public class EmpController : Controller
    {
        EmpRepo erpo = new EmpRepo();
        // GET: Emp
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(erpo.getemplist());
        }        

        // GET: Emp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(Emp emp, FormCollection form)
        {
            try
            {
                var selectedHobbies = form.GetValues("Hobby");
                if (selectedHobbies != null)
                {
                    emp.Hobby = string.Join(", ", selectedHobbies); 
                }
                if (erpo.InsertData(emp))
                {
                    ViewBag.Message = "Saved";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(erpo.getemplist().Find(emp => emp.id == id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection form, Emp emp)
        {
            try
            {
                var selectedHobbies = form.GetValues("Hobby");
                if (selectedHobbies != null)
                {
                    emp.Hobby = string.Join(", ", selectedHobbies); 
                }
                else
                {
                    emp.Hobby = string.Empty; 
                }
                if (erpo.UpdateData(emp))
                {
                    ViewBag.Message = "Saved";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Emp/Delete/5
        public ActionResult Delete(int id)
        {
            return View(erpo.getemplist().Find(emp => emp.id == id));
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Emp emp)
        {
            try
            {
                if (erpo.DeleteData(emp))
                {
                    ViewBag.Message = "Saved";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }
    }
}
