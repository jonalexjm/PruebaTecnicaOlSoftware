using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;

namespace OlSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesProgramsController : ControllerBase
    {
        private readonly IProgramLanguageRepository _programLanguageRepository;

        public LanguagesProgramsController(IProgramLanguageRepository programLanguageRepository)
        {
            _programLanguageRepository = programLanguageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _programLanguageRepository.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // var restultBuildings = this.buildingRepository.GetAll();
            var result = await _programLanguageRepository.GetByIdAsync(id);
            //  var resultInterno = result['result'];
            var returnObject = new
            {
                codigo = 200,
                status = "success",
                objeto = result
            };
            return Ok(returnObject);

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(ProgrammingLanguage programmingLanguage)
        {

            var newProject = await _programLanguageRepository.CreateAsync(programmingLanguage);

            return Ok(newProject); ;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _programLanguageRepository.GetByIdAsync(id);
            if (result == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }
            await _programLanguageRepository.DeleteAsync(result);

            var ObjEliminado = new
            {
                codigo = 200,
                status = "se elimino correctamente",
                objeto = result
            };
            return Ok(ObjEliminado);
        }


        // POST api/values
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProgrammingLanguage programmingLanguage, int id)
        {
            //buscar producto
            var result = await _programLanguageRepository.GetByIdAsync(id);
            if (result == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }

            result.Name = programmingLanguage.Name;
            result.Level = programmingLanguage.Level;
            



            var updatedObject = await _programLanguageRepository.UpdateAsync(result);
            return Ok(updatedObject);


        }
    }
}
