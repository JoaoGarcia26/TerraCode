using System;
using System.Windows.Forms;
using TerraCode.Model;
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
            float hectare;
            if (float.TryParse(txtAreaPlantada.Text, out hectare))
            {
                var resultado = _fazendaService.CriarFazenda(txtNomeFaz.Text, txtLocalizacao.Text, hectare);

                if (resultado.Sucesso)
                {
                    MessageBox.Show("Fazenda criada com sucesso!");
                    this.Dispose(true);
                }
                else
                {
                    MessageBox.Show("Erro: " + resultado.MensagemErro);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um valor válido para a área plantada.");
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
    }
}
