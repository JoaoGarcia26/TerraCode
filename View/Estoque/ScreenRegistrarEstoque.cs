using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Estoque
{
    public partial class ScreenRegistrarEstoque : Form
    {
        private EstoqueService _estoqueService;
        private PLService _plService;
        private FazendaService _fazendaService;
        public ScreenRegistrarEstoque()
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
            _plService = new PLService();
            _fazendaService = new FazendaService();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVisibleFalse_Primarias();
            SetVisibleFalse_Secundarias();

            switch (comboTipoAlho.SelectedItem.ToString())
            {
                case "8":
                    SetVisibleTrue_Primarias();
                    break;
                case "7":
                    SetVisibleTrue_Primarias();
                    break;
                case "6":
                    SetVisibleTrue_Primarias();
                    break;
                case "5":
                    SetVisibleTrue_Primarias();
                    break;
                case "4":
                    SetVisibleTrue_Primarias();
                    break;
                case "3":
                    numEscovado.Visible = true;
                    lblEscovado.Visible = true;
                    break;
                case "Borrado 20kg":
                    SetVisibleTrue_Secundarias();
                    break;
                case "2/3":
                    SetVisibleTrue_Secundarias();
                    break;
                case "Industrial 20kg":
                    SetVisibleTrue_Secundarias();
                    break;
                case "Dente 20kg":
                    SetVisibleTrue_Secundarias();
                    break;
            }
        }

        private void SetVisibleTrue_Primarias()
        {
            numExtra.Visible = true;
            numEspecial.Visible = true;
            numEscovado.Visible = true;
            numCat.Visible = true;
            numComercial.Visible = true;
            lblExtra.Visible = true;
            lblComercial.Visible = true;
            lblEscovado.Visible = true;
            lblEspecial.Visible = true;
            lblCat.Visible = true;
        }
        private void SetVisibleFalse_Primarias()
        {
            numExtra.Visible = false;
            numEspecial.Visible = false;
            numEscovado.Visible = false;
            numCat.Visible = false;
            numComercial.Visible = false;
            lblExtra.Visible = false;
            lblComercial.Visible = false;
            lblEscovado.Visible = false;
            lblEspecial.Visible = false;
            lblCat.Visible = false;
        }
        private void SetVisibleTrue_Secundarias()
        {
            numValor.Visible = true;
            lblQuantidade.Visible = true;
        }
        private void SetVisibleFalse_Secundarias()
        {
            numValor.Visible = false;
            lblQuantidade.Visible = false;
        }

        private void btnRegistrarLancamento_Click(object sender, EventArgs e)
        {
            string tipoAlho = comboTipoAlho.SelectedItem.ToString();
            int extra = (int)numExtra.Value;
            int cat = (int)numCat.Value;
            int comercial = (int)numComercial.Value;
            int especial = (int)numEspecial.Value;
            int escovado = (int)numEscovado.Value;
            int quantidade = (int)numValor.Value;

            var classificacoesPorTipo = new Dictionary<string, Dictionary<string, int>>();

            if (tipoAlho == "8" || tipoAlho == "7" || tipoAlho == "6" || tipoAlho == "5" || tipoAlho == "4")
            {
                classificacoesPorTipo["Extra"] = new Dictionary<string, int> { { tipoAlho, extra } };
                classificacoesPorTipo["Cat"] = new Dictionary<string, int> { { tipoAlho, cat } };
                classificacoesPorTipo["Comercial"] = new Dictionary<string, int> { { tipoAlho, comercial } };
                classificacoesPorTipo["Especial"] = new Dictionary<string, int> { { tipoAlho, especial } };
                classificacoesPorTipo["Escovado"] = new Dictionary<string, int> { { tipoAlho, escovado } };
            }
            else if (tipoAlho == "3")
            {
                classificacoesPorTipo["Escovado"] = new Dictionary<string, int> { { "3", quantidade } };
            }
            else if (tipoAlho == "Borrado 20kg")
            {
                classificacoesPorTipo["Borrado"] = new Dictionary<string, int> { { "20kg", quantidade } };
            }
            else if (tipoAlho == "2/3")
            {
                classificacoesPorTipo["Escovado"] = new Dictionary<string, int> { { "2/3", quantidade } };
            }
            else if (tipoAlho == "Industrial 20kg")
            {
                classificacoesPorTipo["Industrial"] = new Dictionary<string, int> { { "20kg", quantidade } };
            }
            else if (tipoAlho == "Dente 20kg")
            {
                classificacoesPorTipo["Dente"] = new Dictionary<string, int> { { "20kg", quantidade } };
            }

            var fazendaSelecionada = _fazendaService.RetornaFazendaPeloNome(comboFazenda.SelectedItem.ToString());
            var plSelecionado = _plService.RetornaPlPeloNomeeFazenda(comboPL.SelectedItem.ToString(), fazendaSelecionada.Conteudo.Nome);

            var resultado = _estoqueService.CriarEstoque(
                dataEntrada.Value,
                comboEvento.SelectedItem.ToString(),
                txtNumDoc.Text,
                fazendaSelecionada.Conteudo.Id,
                plSelecionado.Conteudo.Id,
                classificacoesPorTipo
            );

            if (resultado.Sucesso)
            {
                MessageBox.Show("Estoque criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show($"Erro ao criar estoque: {resultado.MensagemErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ScreenRegistrarEstoque_Load(object sender, EventArgs e)
        {
            var resultadoFazendas = _fazendaService.RetornaTodasFazendas();
            comboFazenda.Items.Clear();
            if (resultadoFazendas.Sucesso)
            {
                foreach (var item in resultadoFazendas.Conteudo)
                {
                    comboFazenda.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show(resultadoFazendas.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboFazenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultadoPL = _plService.RetornaTodosPlDaFazenda(comboFazenda.SelectedItem.ToString());
            comboPL.Items.Clear();
            if (resultadoPL.Sucesso)
            {
                foreach (var item in resultadoPL.Conteudo)
                {
                    comboPL.Items.Add(item.Nome);
                }
            } else
            {
                MessageBox.Show(resultadoPL.MensagemErro, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
