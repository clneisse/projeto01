using System;
using UStart.Domain.Commands;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.UoW;

namespace UStart.Domain.Workflows
{
    public class ResponsavelWorkflow : WorkflowBase
    {
        private readonly IResponsavelRepository _responsavelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ResponsavelWorkflow(IResponsavelRepository responsavelRepository, IUnitOfWork unitOfWork)
        {
            _responsavelRepository = responsavelRepository;
            _unitOfWork = unitOfWork;
        }

        public Responsavel Add(ResponsavelCommand command)
        {
            var responsavel = new Responsavel(command);
            _responsavelRepository.Add(responsavel);
            _unitOfWork.Commit();

            return responsavel;
        }

        public void Update(Guid id, ResponsavelCommand command)
        {
            var responsavel = _responsavelRepository.ConsultarPorId(id);
            if (responsavel != null)
            {
                responsavel.Update(command);
                _responsavelRepository.Update(responsavel);
                _unitOfWork.Commit();
            }
            else
            {
                AddError("Responsavel", "Responsavel não encontrado", id);
            }
        }

        public void Delete(Guid id)
        {
            try
            {

                var responsavel = _responsavelRepository.ConsultarPorId(id);
                if (responsavel == null)
                {
                    AddError("Responsavel", "Responsavel de dados não encontrado", id);
                }
                if (!IsValid())
                {
                    return;
                }

                _responsavelRepository.Delete(responsavel);
                _unitOfWork.Commit();
            }
            catch (System.Exception exp)
            {
                if (this.isDevelopment())
                    AddException("Responsavel", exp);
                else throw;
            }
        }
    }
}