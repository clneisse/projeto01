using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UStart.Domain.Contracts.Entities;
using UStart.Domain.Contracts.Repositories;
using UStart.Domain.Entities;
using UStart.Domain.Results;
using UStart.Infrastructure.Context;

namespace UStart.Infrastructure.Repositories
{
    public class ResponsavelRepository : IResponsavelRepository
    {
        private readonly UStartContext _context;

        public ResponsavelRepository(UStartContext context)
        {
            _context = context;
        }

        public Responsavel ConsultarPorId(Guid id)
        {
            return _context.Responsaveis
                .FirstOrDefault(u => u.Id == id);
        }

        public void Add(Responsavel Responsavel)
        {
            _context.Responsaveis.Add(Responsavel);
        }

        public void Update(Responsavel Responsavel)
        {
            _context.Responsaveis.Update(Responsavel);
        }

        public virtual void Delete(Responsavel Responsavel)
        {
            if (_context.Entry(Responsavel).State == EntityState.Detached)
            {
                _context.Responsaveis.Attach(Responsavel);
            }
            _context.Responsaveis.Remove(Responsavel);
        }

        public IEnumerable<Responsavel> RetornarTodos()
        {
            return _context
                .Responsaveis                
                .ToList();
        }
        public IEnumerable<Responsavel> Pesquisar(string pesquisa)
        {
            pesquisa = pesquisa != null ?  pesquisa.ToLower() : "";
            return _context
            .Responsaveis
            .Where(x => x.Nome.ToLower().Contains(pesquisa))
            .ToList();
        }
    }
}
