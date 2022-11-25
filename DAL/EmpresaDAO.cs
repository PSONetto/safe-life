using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class EmpresaDAO
    {
        SqlDataReader dr;

        public String Mensagem { get; set; }

        Conexao con = new Conexao();

        public void cadastrarEmpresa(Empresa empresa)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"insert into pessoasjuridicas (cnpj, nome, email, telefone, cep, rua, numero, bairro, complemento, cidade, estado)" +
                "values (@cnpj, @nome, @email, @telefone, @cep, @rua, @numero, @bairro, @complemento, @cidade, @estado);";

            cmd.Parameters.AddWithValue("@cnpj", empresa.CNPJ);
            cmd.Parameters.AddWithValue("@nome", empresa.Nome);
            cmd.Parameters.AddWithValue("@email", empresa.Email);
            cmd.Parameters.AddWithValue("@telefone", empresa.Telefone);
            cmd.Parameters.AddWithValue("@cep", empresa.endereco.Cep);
            cmd.Parameters.AddWithValue("@rua", empresa.endereco.Rua);
            cmd.Parameters.AddWithValue("@numero", empresa.endereco.Numero);
            cmd.Parameters.AddWithValue("@bairro", empresa.endereco.Bairro);
            cmd.Parameters.AddWithValue("@complemento", empresa.endereco.Complemento);
            cmd.Parameters.AddWithValue("@cidade", empresa.endereco.Cidade);
            cmd.Parameters.AddWithValue("@estado", empresa.endereco.Estado);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();

                this.Mensagem = "Empresa cadastrada";
            }
            catch (Exception e)
            {
                this.Mensagem = "Erro no cadastro.\n" + e.Message;
            }
        }

        public Empresa pesquisarEmpresa(String cnpj)
        {
            this.Mensagem = "";
            SqlCommand cmd = new SqlCommand();

            Empresa empresa = new Empresa();

            cmd.CommandText = @"SELECT TOP 1 *
                FROM pessoasjuridicas
                WHERE cnpj = @cnpj";

            cmd.Parameters.AddWithValue("@cnpj", cnpj);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    empresa.CNPJ = dr["cnpj"].ToString();
                    empresa.Nome = dr["nome"].ToString();
                    empresa.Telefone = dr["telefone"].ToString();
                    empresa.Email = dr["email"].ToString();
                    empresa.endereco.Cep = dr["cep"].ToString();
                    empresa.endereco.Rua = dr["rua"].ToString();
                    empresa.endereco.Numero = dr["numero"].ToString();
                    empresa.endereco.Complemento = dr["complemento"].ToString();
                    empresa.endereco.Bairro = dr["bairro"].ToString();
                    empresa.endereco.Estado = dr["estado"].ToString();
                    empresa.endereco.Cidade = dr["cidade"].ToString();

                    dr.Close();
                }
                else
                {
                    this.Mensagem = "Registro não encontrado";
                }

            }
            catch (Exception e)
            {
                this.Mensagem = "Erro de conexão com banco de dados\n" + e.Message;
            }

            con.Desconectar();

            return empresa;
        }

        public void excluirEmpresa(String cnpj)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"update pessoasjuridicas set cnpj = 0 where cnpj = @cnpj;";

            cmd.Parameters.AddWithValue("@cnpj", cnpj);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
            }
            catch (Exception e)
            {
                this.Mensagem = "Erro ao excluír\n" + e.Message;
            }
        }
    }
}