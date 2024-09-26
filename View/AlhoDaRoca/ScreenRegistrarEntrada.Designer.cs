namespace TerraCode.View.AlhoDaRoca
{
    partial class ScreenRegistrarEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenRegistrarEntrada));
            this.comboPL = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.comboMotorista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboVeiculos = new System.Windows.Forms.ComboBox();
            this.txtQtdCaixas = new System.Windows.Forms.NumericUpDown();
            this.comboFazenda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pickerDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPesoTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdCaixas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboPL
            // 
            this.comboPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPL.FormattingEnabled = true;
            this.comboPL.Location = new System.Drawing.Point(22, 152);
            this.comboPL.Name = "comboPL";
            this.comboPL.Size = new System.Drawing.Size(245, 28);
            this.comboPL.TabIndex = 78;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 17);
            this.label8.TabIndex = 77;
            this.label8.Text = "PL:";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.AutoSize = true;
            this.btnRegistrar.Location = new System.Drawing.Point(413, 206);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(126, 44);
            this.btnRegistrar.TabIndex = 76;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // comboMotorista
            // 
            this.comboMotorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMotorista.FormattingEnabled = true;
            this.comboMotorista.Location = new System.Drawing.Point(352, 95);
            this.comboMotorista.Name = "comboMotorista";
            this.comboMotorista.Size = new System.Drawing.Size(245, 28);
            this.comboMotorista.TabIndex = 74;
            this.comboMotorista.SelectedIndexChanged += new System.EventHandler(this.comboMotorista_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Veículo:";
            // 
            // comboVeiculos
            // 
            this.comboVeiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboVeiculos.FormattingEnabled = true;
            this.comboVeiculos.Location = new System.Drawing.Point(352, 152);
            this.comboVeiculos.Name = "comboVeiculos";
            this.comboVeiculos.Size = new System.Drawing.Size(245, 28);
            this.comboVeiculos.TabIndex = 72;
            // 
            // txtQtdCaixas
            // 
            this.txtQtdCaixas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdCaixas.Location = new System.Drawing.Point(352, 41);
            this.txtQtdCaixas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQtdCaixas.Name = "txtQtdCaixas";
            this.txtQtdCaixas.Size = new System.Drawing.Size(245, 27);
            this.txtQtdCaixas.TabIndex = 71;
            // 
            // comboFazenda
            // 
            this.comboFazenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFazenda.FormattingEnabled = true;
            this.comboFazenda.Location = new System.Drawing.Point(22, 97);
            this.comboFazenda.Name = "comboFazenda";
            this.comboFazenda.Size = new System.Drawing.Size(245, 28);
            this.comboFazenda.TabIndex = 63;
            this.comboFazenda.SelectedIndexChanged += new System.EventHandler(this.comboFazenda_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 68;
            this.label6.Text = "Fazenda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(352, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Motorista:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(352, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 65;
            this.label1.Text = "Quantidade de Caixas:";
            // 
            // pickerDataEntrada
            // 
            this.pickerDataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickerDataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.pickerDataEntrada.Location = new System.Drawing.Point(22, 41);
            this.pickerDataEntrada.Name = "pickerDataEntrada";
            this.pickerDataEntrada.Size = new System.Drawing.Size(244, 27);
            this.pickerDataEntrada.TabIndex = 79;
            this.pickerDataEntrada.Value = new System.DateTime(2024, 9, 23, 11, 24, 10, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 80;
            this.label4.Text = "Data da Entrada:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(181, 17);
            this.label5.TabIndex = 81;
            this.label5.Text = "Peso Total da Carga (Kg):";
            // 
            // txtPesoTotal
            // 
            this.txtPesoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesoTotal.Location = new System.Drawing.Point(22, 214);
            this.txtPesoTotal.Name = "txtPesoTotal";
            this.txtPesoTotal.Size = new System.Drawing.Size(244, 27);
            this.txtPesoTotal.TabIndex = 82;
            // 
            // ScreenRegistrarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 264);
            this.Controls.Add(this.txtPesoTotal);
            this.Controls.Add(this.comboVeiculos);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboMotorista);
            this.Controls.Add(this.comboFazenda);
            this.Controls.Add(this.comboPL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pickerDataEntrada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQtdCaixas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenRegistrarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Entrada | TerraCode";
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdCaixas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboPL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.ComboBox comboMotorista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboVeiculos;
        private System.Windows.Forms.NumericUpDown txtQtdCaixas;
        private System.Windows.Forms.ComboBox comboFazenda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker pickerDataEntrada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPesoTotal;
    }
}