namespace TerraCode.View.Estoque
{
    partial class ScreenRegistrarEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenRegistrarEstoque));
            this.dataEntrada = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarLancamento = new System.Windows.Forms.Button();
            this.comboTipoAlho = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboEvento = new System.Windows.Forms.ComboBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExtra = new System.Windows.Forms.Label();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblEspecial = new System.Windows.Forms.Label();
            this.lblEscovado = new System.Windows.Forms.Label();
            this.numExtra = new System.Windows.Forms.NumericUpDown();
            this.numCat = new System.Windows.Forms.NumericUpDown();
            this.numEspecial = new System.Windows.Forms.NumericUpDown();
            this.numEscovado = new System.Windows.Forms.NumericUpDown();
            this.numComercial = new System.Windows.Forms.NumericUpDown();
            this.lblComercial = new System.Windows.Forms.Label();
            this.numValor = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidade = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEspecial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscovado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComercial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).BeginInit();
            this.SuspendLayout();
            // 
            // dataEntrada
            // 
            this.dataEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEntrada.Location = new System.Drawing.Point(33, 46);
            this.dataEntrada.Name = "dataEntrada";
            this.dataEntrada.Size = new System.Drawing.Size(169, 27);
            this.dataEntrada.TabIndex = 0;
            this.dataEntrada.Value = new System.DateTime(2024, 9, 26, 19, 58, 57, 0);
            // 
            // btnRegistrarLancamento
            // 
            this.btnRegistrarLancamento.Location = new System.Drawing.Point(51, 294);
            this.btnRegistrarLancamento.Name = "btnRegistrarLancamento";
            this.btnRegistrarLancamento.Size = new System.Drawing.Size(112, 46);
            this.btnRegistrarLancamento.TabIndex = 2;
            this.btnRegistrarLancamento.Text = "Registrar Lançamento";
            this.btnRegistrarLancamento.UseVisualStyleBackColor = true;
            this.btnRegistrarLancamento.Click += new System.EventHandler(this.btnRegistrarLancamento_Click);
            // 
            // comboTipoAlho
            // 
            this.comboTipoAlho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTipoAlho.FormattingEnabled = true;
            this.comboTipoAlho.Items.AddRange(new object[] {
            "8",
            "7",
            "6",
            "5",
            "4",
            "3",
            "Borrado 20kg",
            "2/3",
            "Industrial 20kg",
            "Dente 20kg"});
            this.comboTipoAlho.Location = new System.Drawing.Point(31, 173);
            this.comboTipoAlho.Name = "comboTipoAlho";
            this.comboTipoAlho.Size = new System.Drawing.Size(171, 28);
            this.comboTipoAlho.TabIndex = 3;
            this.comboTipoAlho.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 99;
            this.label7.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 100;
            this.label1.Text = "Tipo do Alho:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 102;
            this.label2.Text = "Evento:";
            // 
            // comboEvento
            // 
            this.comboEvento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboEvento.FormattingEnabled = true;
            this.comboEvento.Items.AddRange(new object[] {
            "Produção",
            "Transferência"});
            this.comboEvento.Location = new System.Drawing.Point(31, 239);
            this.comboEvento.Name = "comboEvento";
            this.comboEvento.Size = new System.Drawing.Size(171, 28);
            this.comboEvento.TabIndex = 101;
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDoc.Location = new System.Drawing.Point(31, 110);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(171, 27);
            this.txtNumDoc.TabIndex = 103;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 104;
            this.label3.Text = "Nº do Documento:";
            // 
            // lblExtra
            // 
            this.lblExtra.AutoSize = true;
            this.lblExtra.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExtra.Location = new System.Drawing.Point(267, 28);
            this.lblExtra.Name = "lblExtra";
            this.lblExtra.Size = new System.Drawing.Size(48, 17);
            this.lblExtra.TabIndex = 106;
            this.lblExtra.Text = "Extra:";
            this.lblExtra.Visible = false;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCat.Location = new System.Drawing.Point(267, 90);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(35, 17);
            this.lblCat.TabIndex = 108;
            this.lblCat.Text = "Cat:";
            this.lblCat.Visible = false;
            // 
            // lblEspecial
            // 
            this.lblEspecial.AutoSize = true;
            this.lblEspecial.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEspecial.Location = new System.Drawing.Point(267, 153);
            this.lblEspecial.Name = "lblEspecial";
            this.lblEspecial.Size = new System.Drawing.Size(67, 17);
            this.lblEspecial.TabIndex = 110;
            this.lblEspecial.Text = "Especial:";
            this.lblEspecial.Visible = false;
            // 
            // lblEscovado
            // 
            this.lblEscovado.AutoSize = true;
            this.lblEscovado.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscovado.Location = new System.Drawing.Point(267, 219);
            this.lblEscovado.Name = "lblEscovado";
            this.lblEscovado.Size = new System.Drawing.Size(76, 17);
            this.lblEscovado.TabIndex = 112;
            this.lblEscovado.Text = "Escovado:";
            this.lblEscovado.Visible = false;
            // 
            // numExtra
            // 
            this.numExtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numExtra.Location = new System.Drawing.Point(270, 49);
            this.numExtra.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numExtra.Name = "numExtra";
            this.numExtra.Size = new System.Drawing.Size(139, 27);
            this.numExtra.TabIndex = 113;
            this.numExtra.Visible = false;
            // 
            // numCat
            // 
            this.numCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numCat.Location = new System.Drawing.Point(270, 111);
            this.numCat.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numCat.Name = "numCat";
            this.numCat.Size = new System.Drawing.Size(139, 27);
            this.numCat.TabIndex = 114;
            this.numCat.Visible = false;
            // 
            // numEspecial
            // 
            this.numEspecial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEspecial.Location = new System.Drawing.Point(270, 174);
            this.numEspecial.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEspecial.Name = "numEspecial";
            this.numEspecial.Size = new System.Drawing.Size(139, 27);
            this.numEspecial.TabIndex = 115;
            this.numEspecial.Visible = false;
            // 
            // numEscovado
            // 
            this.numEscovado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numEscovado.Location = new System.Drawing.Point(270, 240);
            this.numEscovado.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numEscovado.Name = "numEscovado";
            this.numEscovado.Size = new System.Drawing.Size(139, 27);
            this.numEscovado.TabIndex = 116;
            this.numEscovado.Visible = false;
            // 
            // numComercial
            // 
            this.numComercial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numComercial.Location = new System.Drawing.Point(270, 304);
            this.numComercial.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numComercial.Name = "numComercial";
            this.numComercial.Size = new System.Drawing.Size(139, 27);
            this.numComercial.TabIndex = 119;
            this.numComercial.Visible = false;
            // 
            // lblComercial
            // 
            this.lblComercial.AutoSize = true;
            this.lblComercial.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComercial.Location = new System.Drawing.Point(267, 283);
            this.lblComercial.Name = "lblComercial";
            this.lblComercial.Size = new System.Drawing.Size(81, 17);
            this.lblComercial.TabIndex = 118;
            this.lblComercial.Text = "Comercial:";
            this.lblComercial.Visible = false;
            // 
            // numValor
            // 
            this.numValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numValor.Location = new System.Drawing.Point(270, 49);
            this.numValor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numValor.Name = "numValor";
            this.numValor.Size = new System.Drawing.Size(139, 27);
            this.numValor.TabIndex = 121;
            this.numValor.Visible = false;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Lucida Sans Unicode", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(267, 28);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(92, 17);
            this.lblQuantidade.TabIndex = 120;
            this.lblQuantidade.Text = "Quantidade:";
            this.lblQuantidade.Visible = false;
            // 
            // ScreenRegistrarEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 358);
            this.Controls.Add(this.numValor);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.numComercial);
            this.Controls.Add(this.lblComercial);
            this.Controls.Add(this.numEscovado);
            this.Controls.Add(this.numEspecial);
            this.Controls.Add(this.numCat);
            this.Controls.Add(this.numExtra);
            this.Controls.Add(this.lblEscovado);
            this.Controls.Add(this.lblEspecial);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.lblExtra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboEvento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboTipoAlho);
            this.Controls.Add(this.btnRegistrarLancamento);
            this.Controls.Add(this.dataEntrada);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenRegistrarEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Estoque | TerraCode";
            ((System.ComponentModel.ISupportInitialize)(this.numExtra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEspecial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numEscovado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComercial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dataEntrada;
        private System.Windows.Forms.Button btnRegistrarLancamento;
        private System.Windows.Forms.ComboBox comboTipoAlho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboEvento;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblEspecial;
        private System.Windows.Forms.Label lblEscovado;
        private System.Windows.Forms.NumericUpDown numExtra;
        private System.Windows.Forms.NumericUpDown numCat;
        private System.Windows.Forms.NumericUpDown numEspecial;
        private System.Windows.Forms.NumericUpDown numEscovado;
        private System.Windows.Forms.NumericUpDown numComercial;
        private System.Windows.Forms.Label lblComercial;
        private System.Windows.Forms.NumericUpDown numValor;
        private System.Windows.Forms.Label lblQuantidade;
    }
}