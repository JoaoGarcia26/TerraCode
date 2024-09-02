namespace TerraCode.View
{
    partial class ScreenMotorista
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenMotorista));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.usuariosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbTerraCodeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbTerraCodeDataSet = new TerraCode.dbTerraCodeDataSet();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnAddMotorista = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.usuariosTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.UsuariosTableAdapter();
            this.motoristaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.motoristaTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter();
            this.veiculoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.veiculoTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(49, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(949, 334);
            this.dataGridView1.TabIndex = 3;
            // 
            // usuariosBindingSource
            // 
            this.usuariosBindingSource.DataMember = "Usuarios";
            this.usuariosBindingSource.DataSource = this.dbTerraCodeDataSetBindingSource;
            // 
            // dbTerraCodeDataSetBindingSource
            // 
            this.dbTerraCodeDataSetBindingSource.DataSource = this.dbTerraCodeDataSet;
            this.dbTerraCodeDataSetBindingSource.Position = 0;
            // 
            // dbTerraCodeDataSet
            // 
            this.dbTerraCodeDataSet.DataSetName = "dbTerraCodeDataSet";
            this.dbTerraCodeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnAddMotorista
            // 
            this.btnAddMotorista.Location = new System.Drawing.Point(884, 375);
            this.btnAddMotorista.Name = "btnAddMotorista";
            this.btnAddMotorista.Size = new System.Drawing.Size(114, 52);
            this.btnAddMotorista.TabIndex = 5;
            this.btnAddMotorista.Text = "Cadastrar Motorista";
            this.btnAddMotorista.UseVisualStyleBackColor = true;
            this.btnAddMotorista.Click += new System.EventHandler(this.btnAddMotorista_Click);
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
            // usuariosTableAdapter
            // 
            this.usuariosTableAdapter.ClearBeforeFill = true;
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
            // veiculoBindingSource
            // 
            this.veiculoBindingSource.DataMember = "Veiculo";
            this.veiculoBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // veiculoTableAdapter
            // 
            this.veiculoTableAdapter.ClearBeforeFill = true;
            // 
            // ScreenMotorista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddMotorista);
            this.Controls.Add(this.btnVoltar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenMotorista";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Motoristas | TerraCode";
            this.Activated += new System.EventHandler(this.ScreenMotorista_Activated);
            this.Load += new System.EventHandler(this.ScreenMotorista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuariosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.veiculoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource usuariosBindingSource;
        private System.Windows.Forms.BindingSource dbTerraCodeDataSetBindingSource;
        private dbTerraCodeDataSet dbTerraCodeDataSet;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private dbTerraCodeDataSetTableAdapters.UsuariosTableAdapter usuariosTableAdapter;
        private System.Windows.Forms.Button btnAddMotorista;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.BindingSource motoristaBindingSource;
        private dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter motoristaTableAdapter;
        private System.Windows.Forms.BindingSource veiculoBindingSource;
        private dbTerraCodeDataSetTableAdapters.VeiculoTableAdapter veiculoTableAdapter;
    }
}