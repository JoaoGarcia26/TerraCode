using System;
using System.Data;
using System.Windows.Forms;
using TerraCode.Service;

namespace TerraCode.View.Classificacao
{
    public partial class ScreenPreClassificacao : Form
    {
        private ScreenRegistrarClassificacao _formRegistrarClassificacao;
        private PreClassificacaoService preClassificacaoService;
        private FazendaService fazendaService;
        private PLService plService;
        public ScreenPreClassificacao()
        {
            preClassificacaoService = new PreClassificacaoService();
            fazendaService = new FazendaService();
            plService = new PLService();
            InitializeComponent();
        }

        private void ScreenClassificacao_Load(object sender, EventArgs e)
        {
            var resultado = preClassificacaoService.RetornaTodasPreClassificacoes();

            DataTable dt = new DataTable();
            dt.Columns.Add("Data", typeof(DateTime));
            dt.Columns.Add("Fazenda", typeof(string));
            dt.Columns.Add("PL", typeof(string));
            dt.Columns.Add("Peso Alho 8", typeof(float));
            dt.Columns.Add("Peso Alho 7", typeof(float));
            dt.Columns.Add("Peso Alho 6", typeof(float));
            dt.Columns.Add("Peso Alho 5", typeof(float));
            dt.Columns.Add("Peso Alho 4", typeof(float));
            dt.Columns.Add("Peso Alho 3", typeof(float));
            dt.Columns.Add("Peso Industrial", typeof(float));
            dt.Columns.Add("Total Classificado", typeof(float));
            dt.Columns.Add("Descarte", typeof(float));
            dt.Columns.Add("Perda", typeof(float));

            if (resultado.Sucesso && resultado.Conteudo != null && resultado.Conteudo.Count > 0)
            {
                foreach (var item in resultado.Conteudo)
                {
                    var fazenda = fazendaService.RetornaFazendaPeloId(item.FazendaId).Conteudo;
                    string fazendaNome = fazenda != null ? fazenda.Nome : "Desconhecida";

                    var pl = plService.RetornaPlPeloIDeFazenda(item.PLId, fazendaNome).Conteudo;
                    string plNome = pl != null ? pl.Nome : "Desconhecido";

                    dt.Rows.Add(
                        item.Data,
                        fazendaNome,
                        plNome,
                        item.PesoAlho8,
                        item.PesoAlho7,
                        item.PesoAlho6,
                        item.PesoAlho5,
                        item.PesoAlho4,
                        item.PesoAlho3,
                        item.PesoIndustrial,
                        item.TotalClassificado,
                        item.Descarte,
                        item.Perda
                    );
                }
            }
            else
            {
                MessageBox.Show("Nenhuma classificação encontrada.");
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Data"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Fazenda"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["PL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Peso Alho 8"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Alho 7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Alho 6"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Alho 5"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Alho 4"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Alho 3"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Peso Industrial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Total Classificado"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Descarte"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Perda"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_formRegistrarClassificacao == null || _formRegistrarClassificacao.IsDisposed)
            {
                _formRegistrarClassificacao = new ScreenRegistrarClassificacao();
            }
            _formRegistrarClassificacao.ShowDialog();
        }
    }
}
