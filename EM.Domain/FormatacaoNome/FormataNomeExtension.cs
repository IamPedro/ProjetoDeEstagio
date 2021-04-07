using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public static class FormataNomeExtension
    {
        public static string FormataNome(this string nome)
        {
            nome = nome.Trim();
            nome = nome.First().ToString().ToUpper() + nome.Substring(1).ToLower();

            string[] partesDoNome = nome.Split(' ');
            string[] conectoresDeNome = new string[] { "da", "de", "do", "das", "dos" };
            

            for (int i = 1; i < partesDoNome.Length; i++)
            {
                bool minusculo = false;
                for (int j = 0; j < conectoresDeNome.Length; j++)
                {
                    if (!partesDoNome[i].Equals(conectoresDeNome[j])) continue;
                    minusculo = true;
                    break;
                }

                if (minusculo) continue;
                char primeiraLetra = partesDoNome[i][0];
                partesDoNome[i] = partesDoNome[i].Remove(0, 1).Insert(0, primeiraLetra.ToString().ToUpper());
            }

            nome = string.Join(" ", partesDoNome);

            return nome;
        }
    }
}
