using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Domain
{
    public class Aluno : IEntidade
    {
        private int _matricula;
        private string _nome;
        private DateTime _nascimento;
        private string _cpf;

        public int Matricula
        {
            get => _matricula;
            set
            {
                if (ValidaMatricula.EhValido(value))
                {
                    _matricula = value;
                }
            } 

        }

        public string Nome
        {
            get => _nome;
            set
            {
                if (ValidaNome.EhValido(value))
                {
                    _nome = value.FormataNome();
                }
            } 

        }

        public EnumeradorSexo Sexo { get; set; }

        public DateTime Nascimento
        {
            get => _nascimento;
            set
            {
                if (ValidaNascimento.EhValido(value))
                {
                    _nascimento = value;
                }
            } 

        }

        public string CPF
        {
            get => _cpf;
            set
            {
                if (ValidaCPF.EhValido(value))
                {
                    _cpf = value;
                }
            } 

        }

        public override bool Equals(object obj)
        {
            return obj is Aluno aluno && aluno.Matricula == Matricula;
        }

        public override int GetHashCode()
        {
            return Matricula;
        }

        public override string ToString()
        {
            return $"{Matricula} | {Nome} | {Sexo} | {Nascimento} | {CPF}";
        }

    }
}
