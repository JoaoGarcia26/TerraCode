using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarVeiculos : Form
    {
        private VeiculoService _veiculoService;
        public ScreenCriarVeiculos()
        {
            InitializeComponent();
            _veiculoService = new VeiculoService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddVeiculo_Click(object sender, EventArgs e)
        {
            var resultado = _veiculoService.AdicionarVeiculo(comboMotorista.Text, comboTipoVeiculo.Text, txtPlaca.Text);
            
            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();            
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private void ScreenCriarVeiculos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbTerraCodeDataSet.Motorista'. Você pode movê-la ou removê-la conforme necessário.
            this.motoristaTableAdapter.Fill(this.dbTerraCodeDataSet.Motorista);

        }
    }
}
