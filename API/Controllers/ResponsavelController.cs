using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Workflows;

namespace UStart.API.Controllers
{
    /// <summary>
    /// Exemplo de controller
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/responsavel")]
    [Authorize]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly ResponsavelWorkflow _responsavelWorkflow;
        public ResponsavelController(
            IResponsavelRepository responsavelRepository, 
            ResponsavelWorkflow responsavelWorkflow)
        {
            _responsavelRepository = responsavelRepository;
            _responsavelWorkflow = responsavelWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok(_responsavelRepository.RetornarTodos());
        }

        /// <summary>
        /// Consultar apenas um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]    
        [Route("{id}")]    
        public IActionResult GetPorId([FromRoute] Guid id)
        {
            return Ok(_responsavelRepository.ConsultarPorId(id));
        }

        /// <summary>
        /// Adicionar (insert) um grupo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]            
        public IActionResult Adicionar([FromBody] ResponsavelCommand command)
        {
            _responsavelWorkflow.Add(command);
            if (_responsavelWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_responsavelWorkflow.GetErrors());
        }

        /// <summary>
        /// Atualizar (update) um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut] 
        [Route("{id}")]           
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] ResponsavelCommand command)
        {
            _responsavelWorkflow.Update(id, command);
            if (_responsavelWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_responsavelWorkflow.GetErrors());
        }

        /// <summary>
        /// Excluir um grupo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]            
        public IActionResult Deletar([FromRoute] Guid id)
        {
            _responsavelWorkflow.Delete(id);
            if (_responsavelWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_responsavelWorkflow.GetErrors());
        }


    }
}
