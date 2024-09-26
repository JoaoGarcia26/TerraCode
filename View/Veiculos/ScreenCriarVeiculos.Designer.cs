namespace TerraCode.View
{
    partial class ScreenCriarVeiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCriarVeiculos));
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAddVeiculo = new System.Windows.Forms.Button();
            this.comboMotorista = new System.Windows.Forms.ComboBox();
            this.motoristaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbTerraCodeDataSet = new TerraCode.dbTerraCodeDataSet();
            this.comboTipoVeiculo = new System.Windows.Forms.ComboBox();
            this.motoristaTableAdapter = new TerraCode.dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 33;
            this.label4.Text = "Placa:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaca.Location = new System.Drawing.Point(49, 175);
            this.txtPlaca.MaxLength = 7;
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(245, 26);
            this.txtPlaca.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 32;
            this.label2.Text = "Tipo do Veículo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Motorista:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(363, 156);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 45);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnAddVeiculo
            // 
            this.btnAddVeiculo.Location = new System.Drawing.Point(363, 50);
            this.btnAddVeiculo.Name = "btnAddVeiculo";
            this.btnAddVeiculo.Size = new System.Drawing.Size(114, 62);
            this.btnAddVeiculo.TabIndex = 4;
            this.btnAddVeiculo.Text = "Cadastrar Veículo";
            this.btnAddVeiculo.UseVisualStyleBackColor = true;
            this.btnAddVeiculo.Click += new System.EventHandler(this.btnAddVeiculo_Click);
            // 
            // comboMotorista
            // 
            this.comboMotorista.DataSource = this.motoristaBindingSource;
            this.comboMotorista.DisplayMember = "Nome";
            this.comboMotorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMotorista.FormattingEnabled = true;
            this.comboMotorista.Location = new System.Drawing.Point(49, 50);
            this.comboMotorista.Name = "comboMotorista";
            this.comboMotorista.Size = new System.Drawing.Size(245, 28);
            this.comboMotorista.TabIndex = 1;
            // 
            // motoristaBindingSource
            // 
            this.motoristaBindingSource.DataMember = "Motorista";
            this.motoristaBindingSource.DataSource = this.dbTerraCodeDataSet;
            // 
            // dbTerraCodeDataSet
            // 
            this.dbTerraCodeDataSet.DataSetName = "dbTerraCodeDataSet";
            this.dbTerraCodeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboTipoVeiculo
            // 
            this.comboTipoVeiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoVeiculo.FormattingEnabled = true;
            this.comboTipoVeiculo.Items.AddRange(new object[] {
            "Caminhão Toco",
            "Caminhão Truck",
            "Caminhão Baú",
            "Carreta Baú",
            "Carreta Graneleira",
            "Carreta Refrigerada"});
            this.comboTipoVeiculo.Location = new System.Drawing.Point(49, 114);
            this.comboTipoVeiculo.Name = "comboTipoVeiculo";
            this.comboTipoVeiculo.Size = new System.Drawing.Size(245, 28);
            this.comboTipoVeiculo.TabIndex = 2;
            // 
            // motoristaTableAdapter
            // 
            this.motoristaTableAdapter.ClearBeforeFill = true;
            // 
            // ScreenCriarVeiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 233);
            this.Controls.Add(this.comboTipoVeiculo);
            this.Controls.Add(this.comboMotorista);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPlaca);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAddVeiculo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenCriarVeiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Veículos | TerraCode";
            this.Load += new System.EventHandler(this.ScreenCriarVeiculos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.motoristaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbTerraCodeDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAddVeiculo;
        private System.Windows.Forms.ComboBox comboMotorista;
        private System.Windows.Forms.ComboBox comboTipoVeiculo;
        private dbTerraCodeDataSet dbTerraCodeDataSet;
        private System.Windows.Forms.BindingSource motoristaBindingSource;
        private dbTerraCodeDataSetTableAdapters.MotoristaTableAdapter motoristaTableAdapter;
    }
}