using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCaixas : Form
    {
        private ScreenRegistrarCaixas _formRegistrarCaixas;

        private FazendaService _fazendaService;
        private MotoristaService _motoristaService;
        private VeiculoService _veiculoService;
        private MovimentacaoCaixasService _movimentacaoService;

        public ScreenCaixas()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
            _motoristaService = new MotoristaService();
            _veiculoService = new VeiculoService();
            _movimentacaoService = new MovimentacaoCaixasService();
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
            var resultadoMovimentacao = _movimentacaoService.ObterTodasMovimentacoes();

            if (!resultadoMovimentacao.Sucesso)
            {
                MessageBox.Show("Erro ao carregar movimentações: " + resultadoMovimentacao.MensagemErro);
                return;
            }

            var movimentacoes = resultadoMovimentacao.Conteudo;

            var dt = new System.Data.DataTable();
            dt.Columns.Add("Data Movimentação", typeof(DateTime));
            dt.Columns.Add("Tipo Movimentação", typeof(string));
            dt.Columns.Add("Fazenda Origem", typeof(string));
            dt.Columns.Add("Fazenda Destino", typeof(string));
            dt.Columns.Add("Quantidade de Caixas", typeof(int));
            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("Veículo", typeof(string));
            dt.Columns.Add("Observações", typeof(string));

            foreach (var movimentacao in movimentacoes)
            {
                var origem = _fazendaService.RetornaFazendaPeloId(movimentacao.FazendaOrigemId);
                var destino = _fazendaService.RetornaFazendaPeloId(movimentacao.FazendaDestinoId);
                var motorista = _motoristaService.RetornaMotoristaPeloId((int)movimentacao.MotoristaId);
                var veiculo = _veiculoService.RetornaVeiculoPeloId((int)movimentacao.VeiculoId);

                dt.Rows.Add(
                    movimentacao.DataMovimentacao,
                    movimentacao.TipoMovimentacao,
                    origem.Conteudo?.Nome,
                    destino.Conteudo?.Nome,
                    movimentacao.QuantidadeCaixas,
                    motorista.Conteudo?.Nome,
                    veiculo.Conteudo?.Placa,
                    movimentacao.Observacoes);
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
        }

        private void ScreenCaixas_Activated(object sender, EventArgs e)
        {
            ScreenCaixas_Load(sender, e);
        }
    }
}
