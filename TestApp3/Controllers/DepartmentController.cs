using Microsoft.AspNetCore.Mvc;
using TestApp3.Dto;
using TestApp3.Models;

namespace TestApp3.Controllers
{
    public class DepartmentController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public IActionResult Index()
        {
           
      var  para=  db.Departments.Select(x => new DepartmentDto() {Id=x.Id,Name=x.Name,Code=x.Code}).ToList();
            return View(para);
        }
        [HttpGet]
        public IActionResult AddEdit(int ?id)
        {

            DepartmentDto dep= new DepartmentDto();
            if (id > 0)
            {
             var demo=   db.Departments.Find(id);

                dep.Name = demo.Name;
                dep.Code=demo.Code;
                dep.Id = demo.Id;

            }

            return View(dep);
        }
        [HttpPost]
        public IActionResult AddEdit(DepartmentDto model)
        {
            if(model.Id==0)
            {
                Department department = new Department();
                department.Id = model.Id;
                department.Name = model.Name;
                department.Code = model.Code;
                db.Departments.Add(department);
                db.SaveChanges();
            }

            else
            {
             Department depa=   db.Departments.Find(model.Id);
               depa.Name = model.Name;
                depa.Code = model.Code;
                db.Departments.Update(depa);
                db.SaveChanges();   
            }
            
           
            

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            var para = db.Departments.Find(id);
            db.Departments.Remove(para);
            db.SaveChanges();
            return RedirectToAction("index");
        }


    }
    
}
