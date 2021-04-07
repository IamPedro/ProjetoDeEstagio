using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public static class ValidaMatricula
    {
        public static bool EhValido(int matricula)
        {
            if (matricula < 0)
            {
                throw new MatriculaInvalidaException();
            }

            return true;
        }
    }
}