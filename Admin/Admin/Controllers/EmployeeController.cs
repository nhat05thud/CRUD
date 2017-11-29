using Admin.Models;
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
                // Cách gán model ở tầng web hứng dữ liệu từ model tầng entity
                List<EmployeeModel> empList = db.Employees //gán list EmployeeModel = bảng Employees
                    .Select(x => new EmployeeModel
                    { // select các giá trị cần thiết cho bảng EmployeeModel
                        EmployeeID = x.EmployeeID,
                        Name = x.Name,
                        Age = x.Age,
                        Position = x.Position,
                        Office = x.Office,
                        Salary = x.Salary
                    }).ToList();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0) {
            if(id == 0) {
                return View(new EmployeeModel());
            }
            else
            {
                using (EmployeeContext db = new EmployeeContext())
                {
                    List<EmployeeModel> empList = db.Employees
                    .Select(x => new EmployeeModel
                    {
                        EmployeeID = x.EmployeeID,
                        Name = x.Name,
                        Age = x.Age,
                        Position = x.Position,
                        Office = x.Office,
                        Salary = x.Salary
                    }).ToList();
                    var view = empList.Where(x => x.EmployeeID == id).FirstOrDefault<EmployeeModel>();

                    return View(view);
                }
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel emp) // khi o client thao tac se qua model EmployeeModel tầng web
        {
            // buoc thuc hien luu xuong db => phai thao tac voi tang Entity
            using (EmployeeContext db = new EmployeeContext())
            {
                if (emp.EmployeeID == 0)
                {
                    // gán các thuộc tính của Employee tầng Entity = thuộc tính EmployeeModel tầng web
                    Employee obj = new Employee();
                    obj.EmployeeID = emp.EmployeeID;
                    obj.Name = emp.Name;
                    obj.Position = emp.Position;
                    obj.Office = emp.Office;
                    obj.Age = emp.Age;
                    obj.Salary = emp.Salary;
                    // Bảng Employees(tầng entity) Add obj
                    db.Employees.Add(obj);
                    // Database SaveChanges
                    db.SaveChanges();
                    // Trả về 1 Json
                    return Json(new { success = true, message = "Saved successfully!!!" }, JsonRequestBehavior.AllowGet);
                }
                else {
                    Employee obj = new Employee();
                    obj.EmployeeID = emp.EmployeeID;
                    obj.Name = emp.Name;
                    obj.Position = emp.Position;
                    obj.Office = emp.Office;
                    obj.Age = emp.Age;
                    obj.Salary = emp.Salary;

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated successfully!!!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
        [HttpPost]
        public ActionResult Delete(int id) {
            using (EmployeeContext db = new EmployeeContext())
            {
                Employee emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted successfully!!!" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}