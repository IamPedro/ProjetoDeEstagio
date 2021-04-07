using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public static class ValidaNome
    {
        public static bool EhValido(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new NomeInvalidoException("Nome precisa ser preenchido. Digite um Nome válido.");
            
            for (int i = 0; i < nome.Length; i++)
            {
                if (!char.IsLetter(nome[i]) && !char.IsWhiteSpace(nome[i]))
                    throw new NomeInvalidoException();
            }

            return true;
        }
    }
}
