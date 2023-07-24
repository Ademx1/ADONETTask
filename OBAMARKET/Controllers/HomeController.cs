using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OBAMARKET.Helpers;
using OBAMARKET.Models;
using OBAMARKET.Services.Implements;

namespace OBAMARKET.Controllers;

public class HomeController : Controller
{

        public async Task<IActionResult> Index()
        {
            List<Employee> employees = new List<Employee>();
            DataTable dt = await SqlHelper.SelectAsync("Select * from Employees");
            foreach (DataRow item in dt.Rows)
            {
                employees.Add(new()
                {
                    EmployeeId = (int)item[0],
                    Name = (string)item[1],
                    Surname = ((string)item[2]),
                    FathersName = (string)item[3],
                    Salary = (decimal)item[4],
                    PositionId = (int)item[5],
                   
                });
            }
            return View(employees);
        }

        [HttpPost]

    public async Task<IActionResult> Employee(string name, string surname, string FatherName, int Salary, int PositionId)
    {
        IEmployeeService service = new EmployeeService();
        await service.AddAsync(new Employee
        {
            Name = name,
            Surname = surname,
            FathersName = FatherName,
            Salary = Salary,
            PositionId = PositionId,
            
        });
        return RedirectToAction(nameof(EmployeeGetAll));
    }
    public async Task<IActionResult> EmployeeGetAll()
    {
        IEmployeeService service = new EmployeeService();
        return Json(await service.GetAllAsync());
    }
    public async Task<IActionResult> EmployeeGetById(int id)
    {
        IEmployeeService service = new EmployeeService();
        return Json(await service.GetByIdAsync(id));
    }
    public async Task<IActionResult> EmployeeDelete(int id)
    {
        IEmployeeService service = new EmployeeService();
        if (await service.Delete(id) > 0)
        {
            return Ok();
        }
        return NotFound();
    }


}

