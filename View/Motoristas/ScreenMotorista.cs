using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenMotorista : Form
    {
        //private MotoristaService _motoristaService;
        private ScreenCriarMotorista _formCriarMotorista;
        public ScreenMotorista()
        {
            InitializeComponent();
            //_motoristaService = new MotoristaService();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ScreenMotorista_Load(object sender, EventArgs e)
        {
            this.veiculoTableAdapter.Fill(this.dbTerraCodeDataSet.Veiculo);
            this.motoristaTableAdapter.Fill(this.dbTerraCodeDataSet.Motorista);

            DataTable dt = new DataTable();

            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("Endereço", typeof(string));
            dt.Columns.Add("CNH", typeof(string));
            dt.Columns.Add("CPF", typeof(string));
            dt.Columns.Add("Veículos", typeof(string));

            var query = from motorista in this.dbTerraCodeDataSet.Motorista
                        join veiculo in this.dbTerraCodeDataSet.Veiculo
                        on motorista.Id equals veiculo.MotoristaId into veiculoGroup
                        select new
                        {
                            MotoristaId = motorista.Id,
                            MotoristaNome = motorista.Nome,
                            MotoristaEndereco = motorista.Endereco,
                            MotoristaCNH = motorista.CNH,
                            MotoristaCPF = motorista.CPF,
                            VeiculosNomes = veiculoGroup.Any()
                                ? string.Join(", ", veiculoGroup.Select(v => v.Placa))
                                : "Sem veículos cadastrados"
                        };

            if (!query.Any())
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
            }

            foreach (var item in query)
            {
                string cpfMascarado = string.Format("{0:000\\.000\\.000\\-00}", long.Parse(item.MotoristaCPF));
                dt.Rows.Add(item.MotoristaNome, item.MotoristaEndereco, item.MotoristaCNH, cpfMascarado, item.VeiculosNomes);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Endereço"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["CNH"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["CPF"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Veículos"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }


        private void btnAddMotorista_Click(object sender, EventArgs e)
        {
            _formCriarMotorista = new ScreenCriarMotorista();
            _formCriarMotorista.ShowDialog();
        }

        private void ScreenMotorista_Activated(object sender, EventArgs e)
        {
            ScreenMotorista_Load(sender, e);
        }
    }
}
