using System.Diagnostics;
using EmployeeVacation.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeVacation.Controllers
{
    public class EmployeeController : Controller
    {
        private static List<Employee> Employees = new List<Employee>();

        /// <summary>
        /// create a list of 10 instances of each type of employee
        /// </summary>
        static EmployeeController()
        {
            if (Employees.Count == 0) // Check to make sure there are no employees created
            {

                //Initialize 10 of each type of Employees
                for (int i = 0; i < 10; i++)
                {
                    Employees.Add(new HourlyEmployee($"HourlyEmployee - {i}"));
                    Employees.Add(new SalariedEmployee($"SalariedEmployee - {i}"));
                    Employees.Add(new Manager($"Manager - {i}"));
                }
            }
        }
        public IActionResult Index()
        {
            return View(Employees);
        }

        [HttpPost]
        public IActionResult WorkedDays(string name, int days)
        {
            var employee = Employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                try { employee.Work(days); }
                catch (System.Exception ex) { TempData["Error"] = ex.Message; }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult TakeVacation(string name, float days)
        {
            var employee = Employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                try { employee.TakeVacation(days); }
                catch (System.Exception ex) { TempData["Error"] = ex.Message; }
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
