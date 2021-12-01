using System;
using System.Collections.Generic;
using UStart.Domain.Entities;

namespace UStart.Domain.Contracts.Repositories
{
    public interface IResponsavelRepository
    {
        void Add(Responsavel Responsavel);
        Responsavel ConsultarPorId(Guid id);
        void Delete(Responsavel Responsavel);
        IEnumerable<Responsavel> Pesquisar(string pesquisa);
        IEnumerable<Responsavel> RetornarTodos();
        void Update(Reponsavel Responsavel);
    }
}
