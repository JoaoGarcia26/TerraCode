using System;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Estoque.Movimentacoes
{
    public partial class ScreenEditarMovimentacao : Form
    {
        private EstoqueService _estoqueService;
        private FazendaService _fazendaService;
        private PLService _plService;

        private string numDoc;
        private int idMovimentacao;
        private int FazendaId;
        private int PLId;
        public ScreenEditarMovimentacao(string numDoc)
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
            _fazendaService = new FazendaService();
            _plService = new PLService();
            this.numDoc = numDoc;
        }

        private void ScreenEditarMovimentacao_Load(object sender, EventArgs e)
        {
            CarregaCampos();
            txtData.Enabled = false;
            txtNumDoc.Enabled = false;
            txtEvento.Enabled = false;
        }

        public void CarregaCampos()
        {
            var resultadoMovimentacao = _estoqueService.RetornaEstoquePorNumDoc(numDoc);
            var fazenda = _fazendaService.RetornaFazendaPeloId(resultadoMovimentacao.Conteudo.FazendaId);
            var pl = _plService.RetornaPlPeloID(resultadoMovimentacao.Conteudo.PLId);

            if (resultadoMovimentacao.Sucesso)
            {
                idMovimentacao = resultadoMovimentacao.Conteudo.ID;
                txtNumDoc.Text = resultadoMovimentacao.Conteudo.DocNr;
                txtData.Text = resultadoMovimentacao.Conteudo.Data.ToShortDateString();
                txtEvento.Text = resultadoMovimentacao.Conteudo.Evento;
                lblFazenda.Text = fazenda.Conteudo.Nome;
                lblPL.Text = $"Plantio: {pl.Conteudo.Nome}";

                FazendaId = fazenda.Conteudo.Id;
                PLId = pl.Conteudo.Id;

                numExtra8.Value = (decimal)resultadoMovimentacao.Conteudo.Extra8;
                numExtra7.Value = (decimal)resultadoMovimentacao.Conteudo.Extra7;
                numExtra6.Value = (decimal)resultadoMovimentacao.Conteudo.Extra6;
                numExtra5.Value = (decimal)resultadoMovimentacao.Conteudo.Extra5;
                numExtra4.Value = (decimal)resultadoMovimentacao.Conteudo.Extra4;

                numCat8.Value = (decimal)resultadoMovimentacao.Conteudo.Cat8;
                numCat7.Value = (decimal)resultadoMovimentacao.Conteudo.Cat7;
                numCat6.Value = (decimal)resultadoMovimentacao.Conteudo.Cat6;
                numCat5.Value = (decimal)resultadoMovimentacao.Conteudo.Cat5;
                numCat4.Value = (decimal)resultadoMovimentacao.Conteudo.Cat4;

                numComercial8.Value = (decimal)resultadoMovimentacao.Conteudo.Comercial8;
                numComercial7.Value = (decimal)resultadoMovimentacao.Conteudo.Comercial7;
                numComercial6.Value = (decimal)resultadoMovimentacao.Conteudo.Comercial6;
                numComercial5.Value = (decimal)resultadoMovimentacao.Conteudo.Comercial5;
                numComercial4.Value = (decimal)resultadoMovimentacao.Conteudo.Comercial4;

                numEspecial8.Value = (decimal)resultadoMovimentacao.Conteudo.Especial8;
                numEspecial7.Value = (decimal)resultadoMovimentacao.Conteudo.Especial7;
                numEspecial6.Value = (decimal)resultadoMovimentacao.Conteudo.Especial6;
                numEspecial5.Value = (decimal)resultadoMovimentacao.Conteudo.Especial5;
                numEspecial4.Value = (decimal)resultadoMovimentacao.Conteudo.Especial4;

                numEscovado8.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado8;
                numEscovado7.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado7;
                numEscovado6.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado6;
                numEscovado5.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado5;
                numEscovado4.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado4;

                numEscovado3.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado3;
                numIndustrial.Value = (decimal)resultadoMovimentacao.Conteudo.Industrial20kg;
                num2_3.Value = (decimal)resultadoMovimentacao.Conteudo.Escovado2_3;
                numDente.Value = (decimal)resultadoMovimentacao.Conteudo.Dente20kg;
                numBorrado.Value = (decimal)resultadoMovimentacao.Conteudo.Borrado20kg;
            } else
            {
                MessageBox.Show(resultadoMovimentacao.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Model.Estoque estoqueAtualizado = new Model.Estoque
            {
                ID = idMovimentacao,
                Data = DateTime.Parse(txtData.Text),
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
                FazendaId = this.FazendaId,
                PLId = this.PLId
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
