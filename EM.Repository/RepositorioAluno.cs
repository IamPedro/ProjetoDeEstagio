using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EM.Domain;
using FirebirdSql.Data.FirebirdClient;

namespace EM.Repository
{
    public class RepositorioAluno : RepositorioAbstrato<Aluno>
    {
        public string StringConexao { get; private set;}

        public RepositorioAluno(string bancoDeDados)
        {
            StringConexao = $@"Database=C:\Users\pedro\source\repos\BancoDeDados\{bancoDeDados}.FDB;
                               DataSource = localhost;
                               UserID = SYSDBA;
                               Password = masterkey; ";
        }

        public override void Add(Aluno aluno)
        {
            if (GetByMatricula(aluno.Matricula) != null)
            {
                throw new MatriculaInvalidaException("Matricula já está sendo usada por outro aluno. Digite uma Matrícula válida.");
            }

            if (Get(a => a.CPF == aluno.CPF).FirstOrDefault() != null)
            {
                throw new CPFInvalidoException("CPF já está sendo usado por outro aluno. Digite um CPF válido.");
            }

            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            const string comando = @"INSERT INTO ALUNOS (MATRICULA, NOME, SEXO, NASCIMENTO, CPF)
                                   VALUES (@matricula, @nome, @sexo, @nascimento, @cpf)";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;

            fbCmd.Parameters.AddWithValue("@matricula", aluno.Matricula);
            fbCmd.Parameters.AddWithValue("@nome", aluno.Nome);
            fbCmd.Parameters.AddWithValue("@sexo", (int)aluno.Sexo);
            fbCmd.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
            fbCmd.Parameters.AddWithValue("@cpf", aluno.CPF);
            fbCmd.ExecuteNonQuery();
        }

        public override void Remove(Aluno aluno)
        {
            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            var comando = $@"DELETE FROM ALUNOS WHERE MATRICULA = {aluno.Matricula}";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;

            fbCmd.ExecuteNonQuery();
        }

        public override void Update(Aluno aluno)
        {
            if (Get(a => a.CPF == aluno.CPF && a.Matricula != aluno.Matricula).FirstOrDefault() != null)
            {
                throw new CPFInvalidoException("CPF já está sendo usado por outro aluno. Digite um CPF válido.");
            }

            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            var comando = $@"UPDATE ALUNOS 
                                   SET 
                                   NOME = @nome, 
                                   SEXO = @sexo, 
                                   NASCIMENTO = @nascimento, 
                                   CPF = @cpf
                                   WHERE MATRICULA = {aluno.Matricula}";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;
            
            fbCmd.Parameters.AddWithValue("@nome", aluno.Nome);
            fbCmd.Parameters.AddWithValue("@sexo", (int)aluno.Sexo);
            fbCmd.Parameters.AddWithValue("@nascimento", aluno.Nascimento);
            fbCmd.Parameters.AddWithValue("@cpf", aluno.CPF);

            fbCmd.ExecuteNonQuery();
        }

        public override IEnumerable<Aluno> GetAll()
        {
            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            var comando = @"SELECT * FROM ALUNOS";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;

            using var fbDtAd = new FbDataAdapter(fbCmd);
            var dtble = new DataTable();
            fbDtAd.Fill(dtble);

            List<Aluno> alunos = new List<Aluno>();

            for (var i = 0; i < dtble.Rows.Count; i++)
            {
                var aluno = new Aluno()
                {
                    Matricula = (int)dtble.Rows[i][0],
                    Nome = dtble.Rows[i][1].ToString(),
                    Sexo = (EnumeradorSexo)dtble.Rows[i][2],
                    Nascimento = (DateTime)dtble.Rows[i][3],
                    CPF = dtble.Rows[i][4].ToString()
                };
                alunos.Add(aluno);
            }

            return alunos;
        }

        public override IEnumerable<Aluno> Get(Expression<Func<Aluno, bool>> predicate)
        {
            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();
            var alunos = (List<Aluno>) GetAll();

            return alunos.AsQueryable().Where(predicate).ToList();
        }

        public Aluno GetByMatricula(int matricula)
        {
            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            var comando = $@"SELECT * FROM ALUNOS WHERE MATRICULA = {matricula}";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;

            using var fbDtAd = new FbDataAdapter(fbCmd);
            var dtble = new DataTable();
            fbDtAd.Fill(dtble);

            return (dtble.Rows.Count > 0) ? new Aluno()
            {
                Matricula = (int)dtble.Rows[0][0],
                Nome = dtble.Rows[0][1].ToString(),
                Sexo = (EnumeradorSexo)dtble.Rows[0][2],
                Nascimento = (DateTime)dtble.Rows[0][3],
                CPF = dtble.Rows[0][4].ToString()
            } : null;
        }

        public IEnumerable<Aluno> GetByContendoNoNome(string parteDoNome)
        {
            using var fbConexao = new FbConnection(StringConexao);
            fbConexao.Open();

            var comando = $@"SELECT * FROM ALUNOS WHERE UPPER(NOME) LIKE UPPER('%{parteDoNome}%')";
            using var fbCmd = fbConexao.CreateCommand();
            fbCmd.CommandText = comando;

            using var fbDtAd = new FbDataAdapter(fbCmd);
            var dtble = new DataTable();
            fbDtAd.Fill(dtble);

            List<Aluno> alunos = new List<Aluno>();

            for (var i = 0; i < dtble.Rows.Count; i++)
            {
                var aluno = new Aluno()
                {
                    Matricula = (int)dtble.Rows[i][0],
                    Nome = dtble.Rows[i][1].ToString(),
                    Sexo = (EnumeradorSexo)dtble.Rows[i][2],
                    Nascimento = (DateTime)dtble.Rows[i][3],
                    CPF = dtble.Rows[i][4].ToString()
                };
                alunos.Add(aluno);
            }

            return alunos;
        }

    }

}
