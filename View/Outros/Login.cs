using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class Login : Form
    {
        private UsuarioService _usuarioService;
        private MenuGeral formMenuGeral;
        public Login()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var resultado = _usuarioService.ValidarLogin(txtUsernameLog.Text, txtPassLog.Text);

            if (resultado.Sucesso)
            {
                formMenuGeral = new MenuGeral();
                formMenuGeral.Visible = true;
                this.Visible = false;
            } else
            {
                MessageBox.Show(null, resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
