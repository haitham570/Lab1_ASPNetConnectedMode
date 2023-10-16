using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using Lab1_ASPNetConnectedMode.GUI;
using Lab1_ASPNetConnectedMode.VALIDATION;
using Lab1_ASPNetConnectedMode.BLL;
using Lab1_ASPNetConnectedMode.DAL;

namespace Lab1_ASPNetConnectedMode.GUI
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListSearchBy.Items.Add("Employee ID");
                DropDownListSearchBy.Items.Add("First Name");
                DropDownListSearchBy.Items.Add("LastName");
  
                
            }
        }

        protected void ButtonListAllEmployees_Click(object sender, EventArgs e)
        {
            Lab1_ASPNetConnectedMode.BLL.Employee emp = new BLL.Employee();
            GridView1.DataSource = emp.GetAllEmployees();
            GridView1.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Employee emp = null;
            string searchBy = DropDownListSearchBy.SelectedValue;
            string searchText = TextBoxSearchBy.Text.Trim();
            List<Employee> searchResults = new List<Employee>();
            using (SqlConnection conn = UtilityDB.ConnectDB())
            {
                SqlCommand cmdSearch = new SqlCommand();
                cmdSearch.Connection = conn;

                switch (searchBy)
                {
                    case "Employee ID":
                        cmdSearch.CommandText = "SELECT * FROM Employees WHERE EmployeeId = @EmployeeId";
                        cmdSearch.Parameters.AddWithValue("@EmployeeId", int.TryParse(searchText, out int employeeId) ? employeeId : -1);
                        break;

                    case "First Name":
                        cmdSearch.CommandText = "SELECT * FROM Employees WHERE FirstName LIKE @FirstName";
                        cmdSearch.Parameters.AddWithValue("@FirstName", "%" + searchText + "%");
                        break;

                    case "Last Name":
                        cmdSearch.CommandText = "SELECT * FROM Employees WHERE LastName LIKE @LastName";
                        cmdSearch.Parameters.AddWithValue("@LastName", "%" + searchText + "%");
                        break;

                    // Handle other search criteria if needed

                    default:
                        // Handle an unsupported search criterion or show an error message
                        break;
                }

                using (SqlDataReader reader = cmdSearch.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        emp = new Employee
                        {
                            //EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            //FirstName = reader["FirstName"].ToString(),
                            //LastName = reader["LastName"].ToString(),
                            //JobTitle = reader["JobTitle"].ToString()
                        };
                        searchResults.Add(emp);
                    }
                }
            }

            // Bind the search results directly to the GridView
            GridView1.DataSource = searchResults;
            GridView1.DataBind();

        }

        protected void ButtonSaveEmployee_Click(object sender, EventArgs e)
        {
            Lab1_ASPNetConnectedMode.BLL.Employee emp = new BLL.Employee();
            string input=string.Empty;
            input = TextBoxEmployeeID.Text.Trim();
            if (!Validator.IsValid(input,4))
            {
                MessageBox.Show("Employee ID must be 4-digit number", "Invalid ID");
                TextBoxEmployeeID.Text = "";
                TextBoxEmployeeID.Focus();
                return;

            }
            if (emp.IsDuplicateEmployeeID(Convert.ToInt32(input)))
            {
                MessageBox.Show("Duplicate Employee Id", "Invalid");
                TextBoxEmployeeID.Text = "";
                TextBoxEmployeeID.Focus();
                return;
            }
            input = string.Empty;
            input= TextBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid First Name", "Invalid Data");
                TextBoxFirstName.Text = "";
                TextBoxFirstName.Focus();
                return;

            }
            input = string.Empty;
            input = TextBoxFirstName.Text.Trim();
            if (!Validator.IsValidName(input))
            {
                MessageBox.Show("Invalid Last Name", "Invalid Data");
                TextBoxLastName.Text = "";
                TextBoxLastName.Focus();
                return;

            }

            if (TextBoxJobTitle.Text.Length > 0)
            {
                emp.EmployeeId = Convert.ToInt32(TextBoxEmployeeID.Text.Trim());
                emp.FirstName = (TextBoxFirstName.Text.Trim());
                emp.LastName = (TextBoxLastName.Text.Trim());
                emp.JobTitle = (TextBoxJobTitle.Text.Trim());

                emp.SaveEmployee(emp);
                
                MessageBox.Show("Employee Saved Successfully","Confirmation");
                TextBoxEmployeeID.Text = "";
                TextBoxFirstName.Text = "";
                TextBoxLastName.Text = "";
                TextBoxJobTitle.Text = "";
            }


            

        }

        protected void ButtonDeleteEmployee_Click(object sender, EventArgs e)
        {
            if(TextBoxEmployeeID.Text.Length == 0) 
            {
                MessageBox.Show("pleease enter Employee ID to Delete");
                return;
            }
            Lab1_ASPNetConnectedMode.BLL.Employee emp = new BLL.Employee();
            if (!Validator.IsValid(TextBoxEmployeeID.Text))
            {
                MessageBox.Show("The id you entered is not right", "Invalid");
                return;
            }
            DialogResult ans = MessageBox.Show("Do you really want to delete this Employee?", "Confirmation");
            if (ans == DialogResult.Yes)
            {
                emp.DeleteEmployee(Convert.ToInt32(((TextBoxEmployeeID.Text).Trim())));
                MessageBox.Show("Employee record has been deleted successfully.", "Confirmation");
                
            }
            
        }

        protected void ButtonUpdateEmployee_Click(object sender, EventArgs e)
        {
            Lab1_ASPNetConnectedMode.BLL.Employee emp = new BLL.Employee();
            emp.EmployeeId=Convert.ToInt32(TextBoxEmployeeID.Text.Trim());
            emp.FirstName=TextBoxFirstName.Text.Trim();
            emp.LastName=TextBoxLastName.Text.Trim();
            emp.JobTitle=TextBoxJobTitle.Text.Trim();
            //validations that the employee exists
            //validate data entered if it's different or not 
            emp.UpdateEmployee(emp);
            MessageBox.Show("Employee data has been updated successfully.", "Confirmation");



        }
    }
}