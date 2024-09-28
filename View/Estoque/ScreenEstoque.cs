using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TerraCode.Service;
using TerraCode.View.Estoque.Movimentacoes;

namespace TerraCode.View.Estoque
{
    public partial class ScreenEstoque : Form
    {
        private ScreenRegistrarEstoque _formRegistrarEstoque;
        private ScreenMovimentacoesEstoque _formMovimentacoesEstoque;
        private EstoqueService _estoqueService;
        
        public ScreenEstoque()
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
            LoadEstoqueChart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_formRegistrarEstoque == null || _formRegistrarEstoque.IsDisposed)
            {
                _formRegistrarEstoque = new ScreenRegistrarEstoque();
            }
            _formRegistrarEstoque.ShowDialog();
        }
        private void ScreenEstoque_Load(object sender, EventArgs e)
        {
            LoadEstoqueChart();
        }

        private void LoadEstoqueChart()
        {
            var estoqueGeral = _estoqueService.GetEstoqueGeral();

            chartEstoque.Series.Clear();
            chartEstoque.ChartAreas.Clear();
            chartEstoque.Legends.Clear();

            var chartArea = new ChartArea
            {
                Name = "EstoqueChartArea",
                AxisX =
                {
                    Title = "Tipo de Alho",
                    Interval = 1,
                    IsLabelAutoFit = true,
                    MajorGrid = { Enabled = false },
                    MinorGrid = { Enabled = false },
                    TitleFont = new Font("Lucida Sans Unicode", 10, FontStyle.Regular)
                },
                AxisY =
                {
                    Title = "Quantidade em Estoque",
                    IsLabelAutoFit = true,
                    LabelStyle = { Format = "N0" },
                    MajorGrid = { Enabled = false },
                    MinorGrid = { Enabled = false },
                    TitleFont = new Font("Lucida Sans Unicode", 10, FontStyle.Regular)
                }
            };

            chartEstoque.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Quantidade de Alho",
                Color = System.Drawing.Color.Purple,
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Column,
                BorderWidth = 2
            };

            // Adiciona os pontos à série
            foreach (var item in estoqueGeral.Conteudo)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            // Adiciona a série ao gráfico
            chartEstoque.Series.Add(series);

            chartEstoque.BorderlineDashStyle = ChartDashStyle.Solid;
        }

        private void ScreenEstoque_Activated(object sender, EventArgs e)
        {
            ScreenEstoque_Load(sender, e);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMovimentacoes_Click(object sender, EventArgs e)
        {
            if (_formMovimentacoesEstoque == null || _formMovimentacoesEstoque.IsDisposed)
            {
                _formMovimentacoesEstoque = new ScreenMovimentacoesEstoque();
            }
            _formMovimentacoesEstoque.ShowDialog();
        }

        private void ExibirGraficos(List<Model.Estoque> estoques)
        {
            this.Controls.OfType<Chart>().ToList().ForEach(c => this.Controls.Remove(c));

            foreach (var estoque in estoques)
            {
                var groupBox = new GroupBox
                {
                    Name = $"groupBoxPL_{estoque.PL_Id}",
                    Text = $"Estoque de Alho para PL {estoque.PL_Id}",
                    Width = 420,
                    Height = 350,
                    Location = new Point(10, 10 + (estoques.IndexOf(estoque) * 360)) // Ajuste a posição conforme necessário
                };

                var chart = new Chart
                {
                    Name = $"chartPL_{estoque.PL_Id}",
                    Width = 400,
                    Height = 300
                };

                var series = new Series($"Total Alho PL {estoque.PL_Id}")
                {
                    ChartType = SeriesChartType.Pie
                };

                series.Points.AddXY("Total Alho 8", estoque.TotalAlho8);
                series.Points.AddXY("Total Alho 7", estoque.TotalAlho7);
                series.Points.AddXY("Total Alho 6", estoque.TotalAlho6);
                series.Points.AddXY("Total Alho 5", estoque.TotalAlho5);
                series.Points.AddXY("Total Alho 4", estoque.TotalAlho4);
                series.Points.AddXY("Total Alho 3", estoque.TotalAlho3);

                chart.Series.Add(series);
                groupBox.Controls.Add(chart); // Adiciona o gráfico ao GroupBox
                this.Controls.Add(groupBox); // Adiciona o GroupBox à tela
            }
        }
    }
}
