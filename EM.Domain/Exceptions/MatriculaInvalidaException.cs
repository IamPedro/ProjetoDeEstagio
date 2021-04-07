using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class MatriculaInvalidaException : ApplicationException
    {
        public MatriculaInvalidaException() : base("Matrícula Inválida. Digite uma Matrícula válida.") { }
        public MatriculaInvalidaException(string msg) : base(msg) { }
    }
}
