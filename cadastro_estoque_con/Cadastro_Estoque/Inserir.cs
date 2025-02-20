using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cadastro_Estoque.DAO;

namespace Cadastro_Estoque
{
    public partial class Inserir : Form
    {
        private int id_itens;

        public Inserir()
        {
            InitializeComponent();
        }

        // Criação do comando Inser

        private void btInsert_Click_1(object sender, EventArgs e)
        {
            try
            {
                Itens novoItem = new Itens
                {
                    nome = txtNome.Text,
                    descricao = txtDescricao.Text,
                    valor = Double.Parse(txtValor.Text),
                    quant_estoque = int.Parse(txtQuant.Text),
                    tipo = cbtipo.Text,
                    dataEntrada = DateTime.Parse(txtDataEntrada.Text)
                };

                ItensDAO itensDAO = new ItensDAO();
                itensDAO.Salvar(novoItem);
                MessageBox.Show("Item salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o item: " + ex.Message);
            }
        }

        private void BtBuscar_Click_1(object sender, EventArgs e)
        {
            Buscar_Deletar_Excluir novoFormulario = new Buscar_Deletar_Excluir();
            novoFormulario.Show();
            this.Hide();
        }
    }
}
