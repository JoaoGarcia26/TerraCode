using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarMotorista : Form
    {
        private MotoristaService _motoristaService;
        public ScreenCriarMotorista()
        {
            InitializeComponent();
            _motoristaService = new MotoristaService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddPl_Click(object sender, EventArgs e)
        {
            var resultado = _motoristaService.CriarMotorista(txtNomeMotorista.Text, txtEndereco.Text, txtCNH.Text, txtCPF.Text);

            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ScreenCriarMotorista_Load(object sender, EventArgs e)
        {

        }

        private void txtCPF_Click(object sender, EventArgs e)
        {
            txtCPF.Clear();
        }
    }
}
