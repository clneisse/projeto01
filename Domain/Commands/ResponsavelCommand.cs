using System;

namespace UStart.Domain.Commands
{
    public class ResponsavelCommand
    {
        public Guid Id { get; set; }
        public string CodigoExterno { get; set; }
        public bool Ativo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        
    }
}