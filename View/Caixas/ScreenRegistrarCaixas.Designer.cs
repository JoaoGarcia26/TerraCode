﻿namespace TerraCode.View
{
    partial class ScreenRegistrarCaixas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenRegistrarCaixas));
            this.comboBarracao = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboFazDestino = new System.Windows.Forms.ComboBox();
            this.txtQtdCaixas = new System.Windows.Forms.NumericUpDown();
            this.comboVeiculos = new System.Windows.Forms.ComboBox();
            this.comboMotorista = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.dataEnvio = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdCaixas)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBarracao
            // 
            this.comboBarracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBarracao.FormattingEnabled = true;
            this.comboBarracao.Location = new System.Drawing.Point(367, 46);
            this.comboBarracao.Name = "comboBarracao";
            this.comboBarracao.Size = new System.Drawing.Size(245, 28);
            this.comboBarracao.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(364, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 17);
            this.label5.TabIndex = 50;
            this.label5.Text = "Fazenda de Destino:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(364, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "Barracão de Origem:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "Observação:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacoes.Location = new System.Drawing.Point(33, 175);
            this.txtObservacoes.MaxLength = 250;
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(245, 83);
            this.txtObservacoes.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(364, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 47;
            this.label2.Text = "Motorista:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 17);
            this.label1.TabIndex = 46;
            this.label1.Text = "Quantidade de Caixas:";
            // 
            // comboFazDestino
            // 
            this.comboFazDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFazDestino.FormattingEnabled = true;
            this.comboFazDestino.Location = new System.Drawing.Point(367, 111);
            this.comboFazDestino.Name = "comboFazDestino";
            this.comboFazDestino.Size = new System.Drawing.Size(245, 28);
            this.comboFazDestino.TabIndex = 51;
            // 
            // txtQtdCaixas
            // 
            this.txtQtdCaixas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtdCaixas.Location = new System.Drawing.Point(34, 48);
            this.txtQtdCaixas.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.txtQtdCaixas.Name = "txtQtdCaixas";
            this.txtQtdCaixas.Size = new System.Drawing.Size(245, 27);
            this.txtQtdCaixas.TabIndex = 52;
            // 
            // comboVeiculos
            // 
            this.comboVeiculos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboVeiculos.FormattingEnabled = true;
            this.comboVeiculos.Location = new System.Drawing.Point(367, 234);
            this.comboVeiculos.Name = "comboVeiculos";
            this.comboVeiculos.Size = new System.Drawing.Size(245, 28);
            this.comboVeiculos.TabIndex = 53;
            // 
            // comboMotorista
            // 
            this.comboMotorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMotorista.FormattingEnabled = true;
            this.comboMotorista.Location = new System.Drawing.Point(367, 173);
            this.comboMotorista.Name = "comboMotorista";
            this.comboMotorista.Size = new System.Drawing.Size(245, 28);
            this.comboMotorista.TabIndex = 55;
            this.comboMotorista.SelectedIndexChanged += new System.EventHandler(this.comboMotorista_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(364, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Veículo:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(33, 285);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 45);
            this.btnVoltar.TabIndex = 56;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(497, 276);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 62);
            this.btnRegistrar.TabIndex = 57;
            this.btnRegistrar.Text = "Registrar Envio";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // dataEnvio
            // 
            this.dataEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEnvio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEnvio.Location = new System.Drawing.Point(33, 112);
            this.dataEnvio.Name = "dataEnvio";
            this.dataEnvio.Size = new System.Drawing.Size(245, 27);
            this.dataEnvio.TabIndex = 58;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 59;
            this.label7.Text = "Data de Envio:";
            // 
            // ScreenRegistrarCaixas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 351);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dataEnvio);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.comboMotorista);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboVeiculos);
            this.Controls.Add(this.txtQtdCaixas);
            this.Controls.Add(this.comboFazDestino);
            this.Controls.Add(this.comboBarracao);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenRegistrarCaixas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Saídas | TerraCode";
            this.Load += new System.EventHandler(this.ScreenRegistrarCaixas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtQtdCaixas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBarracao;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboFazDestino;
        private System.Windows.Forms.NumericUpDown txtQtdCaixas;
        private System.Windows.Forms.ComboBox comboVeiculos;
        private System.Windows.Forms.ComboBox comboMotorista;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.DateTimePicker dataEnvio;
        private System.Windows.Forms.Label label7;
    }
}