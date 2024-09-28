using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarFazendas : Form
    {
        private FazendaService _fazendaService;
        public ScreenCriarFazendas()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddFazenda_Click(object sender, EventArgs e)
        {
            float hectare = 0;
            var isBarracao = chkIsBarracao.CheckState == CheckState.Checked;

            if (!isBarracao)
            {
                try
                {
                    hectare = Convert.ToSingle(txtAreaPlantada.Text.Trim());
                    if (hectare <= 0)
                    {
                        MessageBox.Show("Hectare deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Por favor, insira um valor válido para a área plantada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("O valor inserido é muito grande ou muito pequeno para um float.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var resultado = _fazendaService.CriarFazenda(txtNomeFaz.Text, txtLocalizacao.Text, hectare, isBarracao);

            if (resultado.Sucesso)
            {
                MessageBox.Show("Fazenda criada com sucesso!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Erro: " + resultado.MensagemErro);
            }
        }

        private void txtAreaPlantada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void chkIsBarracao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsBarracao.Checked)
            {
                txtAreaPlantada.Visible = false;
                label4.Visible = false;
            } else
            {
                txtAreaPlantada.Visible = true;
                label4.Visible = true;
            }
        }
    }
}
