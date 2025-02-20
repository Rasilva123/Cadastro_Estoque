using Cadastro_Estoque.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Cadastro_Estoque
{
    public partial class Buscar_Deletar_Excluir : Form
    {
        public Buscar_Deletar_Excluir()
        {
            InitializeComponent();

            list_Itens.View = View.Details;
            list_Itens.LabelEdit = true;
            list_Itens.AllowColumnReorder = true;
            list_Itens.FullRowSelect = true;
            list_Itens.GridLines = true;

            // definir o tamanho das colunas dos itens e em que lado ficarão
            list_Itens.Columns.Add("ID", 30, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Descrição", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Preço", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Quantidade", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Tipo", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Data Entrada", 100, HorizontalAlignment.Left);
        }

        private void Deletar_Load(object sender, EventArgs e)
        {
            CarregarItens();
        }

        // metodo vai carregar todos os itens que estiverem cadastrados e tamebm ordenara pelo nome
        private void CarregarItens()
        {
            list_Itens.Items.Clear();

            try
            {
                string sql = "SELECT * FROM itens ORDER BY nome_item";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetInt32("id_item").ToString(),
                        reader.GetString("nome_item"),
                        reader.GetString("descricao_item"),
                        reader.GetString("preco_item"),
                        reader.GetInt32("quantidade_estoque").ToString(),
                        reader.GetString("tipo_item"),
                        reader.GetDateTime("data_entrada").ToString()
                    };

                    var linha_listView = new ListViewItem(row);

                    list_Itens.Items.Add(linha_listView);
                }

                reader.Close();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar os itens: " + ex.Message);
            }
        }

        // metodo irá mostrar o item que vc quer por uma busca 
        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtBuscar.Text + "%'";
                string sql = "SELECT * FROM itens WHERE nome_item LIKE " + q + " OR id_item LIKE " + q;
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                MySqlDataReader reader = comando.ExecuteReader();

                list_Itens.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetInt32("id_item").ToString(),
                        reader.GetString("nome_item"),
                        reader.GetString("descricao_item"),
                        reader.GetString("preco_item"),
                        reader.GetInt32("quantidade_estoque").ToString(),
                        reader.GetString("tipo_item"),
                        reader.GetDateTime("data_entrada").ToString()
                    };

                    var linha_listView = new ListViewItem(row);

                    list_Itens.Items.Add(linha_listView);
                }

                reader.Close();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar os itens: " + ex.Message);
            }
        }

        // metodo irá excluir o item que vc selecionar
        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (list_Itens.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = list_Itens.SelectedItems[0];
                int id_item = int.Parse(itemSelecionado.SubItems[0].Text);
                Itens item = new Itens { id_itens = id_item };

                ItensDAO itensDAO = new ItensDAO();
                itensDAO.Delete(item);

                MessageBox.Show("Item deletado com sucesso!");
                CarregarItens(); // Recarregar os itens após a exclusão
            }
            else
            {
                MessageBox.Show("Selecione um item para deletar.");
            }
        }

        // metodo irá editar o item que vc selecionar 
        private void btEdit_Click(object sender, EventArgs e)
        {
            if (list_Itens.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = list_Itens.SelectedItems[0];
                int id_item = int.Parse(itemSelecionado.SubItems[0].Text);
                string nomeItem = itemSelecionado.SubItems[1].Text;
                string descricaoItem = itemSelecionado.SubItems[2].Text;
                double valorItem = double.Parse(itemSelecionado.SubItems[3].Text);
                int quantidadeEstoque = int.Parse(itemSelecionado.SubItems[4].Text);
                string tipoItem = itemSelecionado.SubItems[5].Text;
                DateTime dataEntradaItem = DateTime.Parse(itemSelecionado.SubItems[6].Text);

                // Abre um novo formulário de edicao
                Editar formEditar = new Editar(id_item, nomeItem, descricaoItem, quantidadeEstoque, tipoItem, dataEntradaItem, valorItem);
                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    CarregarItens();
                    MessageBox.Show("Item atualizado com sucesso!");
                }
            }
            else
            {
                MessageBox.Show("Selecione um item para editar.");
            }
        }

        // metodo para voltar a tabela de inserção de dados 
        private void button1_Click(object sender, EventArgs e)
        {
            Inserir novoFormulario = new Inserir();
            novoFormulario.Show();
            this.Hide();
        }
    }
}
