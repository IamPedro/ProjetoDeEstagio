using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Domain;
using Xunit;

namespace EM.Domain.Testes
{
    public class AlunoTestes
    {
        [Theory]
        [InlineData(100, 100)]
        [InlineData(2, 2)]
        [InlineData(20501, 20501)]
        public void Equals_MatriculasShouldBeEquals(int matricula1, int matricula2)
        {
            Aluno aluno1 = new Aluno() { Matricula = matricula1 };
            Aluno aluno2 = new Aluno() { Matricula = matricula2 };
            const bool expected = true;

            bool actual = aluno1.Equals(aluno2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(50, 231)]
        [InlineData(10, 5)]
        public void Equals_MatriculasShouldBeDifferent(int matricula1, int matricula2)
        {
            Aluno aluno1 = new Aluno() { Matricula = matricula1 };
            Aluno aluno2 = new Aluno() { Matricula = matricula2 };
            const bool expected = false;

            bool actual = aluno1.Equals(aluno2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        public void GetHashCode_MatriculaShouldBeEqualHashCode(int matricula)
        {
            Aluno aluno = new Aluno() { Matricula = matricula };

            Assert.Equal(aluno.Matricula, aluno.GetHashCode());
        }

        [Theory]
        [InlineData(2, "Pedro", EnumeradorSexo.Masculino, "01/05/1902", "")]
        public void ToString_AlunoPropertiesShouldBeEqualToString(int matricula, string nome, EnumeradorSexo sexo, string nascimento, string cpf)
        {
            DateTime.TryParse(nascimento, out DateTime date);
            Aluno aluno = new Aluno() { Matricula = matricula, Nome = nome, Sexo = sexo, Nascimento = Convert.ToDateTime(date), CPF = cpf};
            string expected = $"{matricula} | {nome} | {sexo} | {date} | {cpf}";

            Assert.Equal(expected, aluno.ToString());

        }

        [Theory]
        [InlineData(-1)]
        public void ValidaMatricula_InvalidMatriculaShouldFail(int matricula)
        {
            Assert.Throws<MatriculaInvalidaException>(() => new Aluno() { Matricula = matricula});
        }

        [Theory]
        [InlineData(1)]
        public void ValidaMatricula_ValidMatriculaShouldWork(int matricula)
        {
            Aluno aluno = new Aluno() { Matricula = matricula};

            bool actual = ValidaMatricula.EhValido(aluno.Matricula);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-13abc")]
        public void ValidaNome_InvalidNameShouldFail(string nome)
        {
            Assert.Throws<NomeInvalidoException>(() => new Aluno() { Nome = nome});
        }

        [Theory]
        [InlineData("Henrique")]
        public void ValidaNome_ValidNameShouldWork(string nome)
        {
            Aluno aluno = new Aluno() { Nome = nome };

            bool actual = ValidaNome.EhValido(aluno.Nome);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("19/13/2000")]
        [InlineData("01/01/3000")]
        public void ValidaNascimento_InvalidBirthShouldFail(string nascimento)
        {
            DateTime.TryParse(nascimento, out DateTime date);

            Assert.Throws<NascimentoInvalidoException>(() => new Aluno() { Nascimento = date });
        }

        [Theory]
        [InlineData("01/06/1990")]
        public void ValidaNascimento_ValidBirthShouldWork(string nascimento)
        {
            DateTime.TryParse(nascimento, out DateTime date);
            Aluno aluno = new Aluno() { Nascimento = date };

            bool actual = ValidaNascimento.EhValido(aluno.Nascimento);
            Assert.True(actual);
        }

        [Theory]
        [InlineData("11111111111")]
        [InlineData("12345678901")]
        [InlineData("32156")]
        [InlineData("abcdef12345")]
        public void ValidaCPF_InvalidCPFShouldFail(string cpf)
        {
            Assert.Throws<CPFInvalidoException>(() => new Aluno() { CPF = cpf });
        }

        [Theory]
        [InlineData("")]
        [InlineData("28825425007")]
        public void ValidaCPF_ValidCPFShouldWork(string cpf)
        {
            Aluno aluno = new Aluno() { CPF = cpf };

            bool actual = ValidaCPF.EhValido(aluno.CPF);
            Assert.True(actual);
        }

    }
}
