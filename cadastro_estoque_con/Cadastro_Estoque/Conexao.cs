using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Cadastro_Estoque
{
    internal static class Conexao
    {
        static MySqlConnection _conexao;
        static string strconexao = "server=localhost; port=3306; uid=root; pwd=root; database=CadastroEstoqueOficina ";

        public static MySqlConnection Conectar()
        {
            try
            {
                _conexao = new MySqlConnection(strconexao);
                _conexao.Open();
                return _conexao;
            }
            catch (Exception ex )
            {

                throw new Exception("Erro ao conectar " + ex.Message);
            }
        }

        public static void FecharConexao()
        {
            _conexao.Close();
        }
       
    }
}
