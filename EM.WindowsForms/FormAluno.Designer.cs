
namespace EM.WindowsForms
{
    partial class FormAluno
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxAluno = new System.Windows.Forms.GroupBox();
            this.buttonAdicionarOuModificar = new System.Windows.Forms.Button();
            this.buttonLimparOuCancelar = new System.Windows.Forms.Button();
            this.textBoxCPF = new System.Windows.Forms.TextBox();
            this.labelCPF = new System.Windows.Forms.Label();
            this.maskedTextBoxNascimento = new System.Windows.Forms.MaskedTextBox();
            this.labelNascimento = new System.Windows.Forms.Label();
            this.comboBoxSexo = new System.Windows.Forms.ComboBox();
            this.labelSexo = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxMatricula = new System.Windows.Forms.TextBox();
            this.labelMatricula = new System.Windows.Forms.Label();
            this.textBoxPesquisar = new System.Windows.Forms.TextBox();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.dataGridViewAluno = new System.Windows.Forms.DataGridView();
            this.matriculaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sexoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nascimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPFDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceAluno = new System.Windows.Forms.BindingSource(this.components);
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.groupBoxAluno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAluno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAluno)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAluno
            // 
            this.groupBoxAluno.Controls.Add(this.buttonAdicionarOuModificar);
            this.groupBoxAluno.Controls.Add(this.buttonLimparOuCancelar);
            this.groupBoxAluno.Controls.Add(this.textBoxCPF);
            this.groupBoxAluno.Controls.Add(this.labelCPF);
            this.groupBoxAluno.Controls.Add(this.maskedTextBoxNascimento);
            this.groupBoxAluno.Controls.Add(this.labelNascimento);
            this.groupBoxAluno.Controls.Add(this.comboBoxSexo);
            this.groupBoxAluno.Controls.Add(this.labelSexo);
            this.groupBoxAluno.Controls.Add(this.textBoxNome);
            this.groupBoxAluno.Controls.Add(this.labelNome);
            this.groupBoxAluno.Controls.Add(this.textBoxMatricula);
            this.groupBoxAluno.Controls.Add(this.labelMatricula);
            this.groupBoxAluno.Location = new System.Drawing.Point(12, 13);
            this.groupBoxAluno.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBoxAluno.Name = "groupBoxAluno";
            this.groupBoxAluno.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBoxAluno.Size = new System.Drawing.Size(776, 204);
            this.groupBoxAluno.TabIndex = 0;
            this.groupBoxAluno.TabStop = false;
            this.groupBoxAluno.Text = "Novo Aluno";
            // 
            // buttonAdicionarOuModificar
            // 
            this.buttonAdicionarOuModificar.Location = new System.Drawing.Point(650, 129);
            this.buttonAdicionarOuModificar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonAdicionarOuModificar.Name = "buttonAdicionarOuModificar";
            this.buttonAdicionarOuModificar.Size = new System.Drawing.Size(119, 26);
            this.buttonAdicionarOuModificar.TabIndex = 11;
            this.buttonAdicionarOuModificar.Text = "Adicionar";
            this.buttonAdicionarOuModificar.UseVisualStyleBackColor = true;
            this.buttonAdicionarOuModificar.Click += new System.EventHandler(this.buttonAdicionarOuModificar_Click);
            // 
            // buttonLimparOuCancelar
            // 
            this.buttonLimparOuCancelar.Location = new System.Drawing.Point(526, 129);
            this.buttonLimparOuCancelar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonLimparOuCancelar.Name = "buttonLimparOuCancelar";
            this.buttonLimparOuCancelar.Size = new System.Drawing.Size(119, 26);
            this.buttonLimparOuCancelar.TabIndex = 10;
            this.buttonLimparOuCancelar.Text = "Limpar";
            this.buttonLimparOuCancelar.UseVisualStyleBackColor = true;
            this.buttonLimparOuCancelar.Click += new System.EventHandler(this.buttonLimparOuCancelar_Click);
            // 
            // textBoxCPF
            // 
            this.textBoxCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCPF.Location = new System.Drawing.Point(275, 129);
            this.textBoxCPF.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxCPF.MaxLength = 11;
            this.textBoxCPF.Name = "textBoxCPF";
            this.textBoxCPF.Size = new System.Drawing.Size(162, 26);
            this.textBoxCPF.TabIndex = 9;
            this.textBoxCPF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCPF_KeyPress);
            // 
            // labelCPF
            // 
            this.labelCPF.AutoSize = true;
            this.labelCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCPF.Location = new System.Drawing.Point(272, 113);
            this.labelCPF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCPF.Name = "labelCPF";
            this.labelCPF.Size = new System.Drawing.Size(34, 16);
            this.labelCPF.TabIndex = 8;
            this.labelCPF.Text = "CPF";
            // 
            // maskedTextBoxNascimento
            // 
            this.maskedTextBoxNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxNascimento.Location = new System.Drawing.Point(146, 129);
            this.maskedTextBoxNascimento.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.maskedTextBoxNascimento.Mask = "00/00/0000";
            this.maskedTextBoxNascimento.Name = "maskedTextBoxNascimento";
            this.maskedTextBoxNascimento.Size = new System.Drawing.Size(123, 26);
            this.maskedTextBoxNascimento.TabIndex = 7;
            this.maskedTextBoxNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // labelNascimento
            // 
            this.labelNascimento.AutoSize = true;
            this.labelNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNascimento.Location = new System.Drawing.Point(143, 113);
            this.labelNascimento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNascimento.Name = "labelNascimento";
            this.labelNascimento.Size = new System.Drawing.Size(80, 16);
            this.labelNascimento.TabIndex = 6;
            this.labelNascimento.Text = "Nascimento";
            // 
            // comboBoxSexo
            // 
            this.comboBoxSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSexo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxSexo.FormattingEnabled = true;
            this.comboBoxSexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino"});
            this.comboBoxSexo.Location = new System.Drawing.Point(19, 129);
            this.comboBoxSexo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBoxSexo.Name = "comboBoxSexo";
            this.comboBoxSexo.Size = new System.Drawing.Size(120, 26);
            this.comboBoxSexo.TabIndex = 5;
            // 
            // labelSexo
            // 
            this.labelSexo.AutoSize = true;
            this.labelSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSexo.Location = new System.Drawing.Point(16, 113);
            this.labelSexo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSexo.Name = "labelSexo";
            this.labelSexo.Size = new System.Drawing.Size(39, 16);
            this.labelSexo.TabIndex = 4;
            this.labelSexo.Text = "Sexo";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNome.Location = new System.Drawing.Point(146, 50);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxNome.MaxLength = 100;
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(623, 26);
            this.textBoxNome.TabIndex = 3;
            this.textBoxNome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNome_KeyPress);
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(143, 31);
            this.labelNome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(45, 16);
            this.labelNome.TabIndex = 2;
            this.labelNome.Text = "Nome";
            // 
            // textBoxMatricula
            // 
            this.textBoxMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMatricula.Location = new System.Drawing.Point(19, 50);
            this.textBoxMatricula.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxMatricula.MaxLength = 9;
            this.textBoxMatricula.Name = "textBoxMatricula";
            this.textBoxMatricula.Size = new System.Drawing.Size(120, 26);
            this.textBoxMatricula.TabIndex = 1;
            this.textBoxMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMatricula_KeyPress);
            // 
            // labelMatricula
            // 
            this.labelMatricula.AutoSize = true;
            this.labelMatricula.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMatricula.Location = new System.Drawing.Point(16, 31);
            this.labelMatricula.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMatricula.Name = "labelMatricula";
            this.labelMatricula.Size = new System.Drawing.Size(62, 16);
            this.labelMatricula.TabIndex = 0;
            this.labelMatricula.Text = "Matricula";
            // 
            // textBoxPesquisar
            // 
            this.textBoxPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPesquisar.Location = new System.Drawing.Point(12, 232);
            this.textBoxPesquisar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxPesquisar.MaxLength = 100;
            this.textBoxPesquisar.Name = "textBoxPesquisar";
            this.textBoxPesquisar.Size = new System.Drawing.Size(651, 26);
            this.textBoxPesquisar.TabIndex = 12;
            this.textBoxPesquisar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPesquisar_KeyPress);
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(668, 232);
            this.buttonPesquisar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(119, 26);
            this.buttonPesquisar.TabIndex = 13;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // dataGridViewAluno
            // 
            this.dataGridViewAluno.AllowUserToAddRows = false;
            this.dataGridViewAluno.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewAluno.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAluno.AutoGenerateColumns = false;
            this.dataGridViewAluno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAluno.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matriculaDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.sexoDataGridViewTextBoxColumn,
            this.nascimentoDataGridViewTextBoxColumn,
            this.cPFDataGridViewTextBoxColumn});
            this.dataGridViewAluno.DataSource = this.bindingSourceAluno;
            this.dataGridViewAluno.Location = new System.Drawing.Point(12, 264);
            this.dataGridViewAluno.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridViewAluno.MultiSelect = false;
            this.dataGridViewAluno.Name = "dataGridViewAluno";
            this.dataGridViewAluno.ReadOnly = true;
            this.dataGridViewAluno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAluno.Size = new System.Drawing.Size(776, 135);
            this.dataGridViewAluno.TabIndex = 14;
            // 
            // matriculaDataGridViewTextBoxColumn
            // 
            this.matriculaDataGridViewTextBoxColumn.DataPropertyName = "Matricula";
            this.matriculaDataGridViewTextBoxColumn.HeaderText = "Matricula";
            this.matriculaDataGridViewTextBoxColumn.Name = "matriculaDataGridViewTextBoxColumn";
            this.matriculaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sexoDataGridViewTextBoxColumn
            // 
            this.sexoDataGridViewTextBoxColumn.DataPropertyName = "Sexo";
            this.sexoDataGridViewTextBoxColumn.HeaderText = "Sexo";
            this.sexoDataGridViewTextBoxColumn.Name = "sexoDataGridViewTextBoxColumn";
            this.sexoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nascimentoDataGridViewTextBoxColumn
            // 
            this.nascimentoDataGridViewTextBoxColumn.DataPropertyName = "Nascimento";
            this.nascimentoDataGridViewTextBoxColumn.HeaderText = "Nascimento";
            this.nascimentoDataGridViewTextBoxColumn.Name = "nascimentoDataGridViewTextBoxColumn";
            this.nascimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cPFDataGridViewTextBoxColumn
            // 
            this.cPFDataGridViewTextBoxColumn.DataPropertyName = "CPF";
            this.cPFDataGridViewTextBoxColumn.HeaderText = "CPF";
            this.cPFDataGridViewTextBoxColumn.Name = "cPFDataGridViewTextBoxColumn";
            this.cPFDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSourceAluno
            // 
            this.bindingSourceAluno.DataSource = typeof(EM.Domain.Aluno);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(538, 412);
            this.buttonEditar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(119, 26);
            this.buttonEditar.TabIndex = 15;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(668, 412);
            this.buttonExcluir.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(119, 26);
            this.buttonExcluir.TabIndex = 16;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // FormAluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.dataGridViewAluno);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.textBoxPesquisar);
            this.Controls.Add(this.groupBoxAluno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAluno";
            this.Text = "Cadastro de Alunos";
            this.Load += new System.EventHandler(this.FormAluno_Load);
            this.groupBoxAluno.ResumeLayout(false);
            this.groupBoxAluno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAluno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAluno;
        private System.Windows.Forms.Label labelMatricula;
        private System.Windows.Forms.TextBox textBoxMatricula;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelSexo;
        private System.Windows.Forms.ComboBox comboBoxSexo;
        private System.Windows.Forms.Label labelNascimento;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNascimento;
        private System.Windows.Forms.Label labelCPF;
        private System.Windows.Forms.TextBox textBoxCPF;
        private System.Windows.Forms.Button buttonLimparOuCancelar;
        private System.Windows.Forms.Button buttonAdicionarOuModificar;
        private System.Windows.Forms.TextBox textBoxPesquisar;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.DataGridView dataGridViewAluno;
        private System.Windows.Forms.BindingSource bindingSourceAluno;
        private System.Windows.Forms.DataGridViewTextBoxColumn matriculaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sexoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nascimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPFDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonEditar;
        private System.Windows.Forms.Button buttonExcluir;
    }
}

