using System;
using System.Windows.Forms;
using TerraCode.Model;
using TerraCode.Service;

namespace TerraCode.View.Estoque.Movimentacoes
{
    public partial class ScreenEditarMovimentacao : Form
    {
        private EstoqueService _estoqueService;
        private string numDoc;
        private int id;
        public ScreenEditarMovimentacao(string numDoc)
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
            this.numDoc = numDoc;
        }

        private void ScreenEditarMovimentacao_Load(object sender, EventArgs e)
        {
            CarregaCampos();
            data.Enabled = false;
        }

        public void CarregaCampos()
        {
            var resultadoMovimentacao = _estoqueService.RetornaEstoquePorNumDoc(numDoc);

            if (resultadoMovimentacao.Sucesso)
            {
                this.id = resultadoMovimentacao.Conteudo.ID;
                txtNumDoc.Text = resultadoMovimentacao.Conteudo.DocNr;
                data.Value = resultadoMovimentacao.Conteudo.Data;
                txtEvento.Text = resultadoMovimentacao.Conteudo.Evento;

                numExtra8.Value = resultadoMovimentacao.Conteudo.Extra8;
                numExtra7.Value = resultadoMovimentacao.Conteudo.Extra7;
                numExtra6.Value = resultadoMovimentacao.Conteudo.Extra6;
                numExtra5.Value = resultadoMovimentacao.Conteudo.Extra5;
                numExtra4.Value = resultadoMovimentacao.Conteudo.Extra4;

                numCat8.Value = resultadoMovimentacao.Conteudo.Cat8;
                numCat7.Value = resultadoMovimentacao.Conteudo.Cat7;
                numCat6.Value = resultadoMovimentacao.Conteudo.Cat6;
                numCat5.Value = resultadoMovimentacao.Conteudo.Cat5;
                numCat4.Value = resultadoMovimentacao.Conteudo.Cat4;

                numComercial8.Value = resultadoMovimentacao.Conteudo.Comercial8;
                numComercial7.Value = resultadoMovimentacao.Conteudo.Comercial7;
                numComercial6.Value = resultadoMovimentacao.Conteudo.Comercial6;
                numComercial5.Value = resultadoMovimentacao.Conteudo.Comercial5;
                numComercial4.Value = resultadoMovimentacao.Conteudo.Comercial4;

                numEspecial8.Value = resultadoMovimentacao.Conteudo.Especial8;
                numEspecial7.Value = resultadoMovimentacao.Conteudo.Especial7;
                numEspecial6.Value = resultadoMovimentacao.Conteudo.Especial6;
                numEspecial5.Value = resultadoMovimentacao.Conteudo.Especial5;
                numEspecial4.Value = resultadoMovimentacao.Conteudo.Especial4;

                numEscovado8.Value = resultadoMovimentacao.Conteudo.Escovado8;
                numEscovado7.Value = resultadoMovimentacao.Conteudo.Escovado7;
                numEscovado6.Value = resultadoMovimentacao.Conteudo.Escovado6;
                numEscovado5.Value = resultadoMovimentacao.Conteudo.Escovado5;
                numEscovado4.Value = resultadoMovimentacao.Conteudo.Escovado4;

                numEscovado3.Value = resultadoMovimentacao.Conteudo.Escovado3;
                numIndustrial.Value = resultadoMovimentacao.Conteudo.Industrial20kg;
                num2_3.Value = resultadoMovimentacao.Conteudo.Escovado2_3;
                numDente.Value = resultadoMovimentacao.Conteudo.Dente20kg;
                numBorrado.Value = resultadoMovimentacao.Conteudo.Borrado20kg;
            } else
            {
                MessageBox.Show(resultadoMovimentacao.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Model.Estoque estoqueAtualizado = new Model.Estoque
            {
                ID = id,
                Data = data.Value,
                DocNr = numDoc,
                Evento = txtEvento.Text,

                Extra8 = (int)numExtra8.Value,
                Extra7 = (int)numExtra7.Value,
                Extra6 = (int)numExtra6.Value,
                Extra5 = (int)numExtra5.Value,
                Extra4 = (int)numExtra4.Value,

                Cat8 = (int)numCat8.Value,
                Cat7 = (int)numCat7.Value,
                Cat6 = (int)numCat6.Value,
                Cat5 = (int)numCat5.Value,
                Cat4 = (int)numCat4.Value,

                Comercial8 = (int)numComercial8.Value,
                Comercial7 = (int)numComercial7.Value,
                Comercial6 = (int)numComercial6.Value,
                Comercial5 = (int)numComercial5.Value,
                Comercial4 = (int)numComercial4.Value,

                Especial8 = (int)numEspecial8.Value,
                Especial7 = (int)numEspecial7.Value,
                Especial6 = (int)numEspecial6.Value,
                Especial5 = (int)numEspecial5.Value,
                Especial4 = (int)numEspecial4.Value,

                Escovado8 = (int)numEscovado8.Value,
                Escovado7 = (int)numEscovado7.Value,
                Escovado6 = (int)numEscovado6.Value,
                Escovado5 = (int)numEscovado5.Value,
                Escovado4 = (int)numEscovado4.Value,

                Escovado3 = (int)numEscovado3.Value,
                Industrial20kg = (int)numIndustrial.Value,
                Escovado2_3 = (int)num2_3.Value,
                Dente20kg = (int)numDente.Value,
                Borrado20kg = (int)numBorrado.Value,
            };

            var resultado = _estoqueService.AtualizarEstoque(estoqueAtualizado);

            if (resultado.Sucesso)
            {
                MessageBox.Show(resultado.MensagemErro, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            } else
            {
                MessageBox.Show(resultado.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
