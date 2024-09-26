using System;
using System.Windows.Forms;
using TerraCode.View.AlhoDaRoca;
using TerraCode.View.Classificacao;

namespace TerraCode.View
{
    public partial class MenuGeral : Form
    {
        private ScreenUsuarios _formUsuarios;
        private ScreenCriarUsuarios _formCriarUsuarios;
        private ScreenFazendas _formFazendas;
        private ScreenCriarFazendas _formCriarFazendas;
        private ScreenPls _formPls;
        private ScreenCriarPL _formCriarPl;
        private ScreenMotorista _formMotorista;
        private ScreenCriarMotorista _formCriarMotorista;
        private ScreenVeiculos _formVeiculos;
        private ScreenCriarVeiculos _formCriarVeiculos;
        private ScreenCaixas _formCaixas;
        private ScreenRegistrarCaixas _formRegistrarCaixas;
        private ScreenAlhoDaRoca _formAlhoDaRoca;
        private ScreenRegistrarEntrada _formRegistraAlhoDaRoca;
        private ScreenPreClassificacao _formClassificacao;
        private ScreenRegistrarClassificacao _formRegistrarClassificacao;

        public MenuGeral()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            if (_formUsuarios == null || _formUsuarios.IsDisposed)
            {
                _formUsuarios = new ScreenUsuarios();
            }
            _formUsuarios.ShowDialog();
        }

        private void MenuGeral_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnFazenda_Click(object sender, EventArgs e)
        {
            if (_formFazendas == null || _formFazendas.IsDisposed)
            {
                _formFazendas = new ScreenFazendas();
            }
            _formFazendas.ShowDialog();
        }

        private void btnPls_Click(object sender, EventArgs e)
        {
            if (_formPls == null || _formPls.IsDisposed)
            {
                _formPls = new ScreenPls();
            }
            _formPls.ShowDialog();
        }

        private void adicionarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formCriarUsuarios == null || _formCriarUsuarios.IsDisposed)
            {
                _formCriarUsuarios = new ScreenCriarUsuarios();
            }
            _formCriarUsuarios.ShowDialog();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formCriarFazendas == null || _formCriarFazendas.IsDisposed)
            {
                _formCriarFazendas = new ScreenCriarFazendas();
            }
            _formCriarFazendas.ShowDialog();
        }

        private void listarTodasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formFazendas == null || _formFazendas.IsDisposed)
            {
                _formFazendas = new ScreenFazendas();
            }
            _formFazendas.ShowDialog();
        }

        private void cadastrarPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formCriarPl == null || _formCriarPl.IsDisposed)
            {
                _formCriarPl = new ScreenCriarPL();
            }
            _formCriarPl.ShowDialog();
        }

        private void listarPLsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formPls == null || _formPls.IsDisposed)
            {
                _formPls = new ScreenPls();
            }
            _formPls.ShowDialog();
        }

        private void listarUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formUsuarios == null || _formUsuarios.IsDisposed)
            {
                _formUsuarios = new ScreenUsuarios();
            }
            _formUsuarios.ShowDialog();
        }

        private void btnMotoristas_Click(object sender, EventArgs e)
        {
            if (_formMotorista == null || _formMotorista.IsDisposed)
            {
                _formMotorista = new ScreenMotorista();
            }
            _formMotorista.ShowDialog();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_formCriarMotorista == null || _formCriarMotorista.IsDisposed)
            {
                _formCriarMotorista = new ScreenCriarMotorista();
            }
            _formCriarMotorista.ShowDialog();
        }

        private void listarTodosOsMotoristasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formMotorista == null || _formMotorista.IsDisposed)
            {
                _formMotorista = new ScreenMotorista();
            }
            _formMotorista.ShowDialog();
        }

        private void btnVeiculos_Click(object sender, EventArgs e)
        {
            if (_formVeiculos == null || _formVeiculos.IsDisposed)
            {
                _formVeiculos = new ScreenVeiculos();
            }
            _formVeiculos.ShowDialog();
        }

        private void cadastrarVeículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_formCriarVeiculos == null || _formCriarVeiculos.IsDisposed)
            {
                _formCriarVeiculos = new ScreenCriarVeiculos();
            }
            _formCriarVeiculos.ShowDialog();
        }

        private void btnCaixas_Click(object sender, EventArgs e)
        {
            if (_formCaixas == null || _formCaixas.IsDisposed)
            {
                _formCaixas = new ScreenCaixas();
            }
            _formCaixas.ShowDialog();
        }

        private void btnAlhoRoca_Click(object sender, EventArgs e)
        {
            if (_formAlhoDaRoca == null || _formAlhoDaRoca.IsDisposed)
            {
                _formAlhoDaRoca = new ScreenAlhoDaRoca();
            }
            _formAlhoDaRoca.ShowDialog();
        }

        private void btnClassificacao_Click(object sender, EventArgs e)
        {
            if (_formClassificacao == null || _formClassificacao.IsDisposed)
            {
                _formClassificacao = new ScreenPreClassificacao();
            }
            _formClassificacao.ShowDialog();
        }
    }
}
