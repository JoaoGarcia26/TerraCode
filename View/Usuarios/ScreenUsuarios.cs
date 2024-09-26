using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenUsuarios : Form
    {
        private UsuarioService _usuarioService;
        private ScreenCriarUsuarios _screenCriarUsuarios;
        public ScreenUsuarios()
        {
            InitializeComponent();
            _usuarioService = new UsuarioService();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dbTerraCodeDataSet.Usuarios'. Você pode movê-la ou removê-la conforme necessário.
            this.usuariosTableAdapter.Fill(this.dbTerraCodeDataSet.Usuarios);
            dataGridView1.RowHeadersVisible = false;

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _screenCriarUsuarios = new ScreenCriarUsuarios();
            _screenCriarUsuarios.Visible = true;
        }

        private void ScreenUsuarios_Activated(object sender, EventArgs e)
        {
            this.usuariosTableAdapter.Fill(this.dbTerraCodeDataSet.Usuarios);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
