namespace TerraCode.View.Estoque
{
    partial class ScreenEstoque
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEstoque));
            this.btnVoltar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chartEstoque = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMovimentacoes = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboFazenda = new System.Windows.Forms.ComboBox();
            this.comboPL = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubTitulo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.comboSafra = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartEstoque)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(49, 761);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(114, 52);
            this.btnVoltar.TabIndex = 18;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1169, 761);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 52);
            this.button1.TabIndex = 19;
            this.button1.Text = "Registrar Novo Lançamento";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chartEstoque
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEstoque.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEstoque.Legends.Add(legend1);
            this.chartEstoque.Location = new System.Drawing.Point(12, 345);
            this.chartEstoque.Name = "chartEstoque";
            this.chartEstoque.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEstoque.Series.Add(series1);
            this.chartEstoque.Size = new System.Drawing.Size(1308, 391);
            this.chartEstoque.TabIndex = 20;
            this.chartEstoque.Text = "chart1";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(560, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(230, 28);
            this.lblTitulo.TabIndex = 21;
            this.lblTitulo.Text = "Visão Geral do Estoque";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnMovimentacoes
            // 
            this.btnMovimentacoes.Location = new System.Drawing.Point(620, 761);
            this.btnMovimentacoes.Name = "btnMovimentacoes";
            this.btnMovimentacoes.Size = new System.Drawing.Size(114, 52);
            this.btnMovimentacoes.TabIndex = 22;
            this.btnMovimentacoes.Text = "Ver Movimentações";
            this.btnMovimentacoes.UseVisualStyleBackColor = true;
            this.btnMovimentacoes.Click += new System.EventHandler(this.btnMovimentacoes_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1308, 236);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações por PL:";
            // 
            // comboFazenda
            // 
            this.comboFazenda.FormattingEnabled = true;
            this.comboFazenda.Location = new System.Drawing.Point(10, 46);
            this.comboFazenda.Name = "comboFazenda";
            this.comboFazenda.Size = new System.Drawing.Size(174, 26);
            this.comboFazenda.TabIndex = 24;
            this.comboFazenda.SelectedIndexChanged += new System.EventHandler(this.comboFazenda_SelectedIndexChanged);
            // 
            // comboPL
            // 
            this.comboPL.FormattingEnabled = true;
            this.comboPL.Location = new System.Drawing.Point(206, 46);
            this.comboPL.Name = "comboPL";
            this.comboPL.Size = new System.Drawing.Size(111, 26);
            this.comboPL.TabIndex = 25;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnFiltros);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboFazenda);
            this.groupBox2.Controls.Add(this.comboPL);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 85);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtros:";
            // 
            // btnFiltros
            // 
            this.btnFiltros.Location = new System.Drawing.Point(338, 28);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(77, 47);
            this.btnFiltros.TabIndex = 28;
            this.btnFiltros.Text = "Aplicar Filtros";
            this.btnFiltros.UseVisualStyleBackColor = true;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 27;
            this.label3.Text = "Fazenda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 18);
            this.label2.TabIndex = 26;
            this.label2.Text = "PL:";
            // 
            // lblSubTitulo
            // 
            this.lblSubTitulo.AutoSize = true;
            this.lblSubTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitulo.Location = new System.Drawing.Point(588, 40);
            this.lblSubTitulo.Name = "lblSubTitulo";
            this.lblSubTitulo.Size = new System.Drawing.Size(163, 23);
            this.lblSubTitulo.TabIndex = 25;
            this.lblSubTitulo.Text = "Todas Fazendas/PL\'s";
            this.lblSubTitulo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboSafra);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(1192, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 60);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Safra:";
            // 
            // comboSafra
            // 
            this.comboSafra.FormattingEnabled = true;
            this.comboSafra.Location = new System.Drawing.Point(6, 21);
            this.comboSafra.Name = "comboSafra";
            this.comboSafra.Size = new System.Drawing.Size(111, 26);
            this.comboSafra.TabIndex = 25;
            this.comboSafra.SelectedIndexChanged += new System.EventHandler(this.comboSafra_SelectedIndexChanged);
            // 
            // ScreenEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1332, 827);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblSubTitulo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnMovimentacoes);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.chartEstoque);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScreenEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estoque | TerraCode";
            this.Activated += new System.EventHandler(this.ScreenEstoque_Activated);
            this.Load += new System.EventHandler(this.ScreenEstoque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartEstoque)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEstoque;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMovimentacoes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboFazenda;
        private System.Windows.Forms.ComboBox comboPL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.Label lblSubTitulo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboSafra;
    }
}