using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cadastro_Estoque.DAO
{
    internal class ItensDAO
    {
        // Método Salvar
        public void Salvar(Itens itens)
        {
            try
            {
                string sql = "INSERT INTO itens (nome_item, descricao_item, preco_item, quantidade_estoque, tipo_item, data_entrada) " +
                             "VALUES (@nome_item, @descricao_item, @preco_item, @quantidade_estoque, @tipo_item, @data_entrada)";

                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_item", itens.nome);
                comando.Parameters.AddWithValue("@descricao_item", itens.descricao);
                comando.Parameters.AddWithValue("@preco_item", itens.valor);
                comando.Parameters.AddWithValue("@quantidade_estoque", itens.quant_estoque);
                comando.Parameters.AddWithValue("@tipo_item", itens.tipo);
                comando.Parameters.AddWithValue("@data_entrada", itens.dataEntrada);

                comando.ExecuteNonQuery();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar o item: " + ex.Message);
            }
        }

        // Método Deletar
        public void Delete(Itens itens)
        {
            try
            {
                string sql = "DELETE FROM itens WHERE id_item = @id_item";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_item", itens.id_itens);
                comando.ExecuteNonQuery();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar o item: " + ex.Message);
            }
        }

        // Método Update
        public void Update(Itens itens)
        {
            try
            {
                string sql = "UPDATE itens SET nome_item = @nome_item, descricao_item = @descricao_item, preco_item = @preco_item, " +
                             "quantidade_estoque = @quantidade_estoque, tipo_item = @tipo_item, data_entrada = @data_entrada WHERE id_item = @id_item";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nome_item", itens.nome);
                comando.Parameters.AddWithValue("@descricao_item", itens.descricao);
                comando.Parameters.AddWithValue("@preco_item", itens.valor);
                comando.Parameters.AddWithValue("@quantidade_estoque", itens.quant_estoque);
                comando.Parameters.AddWithValue("@tipo_item", itens.tipo);
                comando.Parameters.AddWithValue("@data_entrada", itens.dataEntrada);
                comando.Parameters.AddWithValue("@id_item", itens.id_itens);

                comando.ExecuteNonQuery();
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar o item: " + ex.Message);
            }
        }
    }
}
