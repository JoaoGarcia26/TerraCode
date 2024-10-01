using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Fazendas
{
    public partial class ScreenCriarSafra : Form
    {
        private readonly SafraService _safraService;
        public ScreenCriarSafra()
        {
            InitializeComponent();
            _safraService = new SafraService();
        }

        private void btnAddSafra_Click(object sender, EventArgs e)
        {
            var resultado = _safraService.CriarSafra(txtNomeSafra.Text, int.Parse(txtAno.Text));

            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
