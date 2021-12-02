using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class ProdutoWorkflow : WorkflowBase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoWorkflow(IProdutoRepository produtoRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _unitOfWork = unitOfWork;
        }

        public Produto Add(ProdutoCommand command)
        {
            var Produto = new Produto(command);
            _produtoRepository.Add(Produto);
            _unitOfWork.Commit();

            return Produto;
        }

        public void Update(Guid id, ProdutoCommand command)
        {
           var Produto = _produtoRepository.ConsultarPorId(id);
                if (Produto == null)
                {
                    AddError("Produto", "Produto de dados não encontrado", id);
                }
                if (!IsValid())
                {
                    return;
                }
        }

        public void Delete(Guid id)
        {
            try
            {

                var Produto = _produtoRepository.ConsultarPorId(id);
                if (Produto == null)
                {
                    AddError("Produto", "Produto de dados não encontrado", id);
                }
                if (!IsValid())
                {
                    return;
                }

                _produtoRepository.Delete(Produto);
                _unitOfWork.Commit();
            }
            catch (System.Exception exp)
            {
                if (this.isDevelopment())
                    AddException("Produto", exp);
                else throw;
            }
        }
    }
}