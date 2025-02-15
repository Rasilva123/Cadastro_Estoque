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
        //Metodo Salvar
        public void Salvar(Itens itens)
        {
            try
            {
                 string sql = "INSERT INTO itens (nome, modelo, tipo, dataEntrada, dataSaida, valor) " +
                     "VALUES (@nome, @modelo,@tipo, @dataEntrada, @dataSaida, @valor)";

                 MySqlCommand comando = new MySqlCommand(sql,Conexao.Conectar());
                 comando.Parameters.AddWithValue("@nome", itens.nome);
                 comando.Parameters.AddWithValue("@modelo", itens.modelo);
                 comando.Parameters.AddWithValue("@tipo", itens.tipo);
                 comando.Parameters.AddWithValue("@dataEntrada", itens.dataEntrada);
                 comando.Parameters.AddWithValue("@dataSaida", itens.dataSaida);
                 comando.Parameters.AddWithValue("@valor", Convert.ToDouble(itens.valor));

                comando.ExecuteNonQuery();
                Conexao.FecharConexao();
                
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar o Itens: " +ex.Message);
            }
           
        }

        //Metodo Deletar
        public void Delete(Itens itens)
        {
            try
            {
                string sql = "DELETE FROM itens WHERE id_itens = @id_itens";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id_itens", itens.id_itens);
                comando.ExecuteNonQuery();
                Conexao.FecharConexao();
                
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Deletar o Item!! {ex.Message}");
            }
        
        }
        
    }
}
