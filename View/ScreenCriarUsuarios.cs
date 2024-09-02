using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenCriarUsuarios : Form
    {
        private UsuarioService _usuarioService;
        public ScreenCriarUsuarios()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            
            var resultado = _usuarioService.InserirUsuario(txtNomeCompleto.Text, txtUsername.Text, txtSenha.Text, txtRepetirSenha.Text);

            if (resultado.Sucesso)
            {
                MessageBox.Show("Usuário criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
