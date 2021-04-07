using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Domain;
using EM.Repository;
using Xunit;
using Xunit.Priority;

namespace EM.Repository.Testes
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class RepositorioTestes
    {
        private List<Aluno> _alunos;

        public RepositorioTestes()
        {
            _alunos = new List<Aluno>()
            {
                new Aluno() { Matricula = 0, Nome = "Pedro Henrique", Sexo = EnumeradorSexo.Masculino, Nascimento = Convert.ToDateTime("18/06/2000"), CPF = "83028348071"},
                new Aluno() { Matricula = 1, Nome = "Mateus Brito", Sexo = EnumeradorSexo.Masculino, Nascimento = Convert.ToDateTime("19/11/1999"), CPF = "94654506004"},
                new Aluno() { Matricula = 2, Nome = "Juliana", Sexo = EnumeradorSexo.Feminino, Nascimento = Convert.ToDateTime("04/04/1980"), CPF = "89140295060"},
            };
        }

        [Fact, Priority(1)]
        public void Add_AlunoShouldBeInsertInToDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");

            foreach (Aluno aluno in _alunos)
            {
                repositorio.Add(aluno);
            }

            List<Aluno> alunosRetornados = new List<Aluno>();

            foreach (Aluno aluno in _alunos)
            {
                alunosRetornados.Add(repositorio.GetByMatricula(aluno.Matricula));
            }

            foreach (var al in _alunos.Zip(alunosRetornados, (alu, aluRet) => new { aluno = alu, alunoRetornado = aluRet }))
            {
                Assert.NotNull(al.alunoRetornado);
                Assert.Equal(al.aluno.Matricula, al.alunoRetornado.Matricula);
            }
        }

        [Fact, Priority(2)]
        public void GetAll_AlunosShouldBeSelectFromDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");

            List<Aluno> alunosRetornados = new List<Aluno>();
            alunosRetornados = (List<Aluno>)repositorio.GetAll();

            foreach (var al in _alunos.Zip(alunosRetornados, (alu, aluRet) => new { aluno = alu, alunoRetornado = aluRet }))
            {
                Assert.NotNull(al.alunoRetornado);
                Assert.Equal(al.aluno.Matricula, al.alunoRetornado.Matricula);
            }
        }

        [Fact, Priority(3)]
        public void Get_AlunoShouldBeSelectFromDbByLINQ()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");
            List<Aluno> alunosRetornados = new List<Aluno>();

            alunosRetornados = (List<Aluno>)repositorio.Get(a => a.Sexo == EnumeradorSexo.Masculino);

            foreach (Aluno alunoRetornado in alunosRetornados)
            {
                Assert.NotNull(alunoRetornado);
                Assert.Equal(EnumeradorSexo.Masculino, alunoRetornado.Sexo);
            }
        }

        [Fact, Priority(4)]
        public void GetByMatricula_AlunoShouldBeSelectFromDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");
            Aluno alunoRetornado = new Aluno();

            alunoRetornado = repositorio.GetByMatricula(_alunos[0].Matricula);

            Assert.NotNull(alunoRetornado);
            Assert.Equal(_alunos[0].Matricula, alunoRetornado.Matricula);
        }

        [Fact, Priority(5)]
        public void GetByContendoNoNome_AlunoShouldBeSelectFromDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");
            List<Aluno> alunosRetornados = new List<Aluno>();

            alunosRetornados = (List<Aluno>)repositorio.GetByContendoNoNome("ri");

            foreach (Aluno alunoRetornado in alunosRetornados)
            {
                Assert.NotNull(alunoRetornado);
            }
        }

        [Fact, Priority(6)]
        public void Update_AlunoShouldBeUpdateInToDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");
            List<Aluno> alunosAtualizados = new List<Aluno>();
            alunosAtualizados = _alunos;

            foreach (Aluno aluno in alunosAtualizados)
            {
                aluno.Nome = "Jose";
                repositorio.Update(aluno);
            }

            List<Aluno> alunosRetornados = new List<Aluno>();

            foreach (Aluno aluno in alunosAtualizados)
            {
                alunosRetornados.Add(repositorio.GetByMatricula(aluno.Matricula));
            }

            foreach (var al in alunosAtualizados.Zip(alunosRetornados, (aluAtu, aluRet) => new { alunoAtualizado = aluAtu, alunoRetornado = aluRet }))
            {
                Assert.NotNull(al.alunoRetornado);
                Assert.Equal(al.alunoAtualizado.Matricula, al.alunoRetornado.Matricula);
                Assert.Equal(al.alunoAtualizado.Nome, al.alunoRetornado.Nome);
            }

        }
        
        [Fact, Priority(7)]
        public void Remove_AlunoShouldBeDeleteFromDB()
        {
            RepositorioAluno repositorio = new RepositorioAluno("TESTECADASTROALUNOS");

            foreach (Aluno aluno in _alunos)
            {
                repositorio.Remove(aluno);
            }

            List<Aluno> alunosRetornados = new List<Aluno>();

            foreach (Aluno aluno in _alunos)
            {
                alunosRetornados.Add(repositorio.GetByMatricula(aluno.Matricula));
            }

            foreach (var al in _alunos.Zip(alunosRetornados, (alu, aluRet) => new { aluno = alu, alunoRetornado = aluRet }))
            {
                Assert.Null(al.alunoRetornado);
            }
        
        }

    }
}
