using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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




    }
}
