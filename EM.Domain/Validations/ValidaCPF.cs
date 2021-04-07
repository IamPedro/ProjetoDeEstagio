using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public static class ValidaCPF
    {
        public static bool EhValido(string cpf)
        {
            if (!string.IsNullOrWhiteSpace(cpf))
            {
                if (cpf.Length != 11)
                {
                    throw new CPFInvalidoException("CPF Inválido. É necessário preencher os 11 dígitos ou deixe em branco.");
                }

                for (var i = 0; i < 11; i++)
                {
                    if (!char.IsDigit(cpf[i]))
                        throw new CPFInvalidoException("CPF Inválido. Digite apenas números ou deixe em branco.");
                }

                var intCpf = new int[11];
                int soma = 0, penultimoDigito = 0, ultimoDigito = 0;

                for (int i = 0, j = 10; i < 11; i++, j--)
                {
                    var sucessoNaConversao = int.TryParse(cpf[i].ToString(), out var valor);
                    intCpf[i] = valor;

                    if (j >= 2 && sucessoNaConversao)
                    {
                        soma += intCpf[i] * j;
                    }
                }

                var cpfComTodosDigitosIguais = true;
                for (var i = 1; i < 11; i++)
                {
                    if (intCpf[0] != intCpf[i])
                    {
                        cpfComTodosDigitosIguais = false;
                        break;
                    }
                }

                if (cpfComTodosDigitosIguais)
                {
                    throw new CPFInvalidoException("CPF Inválido. Os 11 dígitos não podem ser iguais. Digite um CPF válido ou deixe em branco.");
                }

                penultimoDigito = (soma * 10) % 11;
                if (penultimoDigito == 10)
                {
                    penultimoDigito = 0;
                }

                if (penultimoDigito != intCpf[9])
                {
                    throw new CPFInvalidoException();
                }

                soma = 0;
                for (int i = 0, j = 11; j >= 2; i++, j--)
                {
                    soma += intCpf[i] * j;
                }

                ultimoDigito = (soma * 10) % 11;
                if (ultimoDigito == 10)
                {
                    ultimoDigito = 0;
                }

                if (ultimoDigito != intCpf[10])
                {
                    throw new CPFInvalidoException();
                }
            }

            return true;
        }

    }
}
