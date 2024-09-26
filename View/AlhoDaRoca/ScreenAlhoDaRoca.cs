﻿using System;
using System.Data;
using System.Windows.Forms;
using TerraCode.Service;
using TerraCode.View.AlhoDaRoca;

namespace TerraCode.View
{
    public partial class ScreenAlhoDaRoca : Form
    {
        private ScreenRegistrarEntrada _formRegistraAlhoRoca;
        public ScreenAlhoDaRoca()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (_formRegistraAlhoRoca == null || _formRegistraAlhoRoca.IsDisposed)
            {
                _formRegistraAlhoRoca = new ScreenRegistrarEntrada();
            }
            _formRegistraAlhoRoca.ShowDialog();
        }

        private void ScreenAlhoDaRoca_Load(object sender, EventArgs e)
        {
            var movimentacaoService = new MovimentacaoProducaoRocaService();
            var motoristaService = new MotoristaService();
            var fazendaService = new FazendaService();
            var plService = new PLService();
            var veiculoService = new VeiculoService();

            var resultado = movimentacaoService.RetornaTodasMovimentacoes();

            DataTable dt = new DataTable();
            dt.Columns.Add("Data de Entrada", typeof(DateTime));
            dt.Columns.Add("Motorista", typeof(string));
            dt.Columns.Add("Veículo", typeof(string));
            dt.Columns.Add("Fazenda", typeof(string));
            dt.Columns.Add("PL", typeof(string));
            dt.Columns.Add("Peso Total", typeof(float));
            dt.Columns.Add("Número de Caixas", typeof(int));
            dt.Columns.Add("Peso Médio por Caixa", typeof(float));

            if (!resultado.Sucesso || resultado.Conteudo == null || resultado.Conteudo.Count == 0)
            {
                MessageBox.Show("A consulta não retornou nenhum resultado.");
                return;
            }

            foreach (var item in resultado.Conteudo)
            {
                var motorista = motoristaService.RetornaMotoristaPeloId(item.MotoristaId).Conteudo;
                var fazenda = fazendaService.RetornaFazendaPeloId(item.FazendaId).Conteudo;
                var pl = plService.RetornaPlPeloIDeFazenda(item.PLId, fazenda.Nome).Conteudo;
                var veiculo = veiculoService.RetornaVeiculoPeloId(item.VeiculoId).Conteudo;

                string motoristaNome = motorista != null ? motorista.Nome : "Desconhecido";
                string fazendaNome = fazenda != null ? fazenda.Nome : "Desconhecida";
                string plNome = pl != null ? pl.Nome : "Desconhecido";

                float pesoMedioPorCaixa = (float)((item.NumCaixas > 0) ? item.PesoTotal / item.NumCaixas : 0);

                dt.Rows.Add(item.DataEntrada, motoristaNome, veiculo.Placa, fazendaNome, plNome, item.PesoTotal, item.NumCaixas, pesoMedioPorCaixa);
            }

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.Columns["Data de Entrada"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Motorista"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Veículo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Fazenda"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["PL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Peso Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Número de Caixas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns["Peso Médio por Caixa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Refresh();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}