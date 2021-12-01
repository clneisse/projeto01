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
    [Route("api/v{version:apiVersion}/fornecedor")]
    [Authorize]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly FornecedorWorkflow _fornecedorWorkflow;
        public FornecedorController(
            IFornecedorRepository fornecedorRepository, 
            FornecedorWorkflow fornecedorWorkflow)
        {
            _fornecedorRepository = fornecedorRepository;
            _fornecedorWorkflow = fornecedorWorkflow;
        }

        /// <summary>
        /// Consultar todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult Get()
        {
            return Ok(_fornecedorRepository.RetornarTodos());
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
            return Ok(_fornecedorRepository.ConsultarPorId(id));
        }

        /// <summary>
        /// Adicionar (insert) um grupo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]            
        public IActionResult Adicionar([FromBody] FornecedorCommand command)
        {
            _fornecedorWorkflow.Add(command);
            if (_fornecedorWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_fornecedorWorkflow.GetErrors());
        }

        /// <summary>
        /// Atualizar (update) um grupo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut] 
        [Route("{id}")]           
        public IActionResult Atualizar([FromRoute] Guid id, [FromBody] FornecedorCommand command)
        {
            _fornecedorWorkflow.Update(id, command);
            if (_fornecedorWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_fornecedorWorkflow.GetErrors());
        }

        /// <summary>
        /// Excluir um grupo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]            
        public IActionResult Deletar([FromRoute] Guid id)
        {
            _fornecedorWorkflow.Delete(id);
            if (_fornecedorWorkflow.IsValid())
            {
                return Ok();
            }
            return BadRequest(_fornecedorWorkflow.GetErrors());
        }


    }
}
