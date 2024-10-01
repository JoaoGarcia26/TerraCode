using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TerraCode.Model;
using TerraCode.Service;

namespace TerraCode.View
{
    public partial class ScreenPls : Form
    {
        private PLService _plService;
        private FazendaService _fazendaService;
        private ScreenCriarPL _formCriarPl;
        public ScreenPls()
        {
            InitializeComponent();
            _fazendaService = new FazendaService();
            _plService = new PLService();
        }

        private void ScreenPls_Load(object sender, EventArgs e)
        {
            CarregaTabela();
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

        private void CarregaTabela()
        {
            var resultadoFazendas = _fazendaService.RetornaTodasFazendas();

            if (!resultadoFazendas.Sucesso)
            {
                MessageBox.Show("Erro ao carregar fazendas: " + resultadoFazendas.MensagemErro);
                return;
            }

            List<PL> pls = new List<PL>();
            foreach (var fazenda in resultadoFazendas.Conteudo)
            {
                var resultadoPls = _plService.RetornaTodosPlDaFazenda(fazenda.Nome);
                if (resultadoPls.Sucesso)
                {
                    pls.AddRange(resultadoPls.Conteudo);
                }
                else
                {
                    MessageBox.Show("Erro ao carregar PLs da fazenda " + fazenda.Nome + ": " + resultadoPls.MensagemErro);
                    return;
                }
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Nome da Fazenda", typeof(string));
            dt.Columns.Add("Nome do PL", typeof(string));
            dt.Columns.Add("Data do Plantio", typeof(DateTime));
            dt.Columns.Add("Hectares Plantados", typeof(float));
            dt.Columns.Add("Observações", typeof(string));

            foreach (var pl in pls)
            {
                var fazenda = resultadoFazendas.Conteudo.FirstOrDefault(f => f.Id == pl.FazendaId);
                if (fazenda != null)
                {
                    dt.Rows.Add(fazenda.Nome, pl.Nome, pl.DataDoPlantio, pl.HectarePlantados, pl.Observacoes);
                }
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum PL encontrado.");
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

        private void ScreenPls_Activated(object sender, EventArgs e)
        {
            CarregaTabela();
        }
    }
}
