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
    public class ProjectsController : ControllerBase
    {

        private readonly IProjectRepository _projectRepository;

        public ProjectsController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _projectRepository.GetProjectWithClient();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // var restultBuildings = this.buildingRepository.GetAll();
            var result = await _projectRepository.GetByIdAsync(id);
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
        public async Task<IActionResult> Post(Project project)
        {
            
            var newProject = await _projectRepository.CreateAsync(project);

            return Ok(newProject); ;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resultProject = await _projectRepository.GetByIdAsync(id);
            if (resultProject == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }
            await _projectRepository.DeleteAsync(resultProject);

            var ProjectEliminado = new
            {
                codigo = 200,
                status = "se elimino correctamente",
                objeto = resultProject
            };
            return Ok(ProjectEliminado);
        }


        // POST api/values
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Project project, int id)
        {
            //buscar producto
            var resultProject = await _projectRepository.GetByIdAsync(id);
            if (resultProject == null)
            {
                var noEncontrado = new
                {
                    codigo = 200,
                    status = "success",
                    objeto = "No encontrado"
                };
                return Ok(noEncontrado);
            }

            resultProject.Name = project.Name;
            resultProject.StartDate = project.StartDate;
            resultProject.EndDate = project.EndDate;
            resultProject.Price = project.Price;
            resultProject.NumberHours = project.NumberHours;
            


            var updatedProject = await _projectRepository.UpdateAsync(resultProject);
            return Ok(updatedProject);


        }
    }
}
