using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace G4_Guidance.Models
{
    public class User_Data_Managment
    {
        public bool insertData(User_Data user)
        {
            string con= @"Data Source=(localdb)\ProjectsV13;Initial Catalog='G4_Guidance';Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string query = "insert into LoginInfo(Username, Email, Password) values(@u, @e, @p)";
            SqlParameter p1 = new SqlParameter("u", user.username);
            SqlParameter p2 = new SqlParameter("e", user.email);
            SqlParameter p3 = new SqlParameter("p", user.password);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            int rows = cmd.ExecuteNonQuery();
            if(rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User_Data authneticate(User_Data user)
        {
            string con = @"Data Source=(localdb)\ProjectsV13;Initial Catalog='G4_Guidance';Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            string query = "select * from LoginInfo where username=@u";
            SqlParameter p1 = new SqlParameter("u", user.username);
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add(p1);
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    user.password = sdr[3].ToString();
                }
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
