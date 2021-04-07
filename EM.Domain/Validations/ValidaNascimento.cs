using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public static class ValidaNascimento
    {
        public static bool EhValido(DateTime nascimento)
        {
            if (nascimento.Equals(DateTime.MinValue))
                throw new NascimentoInvalidoException();

            if (nascimento > DateTime.Now)
                throw new NascimentoInvalidoException("Nascimento Inválido. Só é aceito datas anteriores a atual. Digite um Nascimento válido.");

            return true;
        }
    }
}
