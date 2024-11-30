using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Vendas
{
    public partial class ScreenCriarVendas : Form
    {
        private FazendaService _fazendaService;
        private PLService _plService;
        private SafraService _safraService;
        private VendasService _vendasService;
        public ScreenCriarVendas()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
            _plService = new PLService();
            _safraService = new SafraService();
            _vendasService = new VendasService();
            CarregaTabelaRomaneio();
            CarregaComboFazenda();
            CarregaComboSafra();
        }

        private void CarregaTabelaRomaneio()
        {
            dataGridView1.Columns.Add("Produto", "Produto");
            dataGridView1.Columns.Add("Quantidade em Caixas", "Quantidade em Caixas");

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["Produto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Quantidade em Caixas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Quantidade em Caixas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            AddNewRow();
        }

        private void AddNewRow()
        {
            int rowIndex = dataGridView1.Rows.Add("", 0);
            UpdateComboBox(rowIndex);
        }

        private void UpdateComboBox(int rowIndex)
        {
            DataGridViewComboBoxCell comboBoxCell = new DataGridViewComboBoxCell();
            string[] produtos = {
                "Extra 8", "Cat 8", "Especial 8", "Escovado 8", "Comercial 8",
                "Extra 7", "Cat 7", "Especial 7", "Escovado 7", "Comercial 7",
                "Extra 6", "Cat 6", "Especial 6", "Escovado 6", "Comercial 6",
                "Extra 5", "Cat 5", "Especial 5", "Escovado 5", "Comercial 5",
                "Extra 4", "Cat 4", "Especial 4", "Escovado 4", "Comercial 4",
                "Escovado 3", "Borrado 20kg", "Escovado 2/3", "Industrial 20kg", "Dente 20kg"
            };

            comboBoxCell.Style.SelectionBackColor = System.Drawing.Color.White;
            comboBoxCell.Style.BackColor = System.Drawing.Color.White;


            var selectedProducts = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Take(rowIndex)
                .Select(r => r.Cells["Produto"].Value?.ToString())
                .Where(v => !string.IsNullOrEmpty(v))
                .ToList();

            foreach (var produto in produtos)
            {
                if (!selectedProducts.Contains(produto))
                {
                    comboBoxCell.Items.Add(produto);
                }
            }

            dataGridView1.Rows[rowIndex].Cells["Produto"] = comboBoxCell;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.Rows.Count - 1)
            {
                var produtoValue = dataGridView1.Rows[e.RowIndex].Cells["Produto"].Value?.ToString();
                var quantidadeValue = dataGridView1.Rows[e.RowIndex].Cells["Quantidade em Caixas"].Value?.ToString();

                if (!string.IsNullOrEmpty(produtoValue) && !string.IsNullOrEmpty(quantidadeValue))
                {
                    AddNewRow();
                }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int idFazenda = _fazendaService.RetornaFazendaPeloNome(comboFazenda.SelectedItem.ToString()).Conteudo.Id;
            int idPL = _plService.RetornaPlPeloNomeeFazenda(comboPL.SelectedItem.ToString(), comboFazenda.SelectedItem.ToString()).Conteudo.Id;
            int idSafra = _safraService.RetornaSafraPeloNome(comboSafra.SelectedItem.ToString()).Conteudo.Id;

            var listaVenda = ObterProdutosDaTabela();

            var resultado = _vendasService.CriarVenda(dataVenda.Value, txtComprador.Text, txtMotorista.Text, txtCpfMotorista.Text, txtPlaca.Text, listaVenda, idPL, idFazenda, idSafra, txtNumDoc.Text);

            if (resultado.Sucesso)
            {
                MessageBox.Show("Venda registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show($"Erro: {resultado.MensagemErro}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Dictionary<string, int> ObterProdutosDaTabela()
        {
            var produtos = new Dictionary<string, int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var produto = row.Cells["Produto"].Value?.ToString();
                var quantidadeString = row.Cells["Quantidade em Caixas"].Value?.ToString();

                if (!string.IsNullOrEmpty(produto) && int.TryParse(quantidadeString, out int quantidade))
                {
                    if (produtos.ContainsKey(produto))
                    {
                        produtos[produto] += quantidade;
                    }
                    else
                    {
                        produtos[produto] = quantidade;
                    }
                }
            }
            return produtos;
        }

        private void CarregaComboFazenda()
        {
            var resultadosFazenda = _fazendaService.RetornaTodasFazendas();
            if (!resultadosFazenda.Sucesso)
            {
                return;
            } else
            {
                comboFazenda.Items.Clear();
                foreach (var item in resultadosFazenda.Conteudo)
                {
                    comboFazenda.Items.Add(item.Nome);
                }
            }
        }

        private void CarregaComboSafra()
        {
            var resultadosSafra = _safraService.RetornaTodasSafras();
            if (!resultadosSafra.Sucesso)
            {
                return;
            }
            else
            {
                comboSafra.Items.Clear();
                foreach (var item in resultadosSafra.Conteudo)
                {
                    comboSafra.Items.Add(item.Nome);
                }
            }
        }

        private void comboFazenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultadosPL = _plService.RetornaTodosPlDaFazenda(comboFazenda.SelectedItem.ToString());
            if (!resultadosPL.Sucesso)
            {
                return;
            }
            else
            {
                comboPL.Items.Clear();
                foreach (var item in resultadosPL.Conteudo)
                {
                    comboPL.Items.Add(item.Nome);
                }
            }
        }
    }
}
