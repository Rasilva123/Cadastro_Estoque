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
        public Inserir()
        {
            InitializeComponent();
        }

        //Criação do comando Insert
        private void btInsert_Click(object sender, EventArgs e)
        {
            try
            {
               
                Itens novoiten = new Itens
                {
                    nome = txtNome.Text,
                    modelo = txtModelo.Text,
                    tipo = txtTipo.Text,
                    dataEntrada = DateTime.Parse(txtDadaEntrada.Text),
                    dataSaida = DateTime.Parse(txtDataSaida.Text),
                    valor = double.Parse(txtValor.Text) 
                };

                ItensDAO intesdao = new ItensDAO();
                intesdao.Salvar(novoiten);
                MessageBox.Show("Item salvo com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar o item: " + ex.Message);
            }

        }

        private void BtBuscar_Click(object sender, EventArgs e)
        {

            Deletar novoFormulario = new Deletar();


            novoFormulario.Show();


            this.Hide();
        }
    }
}
