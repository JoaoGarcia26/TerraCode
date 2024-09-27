using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Estoque
{
    public partial class ScreenRegistrarEstoque : Form
    {
        private EstoqueService _estoqueService;
        public ScreenRegistrarEstoque()
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
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
            lblEspecial.Visible = true;
            lblEscovado.Visible = true;
            lblComercial.Visible = true;
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
            lblEspecial.Visible = false;
            lblEscovado.Visible = false;
            lblComercial.Visible = false;
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
                classificacoesPorTipo[tipoAlho] = new Dictionary<string, int>
                {
                    { "Extra", extra },
                    { "Cat", cat },
                    { "Comercial", comercial },
                    { "Especial", especial },
                    { "Escovado", escovado }
                };
            }
            else if (tipoAlho == "3")
            {
                classificacoesPorTipo["3"] = new Dictionary<string, int> 
                { 
                    { "numQuantidade", quantidade } 
                };
            }
            else if (tipoAlho == "Borrado 20kg")
            {
                classificacoesPorTipo["Borrado20kg"] = new Dictionary<string, int>
                {
                    { "numQuantidade", quantidade }
                };
            }
            else if (tipoAlho == "2/3")
            {
                classificacoesPorTipo["Escovado2_3"] = new Dictionary<string, int>
                {
                    { "numQuantidade", quantidade }
                };
            }
            else if (tipoAlho == "Industrial 20kg")
            {
                classificacoesPorTipo["Industrial20kg"] = new Dictionary<string, int>
                {
                    { "numQuantidade", quantidade }
                };
            }
            else if (tipoAlho == "Dente 20kg")
            {
                classificacoesPorTipo["Dente20kg"] = new Dictionary<string, int>
                {
                    { "numQuantidade", quantidade }
                };
            }

            var resultado = _estoqueService.CriarEstoque(dataEntrada.Value, txtNumDoc.Text, txtNumDoc.Text, classificacoesPorTipo);

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
    }
}
