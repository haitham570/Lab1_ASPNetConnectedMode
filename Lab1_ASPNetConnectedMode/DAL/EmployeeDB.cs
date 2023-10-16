using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;
//using Lab1_ASPNetConnectedMode.GUI;
using System.Collections;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {

        public static void SaveRecord(Employee emp)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = connDB;
            cmdInsert.CommandText = "INSERT INTO Employees(EmployeeId,FirstName,LastName,JobTitle) " +
                            "Values(@EmployeeId,@FirstName,@LastName,@JobTitle) ";
            cmdInsert.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdInsert.Parameters.AddWithValue("FirstName", emp.FirstName);
            cmdInsert.Parameters.AddWithValue("LastName", emp.LastName);
            cmdInsert.Parameters.AddWithValue("JobTitle", emp.JobTitle);

            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }
        //method to update
        public static void UpdateRecord(Employee emp) 
        {
            SqlConnection connDB = UtilityDB.ConnectDB();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = connDB;
            cmdUpdate.CommandText= "UPDATE Employees SET FirstName =@FirstName , LastName =@LastName, JobTitle =@JobTitle WHERE EmployeeId =@EmployeeId";

            cmdUpdate.Parameters.AddWithValue("EmployeeId",emp.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("JobTitle", emp.JobTitle);

            cmdUpdate.ExecuteNonQuery();
            connDB.Close();

        }


        // method to delete
        public static void DeleteRecord(int id)
        {
            // Connect to the database
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                // Define the SQL command for deleting the record
                string deleteQuery = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";

                // Create a SqlCommand object
                using (SqlCommand cmdDelete = new SqlCommand(deleteQuery, connDB))
                {
                    // Add parameters to the SQL command
                    cmdDelete.Parameters.AddWithValue("@EmployeeId", id);

                    // Execute the delete command
                    cmdDelete.ExecuteNonQuery();
                }
            }
        }


        //method to list all employee record
        public static List<Employee> GetAllRecords() 
        {
            List<Employee> listE = new List<Employee>();
            using(SqlConnection conn = UtilityDB.ConnectDB()) 
            {
                SqlCommand cmdList = new SqlCommand("SELECT *FROM Employees",conn);
                SqlDataReader reader = cmdList.ExecuteReader();
                while (reader.Read()) 
                {
                    Employee emp = new Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString() ;
                    emp.JobTitle = reader["JobTitle"].ToString();
                    listE.Add( emp );
                }

            }


            return listE;
        }

        //method to search an employee record through Id,

        // Add this method to the EmployeeDB class
        public static Employee GetEmployeeById(int employeeId)
        {
            Employee employee = null;

            // Connect to the database
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                // Define the SQL command for selecting the employee by ID
                string selectQuery = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";

                // Create a SqlCommand object
                using (SqlCommand cmdSelect = new SqlCommand(selectQuery, connDB))
                {
                    // Add the parameter for the employee ID
                    cmdSelect.Parameters.AddWithValue("@EmployeeId", employeeId);

                    // Execute the query
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        // Check if a record was found
                        if (reader.Read())
                        {
                            // Create an Employee object and populate it with data from the database
                            employee = new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                JobTitle = reader["JobTitle"].ToString()
                            };
                        }
                    }
                }
            }

            return employee;
        }

        public static List<Employee> GetEmployeesByName(string name)
        {
            List<Employee> employees = new List<Employee>();

            // Connect to the database
            using (SqlConnection connDB = UtilityDB.ConnectDB())
            {
                // Define the SQL command for selecting employees by first name or last name
                string selectQuery = "SELECT * FROM Employees WHERE FirstName LIKE @Name OR LastName LIKE @Name";

                // Create a SqlCommand object
                using (SqlCommand cmdSelect = new SqlCommand(selectQuery, connDB))
                {
                    // Add the parameter for the name (assuming you want to search by partial matches)
                    cmdSelect.Parameters.AddWithValue("@Name", "%" + name + "%");

                    // Execute the query
                    using (SqlDataReader reader = cmdSelect.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Create an Employee object for each matching record and add it to the list
                            Employee employee = new Employee
                            {
                                EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                JobTitle = reader["JobTitle"].ToString()
                            };
                            employees.Add(employee);
                        }
                    }
                }
            }

            return employees;
        }
        public static bool IsDublicateId(int checkId)
        {
            Employee emp = new Employee();
            emp = GetEmployeeById(checkId);
            if (emp != null)
            {
                return true;
            }

            
            return false;
        }

    }
}