using Cadastro_Estoque.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Cadastro_Estoque
{
    public partial class Deletar : Form
    {
        public Deletar()
        {
            InitializeComponent();

            list_Itens.View = View.Details;
            list_Itens.LabelEdit = true;
            list_Itens.AllowColumnReorder = true;
            list_Itens.FullRowSelect = true;
            list_Itens.GridLines = true;

            list_Itens.Columns.Add("ID", 30, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Nome", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Modelo", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Tipo", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Data Entrada", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Data Saida", 100, HorizontalAlignment.Left);
            list_Itens.Columns.Add("Valor", 100, HorizontalAlignment.Left);
        }

        private void Deletar_Load(object sender, EventArgs e)
        {
            CarregarItens();
        }

        // metodo vai carregar todos itens que tiverem cadastrados
        private void CarregarItens()
        {
            list_Itens.Items.Clear();

            try
            {
                string sql = "SELECT * FROM itens";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDateTime(4).ToString(),
                        reader.GetDateTime(5).ToString(),
                        reader.GetDouble(6).ToString(),
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

        // metodo ira mostra o item que vc quer por uma busca 
        private void BtBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string q = "'%" + txtBuscar.Text + "%'";
                string sql = "SELECT * FROM itens WHERE nome LIKE " + q + " OR id_itens LIKE " + q;
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());

                MySqlDataReader reader = comando.ExecuteReader();

                list_Itens.Items.Clear();

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetInt32(0).ToString(),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDateTime(4).ToString(),
                        reader.GetDateTime(5).ToString(),
                        reader.GetDouble(6).ToString(),
                    };

                    var linha_listView = new ListViewItem(row);

                    list_Itens.Items.Add(linha_listView);
                }

                reader.Close();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Listar os itens: " + ex.Message);
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (list_Itens.SelectedItems.Count > 0)
            {
                ListViewItem itemSelecionado = list_Itens.SelectedItems[0];
                int id_itens = int.Parse(itemSelecionado.SubItems[0].Text);
                Itens item = new Itens { id_itens = id_itens };

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
    }
}
