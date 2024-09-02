using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenPls : Form
    {
        private PLService _plService;
        private ScreenCriarPL _formCriarPl;
        public ScreenPls()
        {
            InitializeComponent();
            _plService = new PLService();
        }

        private void ScreenPls_Load(object sender, EventArgs e)
        {
            this.pLsTableAdapter.Fill(this.dbTerraCodeDataSet.PLs);
            this.fazendasTableAdapter.Fill(this.dbTerraCodeDataSet.Fazendas);

            DataTable dt = new DataTable();

            dt.Columns.Add("Nome da Fazenda", typeof(string));
            dt.Columns.Add("Nome do PL", typeof(string));
            dt.Columns.Add("Data do Plantio", typeof(DateTime));
            dt.Columns.Add("Hectares Plantados", typeof(float));
            dt.Columns.Add("Observações", typeof(string));

            var query = from pl in this.dbTerraCodeDataSet.PLs
                        join fazenda in this.dbTerraCodeDataSet.Fazendas
                        on pl.FazendaId equals fazenda.Id
                        select new
                        {
                            PLId = pl.Id,
                            PLNome = pl.Nome,
                            FazendaNome = fazenda.Nome,
                            DataPlantio = pl.DataDoPlantio,
                            HectaresPlantados = pl.HectarePlantados,
                            Observacoes = pl.Observacoes
                        };

            if (!query.Any())
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
            }

            foreach (var item in query)
            {
                dt.Rows.Add(item.FazendaNome, item.PLNome, item.DataPlantio, item.HectaresPlantados, item.Observacoes);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Nome da Fazenda"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Nome do PL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Data do Plantio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Hectares Plantados"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Observações"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            _formCriarPl = new ScreenCriarPL();
            _formCriarPl.ShowDialog();
        }
    }
}
