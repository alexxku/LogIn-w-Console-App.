using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LogInLibrary
{
    public class register
    {
        static string connection = "Data Source=DESKTOP-2PSBHKH\\SQLEXPRESS;Initial Catalog=LoginDatabase;Integrated Security=True";
        public static SqlConnection LogInDataBase = new SqlConnection(connection);

        public static int reg(string username, string password)
        {
            string INSERT = "INSERT INTO [LogIn] ([UserName], [Password]) VALUES (@U, @P)";
            string SELECT = "SELECT [UserName], [Password] FROM LogIn WHERE [UserName] = @U";

            if (password == "" || password.Length < 1)
            {
                return 0;
            }

            SqlCommand command = new SqlCommand(SELECT, LogInDataBase);
            command.Parameters.AddWithValue("@U", username);

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

            if (username == user.Username)
            {

                return 1;
                
            }
            else
            {
                SqlCommand command2 = new SqlCommand(INSERT, LogInDataBase);
                command2.Parameters.AddWithValue("@U", username);
                command2.Parameters.AddWithValue("@P", password);

                LogInDataBase.Open();

                command2.ExecuteNonQuery();

                LogInDataBase.Close();

                return 2;
            }

        }
    }
}
