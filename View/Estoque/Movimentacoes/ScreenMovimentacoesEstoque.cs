using System;
using System.Data;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Estoque.Movimentacoes
{
    public partial class ScreenMovimentacoesEstoque : Form
    {
        private EstoqueService _estoqueService;

        public ScreenMovimentacoesEstoque()
        {
            InitializeComponent();
            _estoqueService = new EstoqueService();
        }

        private void ScreenMovimentacoesEstoque_Load(object sender, EventArgs e)
        {
            CarregaTabela();
            dataInicial.Value = DateTime.Today.AddMonths(-3);
        }

        public void CarregaTabela(DateTime? dataInicial = null, DateTime? dataFinal = null, string evento = null, string documento = null)
        {
            Console.WriteLine($"{dataInicial}, {dataFinal}, {evento}, {documento}");
            var resultado = _estoqueService.RetornaEstoqueFiltrado(dataInicial, dataFinal, evento, documento);

            DataTable dt = new DataTable();
            dt.Columns.Add("Data", typeof(DateTime));
            dt.Columns.Add("Evento", typeof(string));
            dt.Columns.Add("Documento", typeof(string));
            dt.Columns.Add("Extra 8", typeof(int));
            dt.Columns.Add("Cat 8", typeof(int));
            dt.Columns.Add("Especial 8", typeof(int));
            dt.Columns.Add("Escovado 8", typeof(int));
            dt.Columns.Add("Comercial 8", typeof(int));
            dt.Columns.Add("Extra 7", typeof(int));
            dt.Columns.Add("Cat 7", typeof(int));
            dt.Columns.Add("Especial 7", typeof(int));
            dt.Columns.Add("Escovado 7", typeof(int));
            dt.Columns.Add("Comercial 7", typeof(int));
            dt.Columns.Add("Extra 6", typeof(int));
            dt.Columns.Add("Cat 6", typeof(int));
            dt.Columns.Add("Especial 6", typeof(int));
            dt.Columns.Add("Escovado 6", typeof(int));
            dt.Columns.Add("Comercial 6", typeof(int));
            dt.Columns.Add("Extra 5", typeof(int));
            dt.Columns.Add("Cat 5", typeof(int));
            dt.Columns.Add("Especial 5", typeof(int));
            dt.Columns.Add("Escovado 5", typeof(int));
            dt.Columns.Add("Comercial 5", typeof(int));
            dt.Columns.Add("Extra 4", typeof(int));
            dt.Columns.Add("Cat 4", typeof(int));
            dt.Columns.Add("Especial 4", typeof(int));
            dt.Columns.Add("Escovado 4", typeof(int));
            dt.Columns.Add("Comercial 4", typeof(int));
            dt.Columns.Add("Escovado 3", typeof(int));
            dt.Columns.Add("Borrado 20kg", typeof(int));
            dt.Columns.Add("Escovado 2/3", typeof(int));
            dt.Columns.Add("Industrial 20kg", typeof(int));
            dt.Columns.Add("Dente 20kg", typeof(int));

            if (resultado.Sucesso && resultado.Conteudo != null && resultado.Conteudo.Count > 0)
            {
                foreach (var item in resultado.Conteudo)
                {
                    dt.Rows.Add(
                        item.Data,
                        item.Evento,
                        item.DocNr,
                        item.Extra8,
                        item.Cat8,
                        item.Especial8,
                        item.Escovado8,
                        item.Comercial8,
                        item.Extra7,
                        item.Cat7,
                        item.Especial7,
                        item.Escovado7,
                        item.Comercial7,
                        item.Extra6,
                        item.Cat6,
                        item.Especial6,
                        item.Escovado6,
                        item.Comercial6,
                        item.Extra5,
                        item.Cat5,
                        item.Especial5,
                        item.Escovado5,
                        item.Comercial5,
                        item.Extra4,
                        item.Cat4,
                        item.Especial4,
                        item.Escovado4,
                        item.Comercial4,
                        item.Escovado3,
                        item.Borrado20kg,
                        item.Escovado2_3,
                        item.Industrial20kg,
                        item.Dente20kg
                    );
                }
            }
            else
            {
                MessageBox.Show("Nenhuma movimentação de estoque encontrada.");
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ScrollBars = ScrollBars.Both;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Refresh();
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            DateTime? dataInicio = dataInicial.Value;
            DateTime? dataFim = dataFinal.Value;
            string evento = comboEvento.SelectedItem?.ToString();
            string documento = txtNumDoc.Text;

            CarregaTabela(dataInicio, dataFim, evento, documento);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];

                string numDocMovimentacao = selectedRow.Cells[2].Value.ToString();

                ScreenEditarMovimentacao screenEditar = new ScreenEditarMovimentacao(numDocMovimentacao);
                screenEditar.ShowDialog();

                CarregaTabela();
            }
            else
            {
                MessageBox.Show("Selecione uma movimentação para editar.");
            }
        }

        private void ScreenMovimentacoesEstoque_Activated(object sender, EventArgs e)
        {
            CarregaTabela();
        }
    }
}
