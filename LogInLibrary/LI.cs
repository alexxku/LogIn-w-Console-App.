using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace LogInLibrary
{
    public class Log
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=LoginDatabase;Integrated Security=True";
        public static SqlConnection LogInDataBase = new SqlConnection(connection);

        public static bool lg(string username, string password)
        {
            string SELECT = "SELECT [UserName], [Password] FROM LogIn WHERE [UserName] = @u AND [Password] = @p";

            SqlCommand command = new SqlCommand(SELECT, LogInDataBase);
            command.Parameters.AddWithValue("@u", username);
            command.Parameters.AddWithValue("@p", password);

            LogInDataBase.Open();

            command.ExecuteNonQuery();

            SqlDataReader reader = command.ExecuteReader();

            UserInfo user = new UserInfo();

            while (reader.Read())
            {
                user.Username = reader["UserName"].ToString();
                user.Password = reader["Password"].ToString();
            }

            LogInDataBase.Close();

            if (user.Username != null && user.Password != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
