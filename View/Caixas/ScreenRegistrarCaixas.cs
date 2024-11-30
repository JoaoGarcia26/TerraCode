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
        private MovimentacaoCaixasService _movimentacaoCaixasService;
        public ScreenRegistrarCaixas()
        {
            InitializeComponent();
            _motoristaService = new MotoristaService();
            _veiculoService = new VeiculoService();
            _fazendaService = new FazendaService();
            _movimentacaoCaixasService = new MovimentacaoCaixasService();
        }

        private void ScreenRegistrarCaixas_Load(object sender, EventArgs e)
        {
            comboFazDestino.Items.Clear();
            comboBarracao.Items.Clear();
            comboMotorista.Items.Clear();

            var listaMotoristas = _motoristaService.RetornaTodosMotoristas();
            foreach (var item in listaMotoristas.Conteudo)
            {
                comboMotorista.Items.Add(item.Nome);
            }

            var listaFazendas = _fazendaService.RetornaTodasFazendas();
            foreach (var item in listaFazendas.Conteudo)
            {
                comboFazDestino.Items.Add(item.Nome);
            }

            var listaBarracoes = _fazendaService.RetornaSomenteBarracoes();
            foreach (var item in listaBarracoes.Conteudo)
            {
                comboBarracao.Items.Add(item.Nome);
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
            var resultado = _movimentacaoCaixasService.RegistrarSaidaMovimentacaoCaixas(dataEnvio.Value, (int)txtQtdCaixas.Value, comboBarracao.Text, comboFazDestino.Text,
                comboMotorista.Text, comboVeiculos.Text, txtObservacoes.Text);

            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
