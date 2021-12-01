using System;
using UStart.Domain.Commands;

namespace UStart.Domain.Entities
{
    public class Responsavel
    {
        public Guid Id { get; private set; }
        public string CodigoExterno { get; private set; }
        public bool Ativo { get; private set; }
        public String Nome { get; private set; }
        public String Email { get; private set; }

        public Responsavel()
        {
            
        }

        public Responsavel(ResponsavelCommand command)
        {
            Id = command.Id == Guid.Empty ? Guid.NewGuid() : command.Id;   
            AtualizarCampos(command);
        }

        public void Update(ResponsavelCommand command)
        {
            AtualizarCampos(command);
        }

        private void AtualizarCampos(ResponsavelCommand command)
        {
            this.Id = command.Id;        
            CodigoExterno = command.CodigoExterno;                        
            Ativo = command.Ativo;                        
            Nome = command.Nome;                                             
            Email = command.Email;                                               
        }

    }
}