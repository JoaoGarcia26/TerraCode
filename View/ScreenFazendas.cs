using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TerraCode.View
{
    public partial class ScreenFazendas : Form
    {
        private ScreenCriarFazendas _formCriarFazendas;
        private ScreenCriarPL _formCriarPl;
        private ScreenPls _formListarPl;
        public ScreenFazendas()
        {
            InitializeComponent();
        }

        private void Fazendas_Load(object sender, EventArgs e)
        {
            this.pLsTableAdapter.Fill(this.dbTerraCodeDataSet.PLs);
            this.fazendasTableAdapter.Fill(this.dbTerraCodeDataSet.Fazendas);

            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Nome da Fazenda", typeof(string));
            dt.Columns.Add("Área Total (HA)", typeof(float));
            dt.Columns.Add("PL's", typeof(string));

            var query = from fazenda in this.dbTerraCodeDataSet.Fazendas
                        join pl in this.dbTerraCodeDataSet.PLs
                        on fazenda.Id equals pl.FazendaId into plGroup
                        select new
                        {
                            FazendaId = fazenda.Id,
                            FazendaNome = fazenda.Nome,
                            FazendaHectare = fazenda.Hectare,
                            PLNomes = plGroup.Any()
                                ? string.Join(", ", plGroup.Select(p => p.Nome))
                                : "Sem PL's cadastrado"
                        };

            if (!query.Any())
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
            }

            foreach (var item in query)
            {
                dt.Rows.Add(item.FazendaId, item.FazendaNome, item.FazendaHectare, item.PLNomes);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Id"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView1.Columns["Nome da Fazenda"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Área Total (HA)"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["PL's"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void btnAddFazenda_Click(object sender, EventArgs e)
        {
            _formCriarFazendas = new ScreenCriarFazendas();
            _formCriarFazendas.ShowDialog();
        }

        private void btnPL_Click(object sender, EventArgs e)
        {
            _formCriarPl = new ScreenCriarPL();
            _formCriarPl.ShowDialog();
        }

        private void ScreenFazendas_VisibleChanged(object sender, EventArgs e)
        {
            Fazendas_Load(sender, e);
        }

        private void ScreenFazendas_Activated(object sender, EventArgs e)
        {
            Fazendas_Load(sender, e);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnListarPls_Click(object sender, EventArgs e)
        {
            _formListarPl = new ScreenPls();
            _formListarPl.ShowDialog();
        }
    }
}
