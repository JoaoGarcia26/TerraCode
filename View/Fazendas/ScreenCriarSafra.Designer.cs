namespace TerraCode.View.Fazendas
{
    partial class ScreenCriarSafra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenCriarSafra));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.txtNomeSafra = new System.Windows.Forms.TextBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnAddSafra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(44, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Ano:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Safra:";
            // 
            // txtAno
            // 
            this.txtAno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAno.Location = new System.Drawing.Point(47, 101);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(172, 26);
            this.txtAno.TabIndex = 28;
            // 
            // txtNomeSafra
            // 
            this.txtNomeSafra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeSafra.Location = new System.Drawing.Point(47, 43);
            this.txtNomeSafra.Name = "txtNomeSafra";
            this.txtNomeSafra.Size = new System.Drawing.Size(172, 26);
            this.txtNomeSafra.TabIndex = 27;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(274, 93);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 45);
            this.btnVoltar.TabIndex = 30;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            // 
            // btnAddSafra
            // 
            this.btnAddSafra.Location = new System.Drawing.Point(274, 35);
            this.btnAddSafra.Name = "btnAddSafra";
            this.btnAddSafra.Size = new System.Drawing.Size(114, 45);
            this.btnAddSafra.TabIndex = 29;
            this.btnAddSafra.Text = "Cadastrar Safra";
            this.btnAddSafra.UseVisualStyleBackColor = true;
            this.btnAddSafra.Click += new System.EventHandler(this.btnAddSafra_Click);
            // 
            // ScreenCriarSafra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 155);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAno);
            this.Controls.Add(this.txtNomeSafra);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnAddSafra);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenCriarSafra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Safra | TerraCode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.TextBox txtNomeSafra;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnAddSafra;
    }
}