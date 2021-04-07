using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class CPFInvalidoException : ApplicationException
    {
        public CPFInvalidoException() : base("CPF Inválido. Digite um CPF válido ou deixe em branco.") { }
        public CPFInvalidoException(string msg) : base(msg) { }
    }
}
