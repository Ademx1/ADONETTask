using System;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using OBAMARKET.Controllers;
using OBAMARKET.Models;
using OBAMARKET.Helpers;

namespace OBAMARKET.Services.Implements;

public class EmployeeService : IEmployeeService
{
    public async Task<int> AddAsync(Employee employee)
    {
        return await SqlHelper.ExecuteAsync($"INSERT INTO Employees VALUES ({employee.Name}, {employee.Surname},{employee.FathersName},{employee.PositionId})");
    }

    public async Task<int> AddAsync(List<Employee> employees)
    {
        string query = "INSERT INTO Employees VALUES";
        foreach (Employee employee in employees)
        {
            query += $"{employee.Name}, {employee.Surname},{employee.FathersName},{employee.PositionId}),";
        }
        return await SqlHelper.ExecuteAsync(query.Substring(0, query.Length - 1));
    }

    public async Task<int> Delete(int id)
    {
        await GetByIdAsync(id);
        return await SqlHelper.ExecuteAsync("DELETE Employee WHERE Id = " + id);
    }

    public async Task<List<Employee>> GetAllAsync()
    {
        List<Employee> list = new List<Employee>();
        DataTable dt = await SqlHelper.SelectAsync("Select * from Employees");
        foreach (DataRow item in dt.Rows)
        {
            list.Add(new Employee
            {
                EmployeeId = (int)item["Id"],
                Name = (string)item["Name"],
                Surname = (string)(item["Surname"]),
                FathersName = (string)item["FatherName"],
                Salary = (int)item["Salary"],
                PositionId = (int)item["PositionId"],
            });
        }
        return list;
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        DataTable dt = await SqlHelper.SelectAsync("Select * from Employees where Id = " + id);
        if (dt.Rows.Count != 1) throw new Exception("Error");
        return new Employee
        {
            EmployeeId = (int)dt.Rows[0]["Id"],
            Name = (string)dt.Rows[0]["Name"],
            Surname = (string)dt.Rows[0]["Surname"],
            FathersName = (string)dt.Rows[0]["FatherName"],
            Salary = (int)dt.Rows[0]["Salary"],
            PositionId = (int)dt.Rows[0]["PositionId"],
        };
    }

    public Task<Employee> Update(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> Update(int id, Employee employee)
    {
        throw new NotImplementedException();
    }

}
