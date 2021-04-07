using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class NomeInvalidoException : ApplicationException
    {
        public NomeInvalidoException() : base("Nome Inválido, só aceita letras. Digite um Nome válido.") { }
        public NomeInvalidoException(string msg) : base(msg) { }
    }
}
