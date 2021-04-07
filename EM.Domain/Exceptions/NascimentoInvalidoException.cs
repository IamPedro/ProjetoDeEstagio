using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class NascimentoInvalidoException : ApplicationException
    {
        public NascimentoInvalidoException() : base("Nascimento Inválido. Digite um Nascimento válido.") { }
        public NascimentoInvalidoException(string msg) : base(msg) { }
    }
}
