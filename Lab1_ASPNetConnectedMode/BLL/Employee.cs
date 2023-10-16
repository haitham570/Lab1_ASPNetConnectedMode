using Lab1_ASPNetConnectedMode.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Lab1_ASPNetConnectedMode.BLL
{
    public class Employee
    {
        //fields
        private int employeeId;
        private string firstName;
        private string lastName;
        private string jobTitle;

        //props
        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string JobTitle { get => jobTitle; set => jobTitle = value; }

        public Employee()
        {
            employeeId = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            jobTitle = string.Empty;
        }
        


        //methods
        //public void SaveEmployee(Employee emp)
        //{
        //    EmployeeDB.SaveRecord(emp);
        //}
        public void SaveEmployee(Employee employee) => EmployeeDB.SaveRecord(employee);
        public List<Employee> GetAllEmployees() 
        {
            return EmployeeDB.GetAllRecords();
        }
        
        public void UpdateEmployee(Employee employee)=>EmployeeDB.UpdateRecord(employee);   
        public Employee SearchEmployee(int employeeId)=>EmployeeDB.GetEmployeeById(employeeId);
        public List<Employee> SearchEmployeeByName(string name)=>EmployeeDB.GetEmployeesByName(name);
        public void DeleteEmployee(int Eid)=>EmployeeDB.DeleteRecord(Eid);
        public bool IsDuplicateEmployeeID(int employee) => EmployeeDB.IsDublicateId(employee);
    }
}