using System;
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
        private MovimentacaoCaixasService _movimentacaoCaixasService;

        public ScreenRegistrarEntrada()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
            _motoristaService = new MotoristaService();
            _plService = new PLService();
            _veiculoService = new VeiculoService();
            _movimentacaoProducaoRocaService = new MovimentacaoProducaoRocaService();
            _movimentacaoCaixasService = new MovimentacaoCaixasService();
            CarregaFormularios();
        }

        public void CarregaFormularios()
        {
            comboFazenda.Items.Clear();
            comboMotorista.Items.Clear();
            comboBarracao.Items.Clear();
            comboPL.Items.Clear();
            comboVeiculos.Items.Clear();
            txtPesoTotal.Text = "0";
            txtQtdCaixas.Text = "0";

            var resultFazendas = _fazendaService.RetornaTodasFazendas();
            var resultMotorista = _motoristaService.RetornaTodosMotoristas();
            var resultBarracoes = _fazendaService.RetornaSomenteBarracoes();
            
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

            if (resultBarracoes.Sucesso)
            {
                foreach (var item in resultBarracoes.Conteudo)
                {
                    comboBarracao.Items.Add(item.Nome);
                }
            }
            else
            {
                MessageBox.Show(resultFazendas.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (comboMotorista.SelectedItem == null || string.IsNullOrWhiteSpace(comboMotorista.SelectedItem.ToString()))
            {
                MessageBox.Show("O campo 'Motorista' é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboVeiculos.SelectedItem == null || string.IsNullOrWhiteSpace(comboVeiculos.SelectedItem.ToString()))
            {
                MessageBox.Show("O campo 'Veículo' é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboFazenda.SelectedItem == null || string.IsNullOrWhiteSpace(comboFazenda.SelectedItem.ToString()))
            {
                MessageBox.Show("O campo 'Fazenda' é obrigatório.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var motorista = _motoristaService.RetornaMotoristaPeloNome(comboMotorista.SelectedItem.ToString());
            if (motorista == null || !motorista.Sucesso || motorista.Conteudo == null)
            {
                MessageBox.Show("Erro ao buscar motorista.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculo = _veiculoService.RetornaVeiculoPelaPlaca(comboVeiculos.SelectedItem.ToString());
            if (veiculo == null || !veiculo.Sucesso || veiculo.Conteudo == null)
            {
                MessageBox.Show("Erro ao buscar veículo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fazenda = _fazendaService.RetornaFazendaPeloNome(comboFazenda.SelectedItem.ToString());
            if (fazenda == null || !fazenda.Sucesso || fazenda.Conteudo == null)
            {
                MessageBox.Show("Erro ao buscar fazenda.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pl = _plService.RetornaPlPeloNomeeFazenda(comboPL.SelectedItem.ToString(), fazenda.Conteudo.Nome);
            if (pl == null || !pl.Sucesso || pl.Conteudo == null)
            {
                MessageBox.Show("Erro ao buscar PL.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var resultadoMovimentacao = _movimentacaoProducaoRocaService.CriarMovimentacao(
                motorista.Conteudo.Id,
                veiculo.Conteudo.Id,
                fazenda.Conteudo.Id,
                pl.Conteudo.Id,
                float.Parse(txtPesoTotal.Text),
                int.Parse(txtQtdCaixas.Value.ToString()),
                dataEntrada.Value
            );

            if (!resultadoMovimentacao.Sucesso)
            {
                MessageBox.Show(resultadoMovimentacao.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(resultadoMovimentacao.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
