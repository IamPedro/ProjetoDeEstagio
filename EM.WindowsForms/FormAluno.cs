using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EM.Domain;
using EM.Repository;
using FirebirdSql.Data.FirebirdClient;

namespace EM.WindowsForms
{
    public partial class FormAluno : Form
    {
        private readonly RepositorioAluno _repositorio = new RepositorioAluno("CADASTROALUNOS");
        private Aluno _aluno = new Aluno();
        private DataTable _dtTable = new DataTable();

        public FormAluno()
        {
            InitializeComponent();
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            comboBoxSexo.SelectedIndex = 0;
            CriaColunasDataTable();

            try
            {
                PreencheGrid(_repositorio.GetAll());
            }
            catch (FbException exception)
            {
                MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void textBoxNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox) sender;

            if (!char.IsLetter(e.KeyChar) && (char)Keys.Back != e.KeyChar && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }

            if (char.IsWhiteSpace(e.KeyChar))
            {
                if (tb.SelectionStart == 0 || char.IsWhiteSpace(tb.Text[tb.TextLength - 1]))
                {
                    e.Handled = true;
                }
            }
        }

        private void textBoxCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar)
            {
                e.Handled = true;
            }
        }

        private void textBoxPesquisar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && (char)Keys.Back != e.KeyChar && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonLimparOuCancelar_Click(object sender, EventArgs e)
        {
            if (buttonLimparOuCancelar.Text.Equals("Cancelar"))
            {
                MessageBox.Show("Edição cancelada. Modo de edição foi desativado.", "Aluno modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AjustaComponentes("Novo aluno", "Limpar", "Adicionar", true);
            }
            LimpaComponentes();
        }

        private void buttonAdicionarOuModificar_Click(object sender, EventArgs e)
        {
            try
            {
                PreencheAluno();
                PersisteDados();
                PreencheGrid(_repositorio.GetAll());
                if (buttonAdicionarOuModificar.Text.Equals("Adicionar"))
                {
                    MessageBox.Show("Aluno adicionado com sucesso.", "Aluno adicionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (buttonAdicionarOuModificar.Text.Equals("Modificar"))
                {
                    MessageBox.Show("Aluno modificado com sucesso. Modo de edição foi desativado.", "Aluno modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AjustaComponentes("Novo aluno", "Limpar", "Adicionar", true);
                }
                LimpaComponentes();
            }
            catch (MatriculaInvalidaException exception)
            {
                MessageBox.Show(exception.Message, "Matrícula Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxMatricula.Focus();
            }
            catch (NomeInvalidoException exception)
            {
                MessageBox.Show(exception.Message, "Nome Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxNome.Focus();
            }
            catch (NascimentoInvalidoException exception)
            {
                MessageBox.Show(exception.Message, "Nascimento Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                maskedTextBoxNascimento.Focus();
            }
            catch (CPFInvalidoException exception)
            {
                MessageBox.Show(exception.Message, "CPF Inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCPF.Focus();
            }
            catch (FbException exception)
            {
                MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAluno.Rows.Count > 0)
            {
                if (buttonAdicionarOuModificar.Text.Equals("Adicionar"))
                {
                    MessageBox.Show("Modo de edição ativado. Aluno selecionado para edição. Caso queira editar outro aluno, selecione o aluno e clique no botão Editar para modificar seus dados.", "Modo de edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AjustaComponentes("Editando aluno", "Cancelar", "Modificar", false);
                }

                textBoxMatricula.Text = dataGridViewAluno.CurrentRow.Cells[0].Value.ToString();
                textBoxNome.Text = dataGridViewAluno.CurrentRow.Cells[1].Value.ToString();
                comboBoxSexo.SelectedIndex = (int) dataGridViewAluno.CurrentRow.Cells[2].Value;
                maskedTextBoxNascimento.Text = dataGridViewAluno.CurrentRow.Cells[3].Value.ToString();
                textBoxCPF.Text = dataGridViewAluno.CurrentRow.Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Edição inválida. Nenhum aluno selecionado", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            if (dataGridViewAluno.Rows.Count > 0)
            {
                _aluno = new Aluno()
                {
                    Matricula = (int)dataGridViewAluno.CurrentRow.Cells[0].Value,
                    Nome = dataGridViewAluno.CurrentRow.Cells[1].Value.ToString(),
                    Sexo = (EnumeradorSexo)dataGridViewAluno.CurrentRow.Cells[2].Value,
                    Nascimento = (DateTime)dataGridViewAluno.CurrentRow.Cells[3].Value,
                    CPF = dataGridViewAluno.CurrentRow.Cells[4].Value.ToString()
                };
            }
            else
            {
                MessageBox.Show("Exclusão inválida. Nenhum aluno selecionado.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Tem certeza que deseja excluir o aluno selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            try
            {
                switch (result)
                {
                    case DialogResult.Yes:
                        _repositorio.Remove(_aluno);
                        MessageBox.Show("Exclusão feita com sucesso!", "Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case DialogResult.No:
                        MessageBox.Show("Você não confirmou a exclusão!", "Mantido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }

                PreencheGrid(_repositorio.GetAll());
                LimpaComponentes();
            }
            catch (FbException exception)
            {
                MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonPesquisar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPesquisar.Text))
            {
                try
                {
                    PreencheGrid(_repositorio.GetAll());
                }
                catch (FbException exception)
                {
                    MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }

            bool numero = true;

            foreach (char caracter in textBoxPesquisar.Text)
            {
                if (!char.IsDigit(caracter))
                {
                    numero = false;
                }
            }

            if (numero)
            {              
                try
                {
                    Int32.TryParse(textBoxPesquisar.Text, out int matricula);
                    PreencheGrid(_repositorio.GetByMatricula(matricula));
                }
                catch (FbException exception)
                {
                    MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                   
            }
            else
            {
                try
                {
                    string parteNome = textBoxPesquisar.Text;
                    PreencheGrid(_repositorio.GetByContendoNoNome(parteNome));
                }
                catch (FbException exception)
                {
                    MessageBox.Show(exception.Message, "ERRO DATABASE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void PreencheAluno()
        {
            _aluno = new Aluno();
            if (buttonAdicionarOuModificar.Text.Equals("Adicionar"))
            {
                if(Int32.TryParse(textBoxMatricula.Text, out int matricula))
                {
                    _aluno.Matricula = matricula;
                }
                else
                {
                    throw new MatriculaInvalidaException("Matrícula precisa ser preenchida. Digite uma Matrícula válida.");
                }

            }
            else if (buttonAdicionarOuModificar.Text.Equals("Modificar"))
            {
                if (dataGridViewAluno.Rows.Count > 0)
                {
                    int matricula = (int)dataGridViewAluno.CurrentRow.Cells[0].Value;
                    _aluno.Matricula = matricula;
                }
                else
                {
                    throw new ApplicationException("Modificação inválida. Nenhum aluno selecionado.");
                }
            }

            _aluno.Nome = textBoxNome.Text;

            _aluno.Sexo = comboBoxSexo.Text.Equals("Masculino") ? EnumeradorSexo.Masculino : EnumeradorSexo.Feminino;

            DateTime.TryParse(maskedTextBoxNascimento.Text, out DateTime date);

            _aluno.Nascimento = date;

            _aluno.CPF = string.IsNullOrWhiteSpace(textBoxCPF.Text) ? null : textBoxCPF.Text;
        }

        private void PersisteDados()
        {
            if (buttonAdicionarOuModificar.Text.Equals("Adicionar"))
            {
                _repositorio.Add(_aluno);
            }
            else if (buttonAdicionarOuModificar.Text.Equals("Modificar"))
            {
                _repositorio.Update(_aluno);
            }
        }

        private void CriaColunasDataTable()
        {
            _dtTable.Columns.Add("Matricula", typeof(int));
            _dtTable.Columns.Add("Nome", typeof(string));
            _dtTable.Columns.Add("Sexo", typeof(EnumeradorSexo));
            _dtTable.Columns.Add("Nascimento", typeof(DateTime));
            _dtTable.Columns.Add("CPF", typeof(string));
        }

        private void PopulaDataTable(IEnumerable<Aluno> alunos)
        {
            _dtTable.Clear();
            foreach (Aluno aluno in alunos)
            {
                _dtTable.Rows.Add(aluno.Matricula, aluno.Nome, aluno.Sexo, aluno.Nascimento, aluno.CPF);
            }
        }

        private void PopulaDataTable(Aluno aluno)
        {
            _dtTable.Clear();
            if(aluno != null)
                _dtTable.Rows.Add(aluno.Matricula, aluno.Nome, aluno.Sexo, aluno.Nascimento, aluno.CPF);
        }

        private void PreencheGrid(IEnumerable<Aluno> alunos)
        {
            PopulaDataTable(alunos);
            bindingSourceAluno.DataSource = _dtTable;
            dataGridViewAluno.DataSource = bindingSourceAluno;
        }

        private void PreencheGrid(Aluno aluno)
        {
            PopulaDataTable(aluno);
            bindingSourceAluno.DataSource = _dtTable;
            dataGridViewAluno.DataSource = bindingSourceAluno;
        }

        private void AjustaComponentes(string tituloTela, string tituloBotaoEsquerda, string tituloBotaoDireita, bool estadoMatricula)
        {
            groupBoxAluno.Text = tituloTela;
            buttonLimparOuCancelar.Text = tituloBotaoEsquerda;
            buttonAdicionarOuModificar.Text = tituloBotaoDireita;
            textBoxMatricula.Enabled = estadoMatricula;
        }

        private void LimpaComponentes()
        {
            textBoxMatricula.Clear();
            textBoxNome.Clear();
            comboBoxSexo.SelectedIndex = 0;
            maskedTextBoxNascimento.Clear();
            textBoxCPF.Clear();
            textBoxMatricula.Focus();
        }
    }
}
