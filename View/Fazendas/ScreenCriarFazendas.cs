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
            bool isBarracao = chkIsBarracao.CheckState == CheckState.Checked;

            var resultado = _fazendaService.CriarFazenda(txtNomeFaz.Text, txtLocalizacao.Text, isBarracao);

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
    }
}
