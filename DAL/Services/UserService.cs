using DAL.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class UserService
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WAD24-DemoASP-DB;Integrated Security=True;";

        public IEnumerable<User> Get()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_User_GetAllActive";
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User result = new User()
                            {
                                User_Id = (Guid)reader[nameof(User.User_Id)],
                                First_Name = (string)reader[nameof(User.First_Name)],
                                Last_Name = (string)reader[nameof(User.Last_Name)],
                                Email = (string)reader[nameof(User.Email)],
                                Password = "********",
                                CreatedAt = (DateTime)reader[nameof(User.CreatedAt)],
                                DisabledAt = (reader[nameof(User.DisabledAt)] is DBNull)? null : (DateTime?)reader[nameof(User.DisabledAt)]
                            };
                            yield return result;
                        }
                    }
                }
            }
        }
    }
}
