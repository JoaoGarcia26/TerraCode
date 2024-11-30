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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCaixas));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dataGridViewMovimentacaoCaixas = new System.Windows.Forms.DataGridView();
            this.btnRegMovimentacao = new System.Windows.Forms.Button();
            this.dbTerraCodeDataSet = new TerraCode.dbTerraCodeDataSet();
            this.fazendasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.FazendasTableAdapter();
            this.pLsTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.PLsTableAdapter();
            this.movimentacaoCaixasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MovimentacaoCaixasTableAdapter();
            this.veiculoTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter();
            this.motoristaTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMovimentacaoCaixas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).BeginInit();
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
            this.dataGridViewMovimentacaoCaixas.Size = new System.Drawing.Size(992, 334);
            this.dataGridViewMovimentacaoCaixas.TabIndex = 8;
            this.dataGridViewMovimentacaoCaixas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewMovimentacaoCaixas_CellContentClick);
            // 
            // btnRegMovimentacao
            // 
            this.btnRegMovimentacao.Location = new System.Drawing.Point(905, 366);
            this.btnRegMovimentacao.Name = "btnRegMovimentacao";
            this.btnRegMovimentacao.Size = new System.Drawing.Size(136, 52);
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
            // fazendasTableAdapter
            // 
            this.fazendasTableAdapter.ClearBeforeFill = true;
            // 
            // pLsTableAdapter
            // 
            this.pLsTableAdapter.ClearBeforeFill = true;
            // 
            // movimentacaoCaixasTableAdapter
            // 
            this.movimentacaoCaixasTableAdapter.ClearBeforeFill = true;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // motoristaTableAdapter
            // 
            this.motoristaTableAdapter.ClearBeforeFill = true;
            // 
            // ScreenCaixas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 435);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dataGridViewMovimentacaoCaixas;
        private dbTerraCodeDataSet dbTerraCodeDataSet;
        private dbTerraCodeDataSetTableAdapters.FazendasTableAdapter fazendasTableAdapter;
        private dbTerraCodeDataSetTableAdapters.PLsTableAdapter pLsTableAdapter;
        private System.Windows.Forms.Button btnRegMovimentacao;
        private dbTerraCodeDataSetTableAdapters.MovimentacaoCaixasTableAdapter movimentacaoCaixasTableAdapter;
        private dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter veiculoTableAdapter;
        private dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter motoristaTableAdapter;
    }
}