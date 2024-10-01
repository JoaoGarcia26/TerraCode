using System;
using System.Collections.Generic;
using System.Drawing;
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
        private FazendaService _fazendaService;
        private PLService _plService;
        private SafraService _safraService;
        
        public ScreenEstoque()
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
            _fazendaService = new FazendaService();
            _plService = new PLService();
            _safraService = new SafraService();
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
            CarregaComboSafra();
            lblTitulo.Text = $"Visão Geral do Estoque | {comboSafra.SelectedItem.ToString()}";
            lblSubTitulo.Font = new Font(lblSubTitulo.Font.FontFamily, 10, FontStyle.Regular);
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblTitulo.Top = 10;
            CarregaComboFazenda();
        }

        private void CarregaComboSafra()
        {
            var resultadoSafras = _safraService.RetornaTodasSafras();

            if (resultadoSafras.Sucesso)
            {
                comboSafra.Items.Clear();
                foreach (var item in resultadoSafras.Conteudo)
                {
                    comboSafra.Items.Add(item.Nome);
                }
                if (comboSafra.Items.Count > 0)
                {
                    comboSafra.SelectedIndex = comboSafra.Items.Count - 1;
                }
            }
        }

        private void LoadEstoqueChart(string Fazenda = null, string PL = null, string Safra = null)
        {
            int? idFazenda = null;
            int? idPL = null;
            int? idSafra = null;
            var estoqueGeral = new Dictionary<string, int>();

            if (!string.IsNullOrEmpty(Fazenda))
            {
                var fazendaSelecionada = _fazendaService.RetornaFazendaPeloNome(Fazenda);
                idFazenda = fazendaSelecionada.Conteudo.Id;
            }

            if (!string.IsNullOrEmpty(PL))
            {
                var plSelecionado = _plService.RetornaPlPeloNomeeFazenda(PL, Fazenda);

                if (plSelecionado == null || plSelecionado.Conteudo == null)
                {
                    idPL = null;
                }
                else
                {
                    idPL = plSelecionado.Conteudo.Id;
                }
            }

            var safraSelecionada = _safraService.RetornaSafraPeloNome(Safra);
            idSafra = safraSelecionada.Conteudo.Id;

            estoqueGeral = _estoqueService.GetEstoqueGeralPorFazendaEPL(idFazenda, idPL, idSafra).Conteudo;

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

            foreach (var item in estoqueGeral)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

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

        public void CarregaComboFazenda()
        {
            var fazendas = _fazendaService.RetornaTodasFazendas();
            comboFazenda.Items.Clear();
            foreach (var item in fazendas.Conteudo)
            {
                comboFazenda.Items.Add(item.Nome);
            }
        }

        private void comboFazenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pls = _plService.RetornaTodosPlDaFazenda(comboFazenda.SelectedItem.ToString());
            comboPL.Items.Clear();
            comboPL.SelectedIndex = -1;
            foreach (var item in pls.Conteudo)
            {
                comboPL.Items.Add(item.Nome);
            }
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboFazenda.SelectedItem?.ToString()))
            {
                MessageBox.Show("Selecione uma Fazenda para aplicar o filtro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(comboPL.SelectedItem?.ToString()))
            {
                string fazendaSelecionada = comboFazenda.SelectedItem.ToString();
                string plSelecionado = comboPL.SelectedItem?.ToString();
                

                LoadEstoqueChart(fazendaSelecionada, plSelecionado, comboSafra.SelectedItem.ToString());
                lblTitulo.Text = $"Visão Geral do Estoque | {comboSafra.SelectedItem.ToString()}";
                lblSubTitulo.Text = $"Fazenda: {fazendaSelecionada} | Todos os PL's";
            }
            else
            {
                string fazendaSelecionada = comboFazenda.SelectedItem.ToString();
                string plSelecionado = comboPL.SelectedItem?.ToString();

                LoadEstoqueChart(fazendaSelecionada, plSelecionado, comboSafra.SelectedItem.ToString());
                lblTitulo.Text = $"Visão Geral do Estoque | {comboSafra.SelectedItem.ToString()}";
                lblSubTitulo.Text = $"Fazenda: {fazendaSelecionada} | PL: {plSelecionado}";
            }

            lblSubTitulo.Font = new Font(lblSubTitulo.Font.FontFamily, 10, FontStyle.Regular);
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblTitulo.Top = 10;
            lblSubTitulo.Left = (this.ClientSize.Width - lblSubTitulo.Width) / 2;
            lblSubTitulo.Top = lblTitulo.Bottom + 5;
        }

        private void comboSafra_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTitulo.Text = $"Visão Geral do Estoque | {comboSafra.SelectedItem.ToString()}";
            lblSubTitulo.Font = new Font(lblSubTitulo.Font.FontFamily, 10, FontStyle.Regular);
            lblTitulo.Left = (this.ClientSize.Width - lblTitulo.Width) / 2;
            lblTitulo.Top = 10;

            if (string.IsNullOrEmpty(comboFazenda.SelectedItem?.ToString()))
            {
                LoadEstoqueChart(null, null, comboSafra.SelectedItem.ToString());
            } else if (string.IsNullOrEmpty(comboPL.SelectedItem?.ToString()))
            {
                LoadEstoqueChart(comboFazenda.SelectedItem.ToString(), null, comboSafra.SelectedItem.ToString());
            }
            LoadEstoqueChart(comboFazenda.SelectedItem?.ToString(), comboPL.SelectedItem?.ToString(), comboSafra.SelectedItem?.ToString());
        }


        /*private void ExibirGraficos(List<Model.Estoque> estoques)
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
                    Location = new Point(10, 10 + (estoques.IndexOf(estoque) * 360))
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
                groupBox.Controls.Add(chart);
                this.Controls.Add(groupBox);
            }
        }*/
    }
}
