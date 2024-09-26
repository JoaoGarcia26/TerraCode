using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TerraCode.View
{
    public partial class ScreenVeiculos : Form
    {
        private ScreenCriarVeiculos _formCriarVeiculos;
        public ScreenVeiculos()
        {
            InitializeComponent();
            _formCriarVeiculos = new ScreenCriarVeiculos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddVeiculos_Click(object sender, EventArgs e)
        {
            _formCriarVeiculos.ShowDialog();
        }

        private void ScreenVeiculos_Load(object sender, EventArgs e)
        {
            this.veiculoTableAdapter.Fill(this.dbTerraCodeDataSet.Veiculo);
            this.motoristaTableAdapter.Fill(this.dbTerraCodeDataSet.Motorista);

            DataTable dt = new DataTable();

            dt.Columns.Add("Placa", typeof(string));
            dt.Columns.Add("Tipo Veículo", typeof(string));
            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("CNH", typeof(string));
            dt.Columns.Add("CPF", typeof(string));

            var query = from veiculo in this.dbTerraCodeDataSet.Veiculo
                        join motorista in this.dbTerraCodeDataSet.Motorista
                        on veiculo.MotoristaId equals motorista.Id into motoristaGroup
                        from motorista in motoristaGroup.DefaultIfEmpty()
                        select new
                        {
                            VeiculoPlaca = veiculo.Placa,
                            VeiculoTipo = veiculo.TipoVeiculo,
                            MotoristaNome = motorista != null ? motorista.Nome : "Sem motorista",
                            MotoristaCNH = motorista != null ? motorista.CNH : "N/A",
                            MotoristaCPF = motorista != null ? motorista.CPF : "N/A"
                        };

            if (!query.Any())
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
            }

            foreach (var item in query)
            {
                string cpfMascarado = item.MotoristaCPF != "N/A" ? string.Format("{0:000\\.000\\.000\\-00}", long.Parse(item.MotoristaCPF)) : "N/A";
                dt.Rows.Add(item.VeiculoPlaca, item.VeiculoTipo, item.MotoristaNome, item.MotoristaCNH, cpfMascarado);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Placa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Tipo Veículo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["CNH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["CPF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void ScreenVeiculos_Activated(object sender, EventArgs e)
        {
            ScreenVeiculos_Load(sender, e);
        }
    }
}
