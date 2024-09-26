using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCaixas : Form
    {
        private ScreenRegistrarCaixas _formRegistrarCaixas;
        private CaixaService _caixaService;
        public ScreenCaixas()
        {
            InitializeComponent();
            _caixaService = new CaixaService(); 
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegMovimentacao_Click(object sender, EventArgs e)
        {
            _formRegistrarCaixas = new ScreenRegistrarCaixas();
            _formRegistrarCaixas.ShowDialog();
        }

        private void ScreenCaixas_Load(object sender, EventArgs e)
        {
            this.motoristaTableAdapter.Fill(this.dbTerraCodeDataSet.Motorista);
            this.veiculoTableAdapter.Fill(this.dbTerraCodeDataSet.Veiculo);
            this.caixasTableAdapter.Fill(this.dbTerraCodeDataSet.Caixas);
            this.movimentacaoCaixasTableAdapter.Fill(this.dbTerraCodeDataSet.MovimentacaoCaixas);

            DataTable dt = new DataTable();

            dt.Columns.Add("Data Movimentação", typeof(DateTime));
            dt.Columns.Add("Tipo Movimentação", typeof(string));
            dt.Columns.Add("Fazenda Origem", typeof(string));
            dt.Columns.Add("Fazenda Destino", typeof(string));
            dt.Columns.Add("Quantidade de Caixas", typeof(int));
            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("Veículo", typeof(string));
            dt.Columns.Add("Observações", typeof(string));

            this.movimentacaoCaixasTableAdapter.Fill(this.dbTerraCodeDataSet.MovimentacaoCaixas);
            this.fazendasTableAdapter.Fill(this.dbTerraCodeDataSet.Fazendas);
            this.motoristaTableAdapter.Fill(this.dbTerraCodeDataSet.Motorista);
            this.veiculoTableAdapter.Fill(this.dbTerraCodeDataSet.Veiculo);


            var query = from movimentacao in this.dbTerraCodeDataSet.MovimentacaoCaixas
                        join origem in this.dbTerraCodeDataSet.Fazendas
                        on movimentacao.FazendaOrigemId equals origem.Id
                        join destino in this.dbTerraCodeDataSet.Fazendas
                        on movimentacao.FazendaDestinoId equals destino.Id
                        join motorista in this.dbTerraCodeDataSet.Motorista
                        on movimentacao.MotoristaId equals motorista.Id
                        join veiculo in this.dbTerraCodeDataSet.Veiculo
                        on movimentacao.VeiculoId equals veiculo.Id
                        select new
                        {
                            DataMovimentacao = movimentacao.DataMovimentacao,
                            TipoMovimentacao = movimentacao.TipoMovimentacao,
                            FazendaOrigem = origem.Nome,
                            FazendaDestino = destino.Nome,
                            QuantidadeCaixas = movimentacao.QuantidadeCaixas,
                            Motorista = motorista.Nome,
                            Veiculo = veiculo.Placa,
                            Observacoes = movimentacao.Observacoes
                        };

            if (!query.Any())
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
            }

            foreach (var item in query)
            {
                dt.Rows.Add(item.DataMovimentacao, item.TipoMovimentacao, item.FazendaOrigem, item.FazendaDestino, item.QuantidadeCaixas, item.Motorista, item.Veiculo, item.Observacoes);
            }

            dataGridViewMovimentacaoCaixas.DataSource = dt;

            dataGridViewMovimentacaoCaixas.RowHeadersVisible = false;

            dataGridViewMovimentacaoCaixas.Columns["Data Movimentação"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Tipo Movimentação"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Fazenda Origem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Fazenda Destino"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Quantidade de Caixas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Veículo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewMovimentacaoCaixas.Columns["Observações"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridViewMovimentacaoCaixas.Refresh();

            lblQtdCaixas.Text = $"Quantidade de caixas total: {_caixaService.RetornaTotalDeCaixas().Conteudo}";
            lblQtdCaixas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        }
    }
}
