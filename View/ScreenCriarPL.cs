using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarPL : Form
    {
        private PLService _plService;
        private FazendaService _fazendaService;
        public ScreenCriarPL()
        {
            InitializeComponent();
            _plService = new PLService();
            _fazendaService = new FazendaService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddPl_Click(object sender, EventArgs e)
        {
            float hectare;
            if (float.TryParse(txtAreaPlantada2.Text, out hectare))
            {
                var resultado = _plService.CriarPL(txtNomePl.Text, comboNomeFaz.SelectedItem?.ToString(), txtDataPlantio.Text, hectare, txtObservacoes.Text);

                if (resultado.Sucesso)
                {
                    MessageBox.Show("PL criado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void ScreenCriarPL_Load(object sender, EventArgs e)
        {
            var resultado = _fazendaService.RetornaTodasFazendas();

            if (resultado.Sucesso)
            {
                foreach (var item in resultado.Conteudo) 
                {
                    comboNomeFaz.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show("Não há fazendas cadastradas.");
            }
        }
    }
}
