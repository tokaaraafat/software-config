using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace software_config
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public List<string> GetEmpData(string NationalIDNumber)
        {
            List<string> employees = new List<string>();
            string connectionString = "Data Source = DESKTOP-J9HV5PE\\SQLEXPRESS; Initial Catalog = AdventureWorks2017; User ID = sa; Password = eslam; Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(" SELECT BusinessEntityID, NationalIDNumber, LoginID, OrganizationLevel, JobTitle, BirthDate, MaritalStatus, Gender, HireDate " +
                    "FROM HumanResources.Employee where (NationalIDNumber = N'" + NationalIDNumber + "')",connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string BusinessEntityID = reader["BusinessEntityID"].ToString();
                    string NationalIDNo = reader["NationalIDNumber"].ToString();
                    string LoginID = reader["LoginID"].ToString();
                    string OrganizationLevel = reader["OrganizationLevel"].ToString();
                    string JobTitle = reader["JobTitle"].ToString();
                    string BirthDate = reader["BirthDate"].ToString();
                    string MaritalStatus = reader["MaritalStatus"].ToString();
                    string Gender = reader["Gender"].ToString();
                    string HireDate = reader["HireDate"].ToString();
                    
                    employees.Add(BusinessEntityID);
                    employees.Add(NationalIDNo);
                    employees.Add(LoginID);
                    employees.Add(OrganizationLevel);
                    employees.Add(JobTitle);
                    employees.Add(BirthDate);
                    employees.Add(MaritalStatus);
                    employees.Add(Gender);
                    employees.Add(HireDate);
                    

                }


            }

            return employees;
        }
    }
}
