using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.AlhoDaRoca
{
    public partial class ScreenRegistrarEntrada : Form
    {
        private MotoristaService _motoristaService;
        private VeiculoService _veiculoService;
        private FazendaService _fazendaService;
        private PLService _plService;
        private MovimentacaoProducaoRocaService _movimentacaoProducaoRocaService;

        public ScreenRegistrarEntrada()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
            _motoristaService = new MotoristaService();
            _plService = new PLService();
            _veiculoService = new VeiculoService();
            _movimentacaoProducaoRocaService = new MovimentacaoProducaoRocaService();
            CarregaFormularios();
        }


        public void CarregaFormularios()
        {
            comboFazenda.Items.Clear();
            comboMotorista.Items.Clear();
            comboPL.Items.Clear();
            comboVeiculos.Items.Clear();
            txtPesoTotal.Text = "0";
            txtQtdCaixas.Text = "0";

            var resultFazendas = _fazendaService.RetornaTodasFazendas();
            var resultMotorista = _motoristaService.RetornaTodosMotoristas();
            
            if (resultFazendas.Sucesso)
            {
                foreach (var item in resultFazendas.Conteudo)
                {
                    comboFazenda.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show(resultFazendas.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (resultMotorista.Sucesso)
            {
                foreach (var item in resultMotorista.Conteudo)
                {
                    comboMotorista.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show(resultMotorista.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboFazenda_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var resultPl = _plService.RetornaTodosPlDaFazenda(comboFazenda.SelectedItem.ToString());

            comboPL.Items.Clear();

            if (resultPl.Sucesso)
            {
                foreach (var item in resultPl.Conteudo)
                {
                    comboPL.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show(resultPl.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboMotorista_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var resultVeiculos = _veiculoService.RetornaTodosVeiculosPeloMotorista(comboMotorista.SelectedItem.ToString());

            comboVeiculos.Items.Clear();

            if (resultVeiculos.Sucesso)
            {
                foreach (var item in resultVeiculos.Conteudo)
                {
                    comboVeiculos.Items.Add(item.Placa);
                }
            }
            else
            {
                MessageBox.Show(resultVeiculos.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            var motorista = _motoristaService.RetornaMotoristaPeloNome(comboMotorista.SelectedItem.ToString());
            var veiculo = _veiculoService.RetornaVeiculoPelaPlaca(comboVeiculos.SelectedItem.ToString());
            var fazenda = _fazendaService.RetornaFazendaPeloNome(comboFazenda.SelectedItem.ToString());
            var pl = _plService.RetornaPlPeloIDeFazenda(int.Parse(comboPL.SelectedItem.ToString()), fazenda.Conteudo.Nome);

            var resultadoMovimentacao = _movimentacaoProducaoRocaService.CriarMovimentacao(motorista.Conteudo.Id, veiculo.Conteudo.Id, fazenda.Conteudo.Id
                , pl.Conteudo.Id, float.Parse(txtPesoTotal.Text), int.Parse(txtQtdCaixas.Value.ToString()), pickerDataEntrada.Value);

            if (resultadoMovimentacao.Sucesso)
            {
                MessageBox.Show("Movimentação cadastrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show(resultadoMovimentacao.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
