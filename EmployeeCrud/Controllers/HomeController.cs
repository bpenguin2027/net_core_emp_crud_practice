using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeCrud.Models;

namespace EmployeeCrud.Controllers
{
    public class HomeController : Controller
    {
        //注入Model（DbContext）
        private EmpDbContext _context;

        public HomeController(EmpDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var employees = _context.TEmployees.ToList();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.TEmployees.Add(employee);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["Err"] = "員工編號重複";
                }
            }

            return View();
        }

        public IActionResult Delete(string id)
        {
            var employee = _context.TEmployees.FirstOrDefault(m => m.FEmpId == id);
            _context.TEmployees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var employee = _context.TEmployees.FirstOrDefault(m => m.FEmpId == id);

            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(TEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string empId = employee.FEmpId;
                    var temp = _context.TEmployees.FirstOrDefault(m => m.FEmpId == empId);

                    temp.FName = employee.FName;
                    temp.FGender = employee.FGender;
                    temp.FMail = employee.FMail;
                    temp.FSalary = employee.FSalary;
                    temp.FEmploymentDate = employee.FEmploymentDate;
                    _context.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception ex)
                {
                    ViewData["Err"] = "員工資料無法修改，請重新檢視修改資料";
                }
            }
            return View(employee);
        }
    }
}
