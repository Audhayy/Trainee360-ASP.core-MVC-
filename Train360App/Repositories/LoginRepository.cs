using Microsoft.Data.SqlClient;
using Trainee360App.Helper;
using Trainee360App.Models;

namespace Trainee360App.Repositories
{
    public class LoginRepository
    {
        private readonly string _connectionString;

        public LoginRequestModel GetUserByEmail(string email)
        {
            LoginRequestModel loginRequest = null;
            try
            {
                using (var connection = ConnectionHelper.GetConnection(_connectionString))
                {
                    string query = "SELECT Email, Password FROM Users WHERE Email = @Email";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                loginRequest = new LoginRequestModel
                                {
                                    Email = reader["Email"].ToString(),
                                    Password = reader["Password"].ToString()
                                };
                                //user = new User
                                //{
                                //    Id = Convert.ToInt32(reader["Id"]),
                                //    FirstName = reader["FirstName"].ToString(),
                                //    LastName = reader["LastName"].ToString(),
                                //    DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                                //    Email = reader["Email"].ToString(),
                                //    Qualification = reader["Qualification"].ToString(),
                                //    Password = reader["Password"].ToString(),
                                //    IsActive = Convert.ToBoolean(reader["IsActive"]),
                                //    InsertedBy = reader["InsertedBy"].ToString(),
                                //    UpdatedBy = reader["UpdatedBy"].ToString(),
                                //    InsertedOn = Convert.ToDateTime(reader["InsertedOn"]),
                                //    LastUpdatedOn = Convert.ToDateTime(reader["LastUpdatedOn"]),
                                //    RoleId = Convert.ToInt32(reader["RoleId"])
                                //};
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in fetching user: " + ex.Message);
            }
            return loginRequest;
        }
    }
}
