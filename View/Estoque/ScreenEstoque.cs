using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Media;
using TerraCode.Service;

namespace TerraCode.View.Estoque
{
    public partial class ScreenEstoque : Form
    {
        private ScreenRegistrarEstoque _formRegistrarEstoque;
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
            var resultado = _estoqueService.RetornaTodosEstoques();

            DataTable dt = new DataTable();
            dt.Columns.Add("Data", typeof(DateTime));
            dt.Columns.Add("Evento", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Extra 8", typeof(int));
            dt.Columns.Add("Cat 8", typeof(int));
            dt.Columns.Add("Especial 8", typeof(int));
            dt.Columns.Add("Escovado 8", typeof(int));
            dt.Columns.Add("Comercial 8", typeof(int));
            dt.Columns.Add("Extra 7", typeof(int));
            dt.Columns.Add("Cat 7", typeof(int));
            dt.Columns.Add("Especial 7", typeof(int));
            dt.Columns.Add("Escovado 7", typeof(int));
            dt.Columns.Add("Comercial 7", typeof(int));
            dt.Columns.Add("Extra 6", typeof(int));
            dt.Columns.Add("Cat 6", typeof(int));
            dt.Columns.Add("Especial 6", typeof(int));
            dt.Columns.Add("Escovado 6", typeof(int));
            dt.Columns.Add("Comercial 6", typeof(int));
            dt.Columns.Add("Extra 5", typeof(int));
            dt.Columns.Add("Cat 5", typeof(int));
            dt.Columns.Add("Especial 5", typeof(int));
            dt.Columns.Add("Escovado 5", typeof(int));
            dt.Columns.Add("Comercial 5", typeof(int));
            dt.Columns.Add("Extra 4", typeof(int));
            dt.Columns.Add("Cat 4", typeof(int));
            dt.Columns.Add("Especial 4", typeof(int));
            dt.Columns.Add("Escovado 4", typeof(int));
            dt.Columns.Add("Comercial 4", typeof(int));
            dt.Columns.Add("Escovado 3", typeof(int));
            dt.Columns.Add("Borrado 20kg", typeof(int));
            dt.Columns.Add("Escovado 2/3", typeof(int));
            dt.Columns.Add("Industrial 20kg", typeof(int));
            dt.Columns.Add("Dente 20kg", typeof(int));

            if (resultado.Sucesso && resultado.Conteudo != null && resultado.Conteudo.Count > 0)
            {
                foreach (var item in resultado.Conteudo)
                {
                    dt.Rows.Add(
                        item.Data,
                        item.Evento,
                        item.DocNr,
                        item.Extra8,
                        item.Cat8,
                        item.Especial8,
                        item.Escovado8,
                        item.Comercial8,
                        item.Extra7,
                        item.Cat7,
                        item.Especial7,
                        item.Escovado7,
                        item.Comercial7,
                        item.Extra6,
                        item.Cat6,
                        item.Especial6,
                        item.Escovado6,
                        item.Comercial6,
                        item.Extra5,
                        item.Cat5,
                        item.Especial5,
                        item.Escovado5,
                        item.Comercial5,
                        item.Extra4,
                        item.Cat4,
                        item.Especial4,
                        item.Escovado4,
                        item.Comercial4,
                        item.Escovado3,
                        item.Borrado20kg,
                        item.Escovado2_3,
                        item.Industrial20kg,
                        item.Dente20kg
                    );
                }
            }
            else
            {
                MessageBox.Show("Nenhuma movimentação de estoque encontrada.");
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Evento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Documento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name.StartsWith("Extra") || col.Name.StartsWith("Cat") || col.Name.StartsWith("Especial") ||
                    col.Name.StartsWith("Escovado") || col.Name.StartsWith("Comercial") || col.Name == "Borrado 20kg" ||
                    col.Name == "Escovado 2/3" || col.Name == "Industrial 20kg" || col.Name == "Dente 20kg")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            dataGridView1.Refresh();
        }

        private void LoadEstoqueChart()
        {
            var estoqueGeral = _estoqueService.GetEstoqueGeral();

            cartesianChart1.Series.Clear();
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();

            var series = new SeriesCollection();
            var labels = new List<string>();

            foreach (var item in estoqueGeral.Conteudo)
            {
                var color = GetColorForTipoAlho(item.Key);

                series.Add(new ColumnSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<int> { item.Value },
                    Fill = new SolidColorBrush(color),
                    Stroke = new SolidColorBrush(color)
                });

                labels.Add(item.Key);
            }

            cartesianChart1.Series = series;

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Tipo de Alho",
                Labels = labels.ToArray()
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Quantidade",
                LabelFormatter = value => value.ToString("N")
            });
        }

        private Color GetColorForTipoAlho(string tipoAlho)
        {
            tipoAlho = tipoAlho.ToLower();

            if (tipoAlho.StartsWith("cat"))
            {
                return Colors.Blue;
            }
            else if (tipoAlho.StartsWith("comercial"))
            {
                return Colors.Green;
            }
            else if (tipoAlho.StartsWith("extra"))
            {
                return Colors.Red;
            }
            else if (tipoAlho.StartsWith("especial"))
            {
                return Colors.Orange;
            }
            else if (tipoAlho.StartsWith("escovado"))
            {
                return Colors.Purple;
            }
            else if (tipoAlho.StartsWith("dente"))
            {
                return Colors.Brown;
            }
            else if (tipoAlho.StartsWith("borrado"))
            {
                return Colors.IndianRed;
            }
            else if (tipoAlho.StartsWith("industrial"))
            {
                return Colors.Fuchsia;
            }
            return Colors.Gray;
        }
        private void ScreenEstoque_Activated(object sender, EventArgs e)
        {
            ScreenEstoque_Load(sender, e);
        }
    }
}
