using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarPL : Form
    {
        private PLService _plService;
        private FazendaService _fazendaService;
        private SafraService _safraService;
        public ScreenCriarPL()
        {
            InitializeComponent();
            _plService = new PLService();
            _fazendaService = new FazendaService();
            _safraService = new SafraService();
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
                var resultado = _plService.CriarPL(txtNomePl.Text, comboNomeFaz.SelectedItem?.ToString(), txtDataPlantio.Text, hectare, txtObservacoes.Text, comboSafra.SelectedItem.ToString());

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
            var resultadoFazenda = _fazendaService.RetornaTodasFazendas();
            var resultadoSafra = _safraService.RetornaTodasSafras();

            if (resultadoFazenda.Sucesso)
            {
                foreach (var item in resultadoFazenda.Conteudo) 
                {
                    comboNomeFaz.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show("Não há fazendas cadastradas.");
            }
            if (resultadoSafra.Sucesso)
            {
                foreach (var item in resultadoSafra.Conteudo)
                {
                    comboSafra.Items.Add(item.Nome);
                }
            }
            else
            {
                MessageBox.Show("Não há safras cadastradas.");
            }
        }
    }
}
