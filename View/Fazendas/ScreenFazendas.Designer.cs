namespace TerraCode.View
{
    partial class ScreenFazendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenFazendas));
            this.btnAddFazenda = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dbTerraCodeDataSet = new TerraCode.dbTerraCodeDataSet();
            this.fazendasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fazendasTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.FazendasTableAdapter();
            this.fazendasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pLsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pLsTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.PLsTableAdapter();
            this.btnPL = new System.Windows.Forms.Button();
            this.btnListarPls = new System.Windows.Forms.Button();
            this.btnSafra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddFazenda
            // 
            this.btnAddFazenda.Location = new System.Drawing.Point(480, 375);
            this.btnAddFazenda.Name = "btnAddFazenda";
            this.btnAddFazenda.Size = new System.Drawing.Size(114, 52);
            this.btnAddFazenda.TabIndex = 5;
            this.btnAddFazenda.Text = "Cadastrar Nova Fazenda";
            this.btnAddFazenda.UseVisualStyleBackColor = true;
            this.btnAddFazenda.Click += new System.EventHandler(this.btnAddFazenda_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(49, 375);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 52);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(702, 334);
            this.dataGridView1.TabIndex = 3;
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
            // btnPL
            // 
            this.btnPL.Location = new System.Drawing.Point(637, 375);
            this.btnPL.Name = "btnPL";
            this.btnPL.Size = new System.Drawing.Size(114, 52);
            this.btnPL.TabIndex = 6;
            this.btnPL.Text = "Cadastrar Novo PL";
            this.btnPL.UseVisualStyleBackColor = true;
            this.btnPL.Click += new System.EventHandler(this.btnPL_Click);
            // 
            // btnListarPls
            // 
            this.btnListarPls.Location = new System.Drawing.Point(202, 375);
            this.btnListarPls.Name = "btnListarPls";
            this.btnListarPls.Size = new System.Drawing.Size(114, 52);
            this.btnListarPls.TabIndex = 7;
            this.btnListarPls.Text = "Listar todos PL\'s";
            this.btnListarPls.UseVisualStyleBackColor = true;
            this.btnListarPls.Click += new System.EventHandler(this.btnListarPls_Click);
            // 
            // btnSafra
            // 
            this.btnSafra.Location = new System.Drawing.Point(340, 375);
            this.btnSafra.Name = "btnSafra";
            this.btnSafra.Size = new System.Drawing.Size(114, 52);
            this.btnSafra.TabIndex = 8;
            this.btnSafra.Text = "Cadastrar Safra";
            this.btnSafra.UseVisualStyleBackColor = true;
            this.btnSafra.Click += new System.EventHandler(this.btnSafra_Click);
            // 
            // ScreenFazendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSafra);
            this.Controls.Add(this.btnListarPls);
            this.Controls.Add(this.btnPL);
            this.Controls.Add(this.btnAddFazenda);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenFazendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fazendas | TerraCode";
            this.Activated += new System.EventHandler(this.ScreenFazendas_Activated);
            this.Load += new System.EventHandler(this.Fazendas_Load);
            this.VisibleChanged += new System.EventHandler(this.ScreenFazendas_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fazendasBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pLsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddFazenda;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private dbTerraCodeDataSet dbTerraCodeDataSet;
        private System.Windows.Forms.BindingSource fazendasBindingSource;
        private dbTerraCodeDataSetTableAdapters.FazendasTableAdapter fazendasTableAdapter;
        private System.Windows.Forms.BindingSource fazendasBindingSource1;
        private System.Windows.Forms.BindingSource pLsBindingSource;
        private dbTerraCodeDataSetTableAdapters.PLsTableAdapter pLsTableAdapter;
        private System.Windows.Forms.Button btnPL;
        private System.Windows.Forms.Button btnListarPls;
        private System.Windows.Forms.Button btnSafra;
    }
}