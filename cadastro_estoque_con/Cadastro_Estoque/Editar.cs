using Cadastro_Estoque.DAO;
using System;
using System.Windows.Forms;

namespace Cadastro_Estoque
{
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

        public Editar(int id_itens, string nomeItem, string modeloItem, string tipoItem, DateTime dataEntrada, DateTime dataSaida, double valorItem)
        {
            InitializeComponent();
            Id_itens = id_itens;
            NomeItem = nomeItem;
            ModeloItem = modeloItem;
            TipoItem = tipoItem;
            DataEntrada = dataEntrada;
            DataSaida = dataSaida;
            ValorItem = valorItem;

            // Inicializar os controles com os valores passados
            txtNome.Text = NomeItem;
            txtModelo.Text = ModeloItem;
            txtTipo.Text = TipoItem;
            txtDadaEntrada.Text = DataEntrada.ToString();
            txtDataSaida.Text = DataSaida.ToString(); 
            txtValor.Text = ValorItem.ToString();

            // Adicionar mensagens de depuração
            MessageBox.Show("Formulário carregado com sucesso. Valores iniciais:\n" +
                            $"Nome: {NomeItem}\nModelo: {ModeloItem}\nTipo: {TipoItem}\n" +
                            $"Data Entrada: {DataEntrada}\nData Saida: {DataSaida}\nValor: {ValorItem}");
        }

        public int Id_itens { get; }
        public string NomeItem { get; }
        public string ModeloItem { get; }
        public string TipoItem { get; }
        public DateTime DataEntrada { get; }
        public DateTime DataSaida { get; }
        public double ValorItem { get; }

        private void btEditar_Click(object sender, EventArgs e)
        {
            string novoNome = txtNome.Text;
            string novoModelo = txtModelo.Text;
            string novoTipo = txtTipo.Text;
            DateTime novaDataEntrada = Convert.ToDateTime(txtDadaEntrada.Text);
            DateTime novaDataSaida = Convert.ToDateTime(txtDataSaida.Text);
            double novoValor = double.Parse(txtValor.Text);

            Itens item = new Itens
            {
                id_itens = Id_itens,
                nome = novoNome,
                modelo = novoModelo,
                tipo = novoTipo,
                dataEntrada = novaDataEntrada,
                dataSaida = novaDataSaida,
                valor = novoValor
            };

            ItensDAO itensDAO = new ItensDAO();
            itensDAO.Update(item);

            MessageBox.Show("Item atualizado com sucesso!");
            this.DialogResult = DialogResult.OK; // Fecha o formulário e indica que a operação foi bem-sucedida
            this.Close();
        }
    }
}
