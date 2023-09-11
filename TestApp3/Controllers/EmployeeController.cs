using Microsoft.AspNetCore.Mvc;
using TestApp3.Dto;
using TestApp3.Models;

namespace TestApp3.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
           
         var emp= db.Employees.Select(x => new EmployeeDto() {Id=x.Id,Name=x.Name,Gender=x.Gender,DepartmentId=x.DepartmentId,DepartmentName=x.DepartmentId.HasValue?x.Name:""}).ToList();
            return View(emp);
        }
        [HttpGet]
        public IActionResult AddEdit(int? id)
        {
            ViewBag.emp = db.Departments.Select(x => new DepartmentDto() { Id = x.Id, Name = x.Name, Code = x.Code}).ToList();
            EmployeeDto dep = new EmployeeDto();
            if (id > 0)
            {
                var demo = db.Employees.Find(id);

                dep.Name = demo.Name;
                dep.Gender = demo.Gender;
                dep.Id = demo.Id;
                dep.DepartmentId = demo.DepartmentId;

            }

            return View(dep);
        }
        [HttpPost]
        public IActionResult AddEdit(EmployeeDto model)
        {
            if (model.Id == 0)
            {
                Employee empo = new Employee();
                empo.Id = model.Id;
                empo.Name = model.Name;
                empo.Gender = model.Gender;
                empo.DepartmentId = model.DepartmentId;   
                db.Employees.Add(empo);
                db.SaveChanges();
            }

            else
            {
                Employee depa = db.Employees.Find(model.Id);
                depa.Name = model.Name;
                depa.Gender = model.Gender;
                db.Employees.Update(depa);
                db.SaveChanges();
            }




            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var para = db.Employees.Find(id);
            db.Employees.Remove(para);
            db.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
