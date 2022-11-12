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
    internal class TitularDAO
    {
        Conexao con = new Conexao();
        SqlDataReader dr;

        public String mensagem = "";

        public DataTable listarTitulares()
        {
            SqlCommand cmd = new SqlCommand();
            DataTable clientes = new DataTable();
            cmd.CommandText = @"select * from Titulares;";
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    clientes.Columns.Add("ID", typeof(int));
                    clientes.Columns.Add("nome", typeof(String));
                    clientes.Columns.Add("CPF", typeof(String));
                    clientes.Columns.Add("RG", typeof(String));
                    while (dr.Read())
                    {
                        clientes.Rows.Add(dr["ID"], dr["nome"], dr["CPF"], dr["RG"]);
                    }
                }
                else
                {
                    this.mensagem = "Nenhum titular encontrado";
                }
            }
            catch (Exception e)
            {
                this.mensagem = e.Message;
            }

            con.Desconectar();
            return clientes;
        }

        public void cadastrarTitular(Titular titular)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"insert into titulares_teste (nome, dat_nasc, cpf, rg, nome_mae, nome_pai, telefone, celular, email, cep, rua, numero, bairro, complemento, estado, cidade) " +
                               "values (@nome, @dat_nasc, @cpf, @rg, @nome_mae, @nome_pai, @telefone, @celular, @email, @cep, @rua, @numero, @bairro, @complemento, @estado, @cidade); ";

            cmd.Parameters.AddWithValue("@nome", titular.nome);
            cmd.Parameters.AddWithValue("@dat_nasc", titular.datNasc);
            cmd.Parameters.AddWithValue("@cpf", titular.cpf);
            cmd.Parameters.AddWithValue("@rg", titular.rg);
            cmd.Parameters.AddWithValue("@nome_mae", titular.nomeMae);
            cmd.Parameters.AddWithValue("@nome_pai", titular.nomePai);
            cmd.Parameters.AddWithValue("@telefone", titular.telefone);
            cmd.Parameters.AddWithValue("@celular", titular.celular);
            cmd.Parameters.AddWithValue("@email", titular.email);
            cmd.Parameters.AddWithValue("@cep", titular.endereco.cep);
            cmd.Parameters.AddWithValue("@rua", titular.endereco.rua);
            cmd.Parameters.AddWithValue("@numero", titular.endereco.numero);
            cmd.Parameters.AddWithValue("@bairro", titular.endereco.bairro);
            cmd.Parameters.AddWithValue("@complemento", titular.endereco.complemento);


            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Titular cadastrado";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro no cadastro.\n" + e.Message;
            }
        }
    }
}
