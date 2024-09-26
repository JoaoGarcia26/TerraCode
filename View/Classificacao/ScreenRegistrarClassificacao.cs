using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Classificacao
{
    public partial class ScreenRegistrarClassificacao : Form
    {
        private PreClassificacaoService _preClassificacaoService;
        private FazendaService _fazendaService;
        private PLService _plService;
        public ScreenRegistrarClassificacao()
        {
            _preClassificacaoService = new PreClassificacaoService();
            _fazendaService = new FazendaService();
            _plService = new PLService();
            InitializeComponent();
        }

        private void ScreenRegistrarClassificacao_Load(object sender, System.EventArgs e)
        {
            var resultFazendas = _fazendaService.RetornaTodasFazendas();

            comboFazenda.Items.Clear();

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
            }
            else
            {
                MessageBox.Show(resultPl.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtPesoAlho08.Text, out float pesoAlho08))
            {
                MessageBox.Show("Valor inválido para Peso Alho 8.");
                return;
            }

            if (!float.TryParse(txtPesoAlho07.Text, out float pesoAlho07))
            {
                MessageBox.Show("Valor inválido para Peso Alho 7.");
                return;
            }

            if (!float.TryParse(txtPesoAlho06.Text, out float pesoAlho06))
            {
                MessageBox.Show("Valor inválido para Peso Alho 6.");
                return;
            }

            if (!float.TryParse(txtPesoAlho05.Text, out float pesoAlho05))
            {
                MessageBox.Show("Valor inválido para Peso Alho 5.");
                return;
            }

            if (!float.TryParse(txtPesoAlho04.Text, out float pesoAlho04))
            {
                MessageBox.Show("Valor inválido para Peso Alho 4.");
                return;
            }

            if (!float.TryParse(txtPesoAlho03.Text, out float pesoAlho03))
            {
                MessageBox.Show("Valor inválido para Peso Alho 3.");
                return;
            }

            if (!float.TryParse(txtPesoTotalIndustrial.Text, out float pesoIndustrial))
            {
                MessageBox.Show("Valor inválido para Peso Industrial.");
                return;
            }

            if (!float.TryParse(txtPesoDescarte.Text, out float pesoDescarte))
            {
                MessageBox.Show("Valor inválido para Descarte.");
                return;
            }

            if (!float.TryParse(txtPesoTotalClassificado.Text, out float pesoTotalClassificado))
            {
                MessageBox.Show("Valor inválido para Total Classificado.");
                return;
            }

            var resultado = _preClassificacaoService.CriarPreClassificacao(
                pickerDataClassificacao.Value,
                comboFazenda.SelectedItem.ToString(),
                comboPL.SelectedItem.ToString(),
                pesoAlho08,
                pesoAlho07,
                pesoAlho06,
                pesoAlho05,
                pesoAlho04,
                pesoAlho03,
                pesoIndustrial,
                pesoDescarte,
                pesoTotalClassificado
            );

            if (resultado.Sucesso)
            {
                MessageBox.Show("Pré-classificação registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
