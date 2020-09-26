using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Data;

namespace OLSoftware.exportFile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportFileController : ControllerBase
    {
       
        private readonly IUserRepository _userRepository;

        private readonly OlsoftwareContext _context;
        public ExportFileController(
                                    OlsoftwareContext context,
                                    IUserRepository userRepository)
        {
            
            _context = context;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getCliente(int id)
        {

            var result = await  _userRepository.GetProjectWithClient();

            return Ok(result);

        }
    }
}
