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

            return View(dep);
        }
        [HttpPost]
        public IActionResult AddEdit(DepartmentDto model)
        {
            Department department= new Department();
            department.Id = model.Id;
            department.Name = model.Name;
            department.Code = model.Code;
            
            db.Departments.Add(department);
            db.SaveChanges();

            return View();
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
