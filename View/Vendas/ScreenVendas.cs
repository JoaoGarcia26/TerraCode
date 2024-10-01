using System;
using System.Data;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Vendas
{
    public partial class ScreenVendas : Form
    {
        private readonly VendasService _vendasService;
        private ScreenCriarVendas _formCriarVendas;
        public ScreenVendas()
        {
            InitializeComponent();
            _vendasService = new VendasService();
        }

        private void ScreenVendas_Load(object sender, EventArgs e)
        {
            CarregaTabela();
        }

        private void CarregaTabela()
        {
            var resultado = _vendasService.RetornaTodasVendas();

            DataTable dt = new DataTable();
            dt.Columns.Add("Data", typeof(DateTime));
            dt.Columns.Add("Comprador", typeof(string));
            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("CPF Motorista", typeof(string));
            dt.Columns.Add("Placa Veículo", typeof(string));
            dt.Columns.Add("Produto", typeof(string));
            dt.Columns.Add("Quantidade Caixas", typeof(int));

            if (resultado.Sucesso && resultado.Conteudo != null && resultado.Conteudo.Count > 0)
            {
                foreach (var item in resultado.Conteudo)
                {
                    dt.Rows.Add(
                        item.Data,
                        item.Comprador,
                        item.Motorista ?? "Não informado",
                        item.CPFMotorista ?? "Não informado",
                        item.PlacaVeiculo ?? "Não informado",
                        item.Produto,
                        item.QuantidadeCaixas
                    );
                }
            }
            else
            {
                MessageBox.Show("Nenhuma venda encontrada.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Comprador"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["CPF Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Placa Veículo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Produto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Quantidade Caixas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_formCriarVendas == null || _formCriarVendas.IsDisposed)
            {
                _formCriarVendas = new ScreenCriarVendas();
            }
            _formCriarVendas.ShowDialog();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ScreenVendas_Activated(object sender, EventArgs e)
        {
            CarregaTabela();
        }
    }
}
