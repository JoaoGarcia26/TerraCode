namespace TerraCode.View
{
    partial class ScreenCaixas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCaixas));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dataGridViewMovimentacaoCaixas = new System.Windows.Forms.DataGridView();
            this.btnRegMovimentacao = new System.Windows.Forms.Button();
            this.dbTerraCodeDataSet = new TerraCode.dbTerraCodeDataSet();
            this.fazendasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fazendasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.FazendasTableAdapter();
            this.fazendasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pLsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pLsTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.PLsTableAdapter();
            this.movimentacaoCaixasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.movimentacaoCaixasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MovimentacaoCaixasTableAdapter();
            this.caixasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.caixasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.CaixasTableAdapter();
            this.dbTerraCodeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter();
            this.motoristaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.motoristaTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimentacaoCaixas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoCaixasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caixasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(49, 366);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 52);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dataGridViewMovimentacaoCaixas
            // 
            this.dataGridViewMovimentacaoCaixas.AllowUserToAddRows = false;
            this.dataGridViewMovimentacaoCaixas.AllowUserToDeleteRows = false;
            this.dataGridViewMovimentacaoCaixas.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewMovimentacaoCaixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovimentacaoCaixas.Location = new System.Drawing.Point(49, 12);
            this.dataGridViewMovimentacaoCaixas.Name = "dataGridViewMovimentacaoCaixas";
            this.dataGridViewMovimentacaoCaixas.ReadOnly = true;
            this.dataGridViewMovimentacaoCaixas.RowHeadersWidth = 51;
            this.dataGridViewMovimentacaoCaixas.RowTemplate.Height = 24;
            this.dataGridViewMovimentacaoCaixas.Size = new System.Drawing.Size(959, 334);
            this.dataGridViewMovimentacaoCaixas.TabIndex = 8;
            // 
            // btnRegMovimentacao
            // 
            this.btnRegMovimentacao.Location = new System.Drawing.Point(884, 366);
            this.btnRegMovimentacao.Name = "btnRegMovimentacao";
            this.btnRegMovimentacao.Size = new System.Drawing.Size(114, 52);
            this.btnRegMovimentacao.TabIndex = 2;
            this.btnRegMovimentacao.Text = "Registrar Saída";
            this.btnRegMovimentacao.UseVisualStyleBackColor = true;
            this.btnRegMovimentacao.Click += new System.EventHandler(this.btnRegMovimentacao_Click);
            // 
            // dbTerraCodeDataSet
            // 
            this.dbTerraCodeDataSet.DataSetName = "dbTerraCodeDataSet";
            this.dbTerraCodeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fazendasBindingSource
            // 
            this.fazendasBindingSource.DataMember = "Fazendas";
            this.fazendasBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // fazendasTableAdapter
            // 
            this.fazendasTableAdapter.ClearBeforeFill = true;
            // 
            // fazendasBindingSource1
            // 
            this.fazendasBindingSource1.DataMember = "Fazendas";
            this.fazendasBindingSource1.DataSource = this.dbTerraCodeDataSet;
            // 
            // pLsBindingSource
            // 
            this.pLsBindingSource.DataMember = "PLs";
            this.pLsBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // pLsTableAdapter
            // 
            this.pLsTableAdapter.ClearBeforeFill = true;
            // 
            // movimentacaoCaixasBindingSource
            // 
            this.movimentacaoCaixasBindingSource.DataMember = "MovimentacaoCaixas";
            this.movimentacaoCaixasBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // movimentacaoCaixasTableAdapter
            // 
            this.movimentacaoCaixasTableAdapter.ClearBeforeFill = true;
            // 
            // caixasBindingSource
            // 
            this.caixasBindingSource.DataMember = "Caixas";
            this.caixasBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // caixasTableAdapter
            // 
            this.caixasTableAdapter.ClearBeforeFill = true;
            // 
            // dbTerraCodeDataSetBindingSource
            // 
            this.dbTerraCodeDataSetBindingSource.DataSource = this.dbTerraCodeDataSet;
            this.dbTerraCodeDataSetBindingSource.Position = 0;
            // 
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataMember = "Veiculo";
            this.veiculoBindingSource.DataSource = this.dbTerraCodeDataSetBindingSource;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // motoristaBindingSource
            // 
            this.motoristaBindingSource.DataMember = "Motorista";
            this.motoristaBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // motoristaTableAdapter
            // 
            this.motoristaTableAdapter.ClearBeforeFill = true;
            // 
            // ScreenCaixas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 435);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dataGridViewMovimentacaoCaixas);
            this.Controls.Add(this.btnRegMovimentacao);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenCaixas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caixas | Registro de Movimentações | TerraCode";
            this.Activated += new System.EventHandler(this.ScreenCaixas_Activated);
            this.Load += new System.EventHandler(this.ScreenCaixas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimentacaoCaixas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoCaixasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caixasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dataGridViewMovimentacaoCaixas;
        private dbTerraCodeDataSet dbTerraCodeDataSet;
        private System.Windows.Forms.BindingSource fazendasBindingSource;
        private dbTerraCodeDataSetTableAdapters.FazendasTableAdapter fazendasTableAdapter;
        private System.Windows.Forms.BindingSource fazendasBindingSource1;
        private System.Windows.Forms.BindingSource pLsBindingSource;
        private dbTerraCodeDataSetTableAdapters.PLsTableAdapter pLsTableAdapter;
        private System.Windows.Forms.Button btnRegMovimentacao;
        private System.Windows.Forms.BindingSource movimentacaoCaixasBindingSource;
        private dbTerraCodeDataSetTableAdapters.MovimentacaoCaixasTableAdapter movimentacaoCaixasTableAdapter;
        private System.Windows.Forms.BindingSource caixasBindingSource;
        private dbTerraCodeDataSetTableAdapters.CaixasTableAdapter caixasTableAdapter;
        private System.Windows.Forms.BindingSource dbTerraCodeDataSetBindingSource;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private System.Windows.Forms.BindingSource motoristaBindingSource;
        private dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter motoristaTableAdapter;
    }
}