using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CSharp_Project
{


    class EmployeeInformation
    {
        EmployeeDetails AddEmployee()
        {
            var emp = new EmployeeDetails();
            Console.WriteLine("Please Enter Employee Details: ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Please Enter Name: ");
            EmployeeDetails.name = Console.ReadLine();

            Console.WriteLine("Please Enter Gender: ");
            EmployeeDetails.gender = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Please Enter Email id: ");
            EmployeeDetails.email = Console.ReadLine();
            Console.WriteLine("Please Enter Location: ");
            EmployeeDetails.location = Console.ReadLine();
            Console.WriteLine("Please Enter Company: ");
            EmployeeDetails.company = Console.ReadLine();
            Console.WriteLine("Please Enter Salary: ");
            EmployeeDetails.salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("----------------------------------------");

            return emp;
        }

        EmployeeDetails DeleteEmployeeInfo()
        {
            var emp = new EmployeeDetails();
            Console.WriteLine("Please Enter id: ");
            EmployeeDetails.id = Convert.ToInt32(Console.ReadLine());

            return emp;
        }



        EmployeeDetails UpdateEmployeeInfo()
        {
            var emp = new EmployeeDetails();
            Console.WriteLine("Please Enter Id: ");
            EmployeeDetails.id = Convert.ToInt32(Console.ReadLine());
            return emp;
        }


        static public void InsertConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-70U6D1RS\SQLEXPRESS;Initial Catalog=CSharpProjectDotNet;Integrated Security=True");
            string query = "insert into tbl_Employee " +
                "(Emp_Name,Emp_Gen,Emp_Email,Emp_Loc,Emp_Company,Emp_Salary)"
                + "values('" + EmployeeDetails.name + "','" + EmployeeDetails.gender + "','" + EmployeeDetails.email + "','" + EmployeeDetails.location + "','" + EmployeeDetails.company + "','" + EmployeeDetails.salary + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
          Console.WriteLine("Record Inserted Successfully !!");
            Console.ReadLine();
            con.Close();
        }

        static public void DeleteConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-70U6D1RS\SQLEXPRESS;Initial Catalog=CSharpProjectDotNet;Integrated Security=True");
            string query = "delete from tbl_Employee where Emp_ID='" + EmployeeDetails.id + "'; ";
            //  string text = "update tbl_Employee set Emp_Name='" + EmployeeDetails.name + "',Emp_Gen='" + EmployeeDetails.gender + "',Emp_Email='" + EmployeeDetails.email + "',Emp_Loc='" + EmployeeDetails.location + "',Emp_Company='" + EmployeeDetails.company + "',Emp_Salary='" + EmployeeDetails.salary + "'where Emp_ID='"+EmployeeDetails.id+"';";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("\n\n-----------------------------------------Congratulation-----------------------------------------");
            Console.WriteLine("Record Deleted Successfully !!");
            con.Close();
        }

        //static public void GetDataConnection()
        //{
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-L395RBO\TUSSI;Initial Catalog=CSharpProject;Integrated Security=True");
        //    con.Open();
        //    DataSet ds = new DataSet();

        //    string query = "select * from tbl_Employee";

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr = cmd.ExecuteReader();

        //    Console.WriteLine("\n\n-----------------------------------------Congratulation-----------------------------------------");
        //    Console.WriteLine("Record Access Successfully !!");
        //    con.Close();
        //}

        static public void UpdateConnection()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-70U6D1RS\SQLEXPRESS;Initial Catalog=CSharpProjectDotNet;Integrated Security=True");
            string text = "update tbl_Employee set Emp_Name='" + EmployeeDetails.name + "',Emp_Gen='" + EmployeeDetails.gender + "',Emp_Email='" + EmployeeDetails.email + "',Emp_Loc='" + EmployeeDetails.location + "',Emp_Company='" + EmployeeDetails.company + "',Emp_Salary='" + EmployeeDetails.salary + "'where Emp_ID='" + EmployeeDetails.id + "';";


            SqlCommand cmd = new SqlCommand(text, con);
            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("\n\n-----------------------------------------Congratulation-----------------------------------------");
            Console.WriteLine("Record Updated Successfully !!");
            con.Close();
        }


        static void Main(string[] args)
        {
            string againRepeate;

            do
            {
                Console.WriteLine("\t\t\t\t\t\tPlease Select A Choice !!\n");

                Console.WriteLine("Please Enter 1-Add Employee, 2-Show Single Employee Info," +
               "3-Show All Employee Info, 4-Update Employee Info, 5-Delete Employee Info, 6-Exit: ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------\n");

                EmployeeInformation info = new EmployeeInformation();
                


                int userChoice = Convert.ToInt32(Console.ReadLine());

                UserInput input = (UserInput)userChoice;

                switch (input)
                {
                    case UserInput.AddEmployee:
                        EmployeeDetails emp = info.AddEmployee();
                        Console.WriteLine(EmployeeDetails.name + " " + EmployeeDetails.gender + " " + EmployeeDetails.email + " " + EmployeeDetails.location + " " + " " + EmployeeDetails.company + " " + " " + EmployeeDetails.salary);
                        InsertConnection();
                        break;

                    case UserInput.ShowSingleEmployeeInfo:
                        break;

                    case UserInput.ShowAllEmployeeInfo:

                        // GetDataConnection();
                        break;

                    case UserInput.UpdateEmployeeInfo:
                        EmployeeDetails emp2 = info.UpdateEmployeeInfo();
                        emp2 = info.AddEmployee();
                        UpdateConnection();


                        break;

                    case UserInput.DeleteEmployeeInfo:
                        EmployeeDetails emp1 = info.DeleteEmployeeInfo();
                        DeleteConnection();
                        break;

                    case UserInput.Exit:

                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Do You Want To Again Repeate Your Operation Perform ? 'YES' or 'NO'");
                againRepeate = Console.ReadLine().ToLower();
            }
            while (againRepeate == "yes" || againRepeate == "y");
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("\t\t\t\t! Thank You for Visiting My Project (: Have a nice day (: ");



            Console.ReadLine();
        }
    }
}

