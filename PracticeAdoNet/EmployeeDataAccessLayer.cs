using Microsoft.Data.SqlClient;
using PracticeAdoNet.Models;
using System.Data;

namespace PracticeAdoNet
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public List<Employees> getAllEmployees()
        {
            List<Employees> ListEmp = new List<Employees>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.EmpName = reader["EmpName"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";
                    emp.State = reader["State"] == DBNull.Value ? "" : reader["State"].ToString() ?? "";
                    ListEmp.Add(emp);
                }
                reader.Close();
            }
            return ListEmp;
        }

        public Employees getEmployeeById(int Id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE Id = @Id", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("id", Id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    emp.Id = Convert.ToInt32(reader["ID"]);
                    emp.EmpName = reader["EmpName"].ToString() ?? "";
                    emp.Gender = reader["Gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString() ?? "";
                    emp.City = reader["City"].ToString() ?? "";
                }
                reader.Close();  
            }
            return emp;
        }

        public void addEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("Gender", emp.Gender);
                cmd.Parameters.AddWithValue("Age", emp.Age);
                cmd.Parameters.AddWithValue("Designation", emp.Designation);
                cmd.Parameters.AddWithValue("City", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void updateEmployee(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", emp.Id);
                cmd.Parameters.AddWithValue("EmpName", emp.EmpName);
                cmd.Parameters.AddWithValue("Gender", emp.Gender);
                cmd.Parameters.AddWithValue("Age", emp.Age);
                cmd.Parameters.AddWithValue("Designation", emp.Designation);
                cmd.Parameters.AddWithValue("City", emp.City);

                con.Open();  
                cmd.ExecuteNonQuery();
            }
        } 

        public void deleteEmployee(Employees emp)
        {
            using(SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", emp.Id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}