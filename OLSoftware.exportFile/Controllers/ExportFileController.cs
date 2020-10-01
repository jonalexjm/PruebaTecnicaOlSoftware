using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;
using OLSoftware.exportFile.Utils;
using OLSoftware.Infrastructure.Data;

namespace OLSoftware.exportFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportFileController : ControllerBase
    {
       
        string urlCliente = "https://localhost:44390/api/projects";

        private readonly OlsoftwareContext _context;
        private readonly string _connectionString;
        public ExportFileController(  IConfiguration configuration
                                   )
        {
            _connectionString = configuration.GetConnectionString("SqlServerConnection");

        }

        [HttpGet]
        public async Task<IActionResult> ExportFile(int id)
        {

            Log filelog = new Log(@"C:\Users\desarrollo\source\repos\SolutionOLSoftware\OLSoftware.exportFile\ExportedFile");

                using (SqlConnection sql = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("InfoProyectos", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var response = new List<ProjectViewModel>();
                        await sql.OpenAsync();
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Add(MapToValue(reader));
                            }
                        }

                    filelog.AddListaProyectos(response);

                    return Ok();
                    }
                }
            

            

            

        }

        private ProjectViewModel MapToValue(SqlDataReader reader)
        {

            return new ProjectViewModel
            {
                Name = reader["Name"].ToString(),
                Phone = reader["Phone"].ToString(),
                project = reader["project"].ToString(),
                StartDate = reader["StartDate"].ToString(),
                EndDate = reader["EndDate"].ToString(),
                Price = reader["Price"].ToString(),
                // NumberHours = reader["NumberHours"],
                Status = reader["Status"].ToString()

            };

        }
    }
}

