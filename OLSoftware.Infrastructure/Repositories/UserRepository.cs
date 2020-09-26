using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace OLSoftware.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly OlsoftwareContext context;

        private readonly string _connectionString;

        public UserRepository(OlsoftwareContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            _connectionString = configuration.GetConnectionString("SqlServerConnection");
        }


        public async Task<List<User>> GetAllSP()
        {
            using(SqlConnection sql = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("GetAllUsers", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<User>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }

        }

        public async Task<User> GetIdUser(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetUserId", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    User response = null;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }

                    return response;
                }
            }

        }


        public async Task InsertUser(User user)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("@addresss", user.Address));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task UpdateUser(User user)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@phone", user.Phone));
                    cmd.Parameters.Add(new SqlParameter("@addresss", user.Address));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        public async Task DeleteById(int Id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", Id));
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return;
                }
            }
        }

        private User MapToValue(SqlDataReader reader)
        {
            return new User()
            {
                Id = (int)reader["Id"],
                Name = reader["Name"].ToString(),
                Phone = reader["Phone"].ToString(),
                Address = reader["Address"].ToString()
            };
        }

        public async Task<List<User>> GetProjectWithClient()
        {

            var result = await context.User.Include(b => b.UserProjects != null).ToListAsync();

            return result;
        }



    }
}
