using Cadastro_Estoque.DAO;
using System;
using System.Windows.Forms;

namespace Cadastro_Estoque
{
    public partial class Editar : Form
    {
        private int id_itens;
        private string nome;
        private string descricao;
        private string tipo;
        private int quant;
        private DateTime dataEntrada;
        private double valor;


        public Editar(int id_item, string nomeItem, string descricaoItem, int quantidadeEstoque, string tipoItem, DateTime dataEntradaItem, double valorItem)
        {
            InitializeComponent();
            this.id_itens = id_item;
            this.nome = nomeItem;
            this.descricao = descricaoItem;
            this.tipo = tipoItem;
            this.quant = quantidadeEstoque;
            this.dataEntrada = dataEntradaItem;
            this.valor = valorItem;

            txtNome.Text = nomeItem;
            txtDescricao.Text = descricaoItem;
            cbtipo.Text = tipoItem;
            txtQuant.Text = quantidadeEstoque.ToString();
            txtDataEntrada.Text = dataEntradaItem.ToString();
            txtValor.Text = valorItem.ToString();

  
            MessageBox.Show("Formulário carregado com sucesso. Valores iniciais:\n" +
                            $"Nome: {nomeItem}\nDescrição: {descricaoItem}\nTipo: {tipoItem}\nQuantidade: {quantidadeEstoque}\n" +
                            $"Data Entrada: {dataEntrada}\nValor: {valorItem}");
        }

        
        private void btEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string novoNome = txtNome.Text;
                string novaDescricao = txtDescricao.Text;
                string novoTipo = cbtipo.Text;
                int quant = Convert.ToInt32(txtQuant.Text);
                DateTime novaDataEntrada = Convert.ToDateTime(txtDataEntrada.Text);
                double novoValor = double.Parse(txtValor.Text);

                Itens item = new Itens
                {
                    id_itens = this.id_itens,
                    nome = novoNome,
                    descricao = novaDescricao,
                    tipo = novoTipo,
                    quant_estoque = quant,
                    dataEntrada = novaDataEntrada,
                    valor = novoValor
                };

                ItensDAO itensDAO = new ItensDAO();
                itensDAO.Update(item);

                MessageBox.Show("Item atualizado com sucesso!");
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro ao atualizar o item: {ex.Message}");
            }
        }
    }
}
