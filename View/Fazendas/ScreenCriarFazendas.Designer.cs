﻿namespace TerraCode.View
{
    partial class ScreenCriarFazendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCriarFazendas));
            this.label4 = new System.Windows.Forms.Label();
            this.txtAreaPlantada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.txtNomeFaz = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAddFazenda = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(46, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 17);
            this.label4.TabIndex = 25;
            this.label4.Text = "Área Total Plantada (HA):";
            // 
            // txtAreaPlantada
            // 
            this.txtAreaPlantada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAreaPlantada.Location = new System.Drawing.Point(49, 175);
            this.txtAreaPlantada.Name = "txtAreaPlantada";
            this.txtAreaPlantada.Size = new System.Drawing.Size(245, 26);
            this.txtAreaPlantada.TabIndex = 3;
            this.txtAreaPlantada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAreaPlantada_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Localização:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(46, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nome da Fazenda:";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocalizacao.Location = new System.Drawing.Point(49, 114);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(245, 26);
            this.txtLocalizacao.TabIndex = 2;
            // 
            // txtNomeFaz
            // 
            this.txtNomeFaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFaz.Location = new System.Drawing.Point(49, 50);
            this.txtNomeFaz.Name = "txtNomeFaz";
            this.txtNomeFaz.Size = new System.Drawing.Size(245, 26);
            this.txtNomeFaz.TabIndex = 1;
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
            // btnAddFazenda
            // 
            this.btnAddFazenda.Location = new System.Drawing.Point(363, 50);
            this.btnAddFazenda.Name = "btnAddFazenda";
            this.btnAddFazenda.Size = new System.Drawing.Size(114, 62);
            this.btnAddFazenda.TabIndex = 4;
            this.btnAddFazenda.Text = "Adicionar Fazenda";
            this.btnAddFazenda.UseVisualStyleBackColor = true;
            this.btnAddFazenda.Click += new System.EventHandler(this.btnAddFazenda_Click);
            // 
            // ScreenCriarFazendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 233);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAreaPlantada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.txtNomeFaz);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAddFazenda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenCriarFazendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fazendas | TerraCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAreaPlantada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.TextBox txtNomeFaz;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAddFazenda;
    }
}