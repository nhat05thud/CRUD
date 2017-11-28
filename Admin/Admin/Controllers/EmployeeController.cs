using EF.Context;
using EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData() {
            using (EmployeeContext db = new EmployeeContext()) {
                List<Employee> empList = db.Employees.ToList<Employee>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0) {
            if(id == 0) {
                return View(new Employee());
            }
            else
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    return View(db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>());
                }
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (EmployeeContext db = new EmployeeContext())
            {
                if (emp.EmployeeID == 0)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved successfully!!!" }, JsonRequestBehavior.AllowGet);
                }
                else {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated successfully!!!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int id) {
            using (EmployeeContext db = new EmployeeContext()) {
                    Employee emp = db.Employees.Where(x=>x.EmployeeID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}