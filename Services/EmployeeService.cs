using EmployeeDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace EmployeeDashboard.Services
{
    public class EmployeeService
    {
        static List<Employee> Employees = new List<Employee>();
       
        static EmployeeService()
        {
            //IEnumerable<Employee> Employees = new List<Employee>();
        }

        //Fetch all Employees
        public IEnumerable<Employee> _GetAll() => Employees;
        

        //Fetch employee by specific Id
        public Employee _GetById(int id) =>
                Employees.Where(p => p.Id == id).SingleOrDefault() ?? new();


        //Add employee
        public bool _AddEmployee(Employee employee) {
           foreach(var item in Employees)
            {
                if (item.Id == employee.Id) return false;
            }
            Employees.Add(employee);
            return true;
        } 
        

        //Delete Employee info
        public void _DeleteEmployee(int id)
        {
            EmployeeService.Employees = Employees.Where(emp => emp.Id != id).ToList();
        }

        public bool _EditEmployee(Employee employee)
        {
            for(int i=0; i<Employees.Count;i++)
            {
                if (Employees[i].Id == employee.Id)
                {
                    Employees[i] = employee;
                    return true;//new Employee(employee.Id,employee.FirstName,employee.SecondName,employee.Phone,employee.Department,employee,employee.Role);
                }
            }
            return false;
        }
    }
}
