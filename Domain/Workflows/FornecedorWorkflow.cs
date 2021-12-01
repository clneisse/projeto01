using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class FornecedorWorkflow : WorkflowBase
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FornecedorWorkflow(IFornecedorRepository fornecedorRepository, IUnitOfWork unitOfWork)
        {
            _fornecedorRepository = fornecedorRepository;
            _unitOfWork = unitOfWork;
        }

        public Fornecedor Add(FornecedorCommand command)
        {
            var fornecedor = new Fornecedor(command);
            _fornecedorRepository.Add(fornecedor);
            _unitOfWork.Commit();

            return fornecedor;
        }

        public void Update(Guid id, FornecedorCommand command)
        {
            var fornecedor = _fornecedorRepository.ConsultarPorId(id);
            if (fornecedor != null)
            {
                fornecedor.Update(command);
                _fornecedorRepository.Update(fornecedor);
                _unitOfWork.Commit();
            }
            else
            {
                AddError("Fornecedor", "Fornecedor não encontrado", id);
            }
        }

        public void Delete(Guid id)
        {
            try
            {

                var fornecedor = _fornecedorRepository.ConsultarPorId(id);
                if (fornecedor == null)
                {
                    AddError("Fornecedor", "Fornecedor não encontrado", id);
                }
                if (!IsValid())
                {
                    return;
                }

                _fornecedorRepository.Delete(fornecedor);
                _unitOfWork.Commit();
            }
            catch (System.Exception exp)
            {
                if (this.isDevelopment())
                    AddException("Fornecedor", exp);
                else throw;
            }
        }
    }
}