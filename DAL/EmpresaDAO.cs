using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class EmpresaDAO
    {
        public String Mensagem;

        Conexao con = new Conexao();

        public void cadastrarEmpresa(Empresa empresa)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"insert into enderecos (cep, rua, numero, bairro, complemento, cidade, estado)" +
                "values (@cep, @rua, @numero, @bairro, @complemento, @cidade, @estado);";

            cmd.Parameters.AddWithValue("@cep", empresa.endereco.Cep);
            cmd.Parameters.AddWithValue("@rua", empresa.endereco.Rua);
            cmd.Parameters.AddWithValue("@numero", empresa.endereco.Numero);
            cmd.Parameters.AddWithValue("@bairro", empresa.endereco.Bairro);
            cmd.Parameters.AddWithValue("@complemento", empresa.endereco.Complemento);
            cmd.Parameters.AddWithValue("@estado", empresa.endereco.Estado);
            cmd.Parameters.AddWithValue("@cidade", empresa.endereco.Cidade);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                this.Mensagem = "Erro no cadastro.\n" + e.Message;
            }

            cmd.CommandText = @"select top 1 id_endereco from enderecos" +
                "order by id_endereco desc;";
        }
    }
}
