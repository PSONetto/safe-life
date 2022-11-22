using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class UsuarioDAO
    {
        Conexao con = new Conexao();
        SqlDataReader dr;
        public String mensagem = "";
        public void cadastrarUsuario(Usuario usuario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText =
                @"insert into Usuarios (Nome, Email , Senha)
                values (@nome, @email, @senha);";
            cmd.Parameters.AddWithValue("@nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@email", usuario.Email);
            cmd.Parameters.AddWithValue("@senha", usuario.Senha);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Usuário cadastrado com sucesso";
            }
            catch (Exception e)
            {
                this.mensagem = "Erro de cadastro";
            }
        }

        public void login(String nome, String senha)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText =
                @"select * from Usuarios 
                where 
                    Nome = @nome and
                    Senha = @senha;";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@senha", senha);
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    nome = dr["nome"].ToString();
                    senha = dr["senha"].ToString();
                }
                else
                {
                    nome = "";
                    senha = "";
                    this.mensagem = "Usuário ou senha incorretos";
                }
            }
            catch (Exception e)
            {
                this.mensagem = e.Message;
            }
            con.Desconectar();
            return;
        }
    }
}
