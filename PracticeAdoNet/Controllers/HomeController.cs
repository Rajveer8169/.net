using Microsoft.AspNetCore.Mvc;
using PracticeAdoNet.Models;
using System.Diagnostics;

namespace PracticeAdoNet.Controllers
{
    public class HomeController : Controller
    {
        EmployeeDataAccessLayer dal = new EmployeeDataAccessLayer();
        public IActionResult Index()
        {
            List<Employees> emp = dal.getAllEmployees();
            return View(emp);
        }
          
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employees emp)
        {
            try
            {
                dal.addEmployee(emp);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        public IActionResult Edit(int Id)
        {
            Employees emp = dal.getEmployeeById(Id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                dal.updateEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int Id)
        {
            Employees emp = dal.getEmployeeById(Id);
            return View(emp);
        }

        public IActionResult Delete(int Id)
        {
            Employees emp = dal.getEmployeeById(Id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Delete(Employees emp)
        {
            try
            {
                dal.deleteEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
