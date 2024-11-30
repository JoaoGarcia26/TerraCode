using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TerraCode.Model;
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
                ExibirEstatisticasPorPL(fazendaSelecionada, plSelecionado, comboSafra.SelectedItem.ToString());
                lblTitulo.Text = $"Visão Geral do Estoque | {comboSafra.SelectedItem.ToString()}";
                lblSubTitulo.Text = $"Fazenda: {fazendaSelecionada} | Todos os PL's";
            }
            else
            {
                string fazendaSelecionada = comboFazenda.SelectedItem.ToString();
                string plSelecionado = comboPL.SelectedItem?.ToString();

                LoadEstoqueChart(fazendaSelecionada, plSelecionado, comboSafra.SelectedItem.ToString());
                ExibirEstatisticasPorPL(fazendaSelecionada, plSelecionado, comboSafra.SelectedItem.ToString());
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
            ExibirEstatisticasPorPL(comboFazenda.SelectedItem?.ToString(), comboPL.SelectedItem?.ToString(), comboSafra.SelectedItem?.ToString());
        }

        private void ExibirEstatisticasPorPL(string Fazenda = null, string PL = null, string Safra = null)
        {
            // Limpa os controles existentes no painel antes de exibir novos dados
            pnlGraficos.Controls.Clear();

            int? idFazenda = null;
            int? idPL = null;
            int? idSafra = null;

            var estoqueGeral = new Dictionary<string, int>();

            // Obtém o ID da fazenda, se fornecido
            if (!string.IsNullOrEmpty(Fazenda))
            {
                var fazendaSelecionada = _fazendaService.RetornaFazendaPeloNome(Fazenda);
                idFazenda = fazendaSelecionada.Conteudo.Id;
            }

            // Obtém o ID do PL, se fornecido
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

            // Obtém o ID da safra
            var safraSelecionada = _safraService.RetornaSafraPeloNome(Safra);
            idSafra = safraSelecionada.Conteudo.Id;

            // Recupera o estoque para a fazenda, PL e safra selecionados
            estoqueGeral = _estoqueService.GetEstoqueGeralPorFazendaEPL(idFazenda, idPL, idSafra).Conteudo;

            // Agrupa as subcategorias nas respectivas categorias
            var categoriasPrincipais = new Dictionary<string, int>
    {
        { "8", 0 },
        { "7", 0 },
        { "6", 0 },
        { "5", 0 },
        { "4", 0 },
        { "3", 0 },
        { "Industrial", 0 },
        { "Outros", 0 },
    };

            // Soma as subcategorias nas categorias principais
            foreach (var item in estoqueGeral)
            {
                Console.WriteLine($"{item.Key}");
                if (categoriasPrincipais.ContainsKey(item.Key))
                {
                    categoriasPrincipais[item.Key] += item.Value;
                }
                else if (item.Key.StartsWith("Extra 8"))
                {
                    categoriasPrincipais["8"] += item.Value; // Contando como categoria 8
                }
                else if (item.Key.StartsWith("Comercial 8"))
                {
                    categoriasPrincipais["8"] += item.Value; // Contando como categoria 8
                }
                else if (item.Key.StartsWith("Especial 8"))
                {
                    categoriasPrincipais["8"] += item.Value; // Contando como categoria 8
                }
                else if (item.Key.StartsWith("Cat 8"))
                {
                    categoriasPrincipais["8"] += item.Value; // Contando como categoria 8
                }
                else if (item.Key.StartsWith("Escovado 8"))
                {
                    categoriasPrincipais["8"] += item.Value; // Contando como categoria 8
                }
                else if (item.Key.StartsWith("Extra 7"))
                {
                    categoriasPrincipais["7"] += item.Value; // Contando como categoria 7
                }
                else if (item.Key.StartsWith("Comercial 7"))
                {
                    categoriasPrincipais["7"] += item.Value; // Contando como categoria 7
                }
                else if (item.Key.StartsWith("Especial 7"))
                {
                    categoriasPrincipais["7"] += item.Value; // Contando como categoria 7
                }
                else if (item.Key.StartsWith("Cat 7"))
                {
                    categoriasPrincipais["7"] += item.Value; // Contando como categoria 7
                }
                else if (item.Key.StartsWith("Escovado 7"))
                {
                    categoriasPrincipais["7"] += item.Value; // Contando como categoria 7
                }
                else if (item.Key.StartsWith("Extra 6"))
                {
                    categoriasPrincipais["6"] += item.Value; // Contando como categoria 6
                }
                else if (item.Key.StartsWith("Comercial 6"))
                {
                    categoriasPrincipais["6"] += item.Value; // Contando como categoria 6
                }
                else if (item.Key.StartsWith("Especial 6"))
                {
                    categoriasPrincipais["6"] += item.Value; // Contando como categoria 6
                }
                else if (item.Key.StartsWith("Cat 6"))
                {
                    categoriasPrincipais["6"] += item.Value; // Contando como categoria 6
                }
                else if (item.Key.StartsWith("Escovado 6"))
                {
                    categoriasPrincipais["6"] += item.Value; // Contando como categoria 6
                }
                else if (item.Key.StartsWith("Extra 5"))
                {
                    categoriasPrincipais["5"] += item.Value; // Contando como categoria 5
                }
                else if (item.Key.StartsWith("Comercial 5"))
                {
                    categoriasPrincipais["5"] += item.Value; // Contando como categoria 5
                }
                else if (item.Key.StartsWith("Especial 5"))
                {
                    categoriasPrincipais["5"] += item.Value; // Contando como categoria 5
                }
                else if (item.Key.StartsWith("Cat 5"))
                {
                    categoriasPrincipais["5"] += item.Value; // Contando como categoria 5
                }
                else if (item.Key.StartsWith("Escovado 5"))
                {
                    categoriasPrincipais["5"] += item.Value; // Contando como categoria 5
                }
                else if (item.Key.StartsWith("Extra 4"))
                {
                    categoriasPrincipais["4"] += item.Value; // Contando como categoria 4
                }
                else if (item.Key.StartsWith("Comercial 4"))
                {
                    categoriasPrincipais["4"] += item.Value; // Contando como categoria 4
                }
                else if (item.Key.StartsWith("Especial 4"))
                {
                    categoriasPrincipais["4"] += item.Value; // Contando como categoria 4
                }
                else if (item.Key.StartsWith("Cat 4"))
                {
                    categoriasPrincipais["4"] += item.Value; // Contando como categoria 4
                }
                else if (item.Key.StartsWith("Escovado 4"))
                {
                    categoriasPrincipais["4"] += item.Value; // Contando como categoria 4
                }
                else if (item.Key.StartsWith("Escovado 3"))
                {
                    categoriasPrincipais["3"] += item.Value; // Contando como categoria 3
                }
                else if (item.Key.StartsWith("Borrado 20kg"))
                {
                    categoriasPrincipais["Outros"] += item.Value; // Contando como categoria Outros
                }
                else if (item.Key.StartsWith("Escovado 2/3"))
                {
                    categoriasPrincipais["Outros"] += item.Value; // Contando como categoria Outros
                }
                else if (item.Key.StartsWith("Industrial 20kg"))
                {
                    categoriasPrincipais["Outros"] += item.Value; // Contando como categoria Outros
                }
                else if (item.Key.StartsWith("Dente 20kg"))
                {
                    categoriasPrincipais["Outros"] += item.Value; // Contando como categoria Outros
                }
            }

            // Calcula o total de estoque
            int totalEstoque = categoriasPrincipais.Values.Sum();

            if (totalEstoque == 0)
            {
                // Se o estoque total for zero, exibe uma mensagem informando
                Label lblNenhumEstoque = new Label
                {
                    Text = "Não há estoque disponível para os filtros selecionados.",
                    AutoSize = true,
                    Font = new Font("Lucida Sans Unicode", 10, FontStyle.Bold),
                    Dock = DockStyle.Top
                };
                pnlGraficos.Controls.Add(lblNenhumEstoque);
                return;
            }

            // Exibe as estatísticas de cada categoria principal em ordem crescente
            foreach (var categoria in categoriasPrincipais.OrderBy(c => c.Key))
            {
                if (categoria.Value > 0) // Verifica se a quantidade é maior que zero
                {
                    // Calcula a porcentagem de cada categoria em relação ao total
                    double porcentagem = ((double)categoria.Value / totalEstoque) * 100;

                    // Cria um label para exibir a estatística
                    Label lblEstatistica = new Label
                    {
                        Text = $"Classe {categoria.Key}: {categoria.Value} - ({porcentagem:F2}%)",
                        AutoSize = true,
                        Font = new Font("Lucida Sans Unicode", 8),
                        Dock = DockStyle.Top
                    };
                    pnlGraficos.Controls.Add(lblEstatistica);
                }
            }
        }
    }
}
