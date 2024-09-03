using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenRegistrarCaixas : Form
    {
        private MotoristaService _motoristaService;
        private VeiculoService _veiculoService;
        private FazendaService _fazendaService;
        private PLService _plService;
        private MovimentacaoCaixasService _movimentacaoCaixasService;
        private CaixaService _caixaService;
        public ScreenRegistrarCaixas()
        {
            InitializeComponent();
            _motoristaService = new MotoristaService();
            _veiculoService = new VeiculoService();
            _plService = new PLService();
            _fazendaService = new FazendaService();
            _movimentacaoCaixasService = new MovimentacaoCaixasService();
            _caixaService = new CaixaService();
        }

        private void ScreenRegistrarCaixas_Load(object sender, EventArgs e)
        {
            comboFazDestino.Items.Clear();
            comboFazOrigem.Items.Clear();
            comboMotorista.Items.Clear();

            var listaMotoristas = _motoristaService.RetornaTodosMotoristas();
            foreach (var item in listaMotoristas.Conteudo)
            {
                comboMotorista.Items.Add(item.Nome);
            }

            var listaFazendas = _fazendaService.RetornaTodasFazendas();
            foreach (var item in listaFazendas.Conteudo)
            {
                comboFazOrigem.Items.Add(item.Nome);
                comboFazDestino.Items.Add(item.Nome);
            }

            lblQtdCaixas.Text = $"Quantidade de caixas total: {_caixaService.RetornaTotalDeCaixas().Conteudo}";
        }

        private void comboFazDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboPL.Items.Clear();
            var listaPl = _plService.RetornaTodosPlDaFazenda(comboFazDestino.Text);
            foreach (var item in listaPl.Conteudo)
            {
                comboPL.Items.Add(item.Nome);
            }
        }

        private void comboMotorista_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboVeiculos.Items.Clear();
            var listaVeiculos = _veiculoService.RetornaTodosVeiculosPeloMotorista(comboMotorista.Text);
            foreach (var item in listaVeiculos.Conteudo)
            {
                comboVeiculos.Items.Add(item.Placa);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboStatus.Text == "Entrada")
            {
                var resultado = _movimentacaoCaixasService.RegistrarEntradaMovimentacaoCaixas((int)txtQtdCaixas.Value, comboFazDestino.Text, comboFazOrigem.Text,
                    comboMotorista.Text, comboPL.Text, comboVeiculos.Text, txtObservacoes.Text);

                if (resultado.Sucesso)
                {
                    MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (comboStatus.Text == "Saída")
            {
                var resultado = _movimentacaoCaixasService.RegistrarSaidaMovimentacaoCaixas((int)txtQtdCaixas.Value, comboFazDestino.Text, comboFazOrigem.Text,
                    comboMotorista.Text, comboVeiculos.Text, txtObservacoes.Text);

                if (resultado.Sucesso)
                {
                    MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
