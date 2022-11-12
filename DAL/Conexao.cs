using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class Conexao
    {
        SqlConnection con;

        public Conexao()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=Seguradora.mssql.somee.com;" +
                "Initial Catalog=Seguradora;" +
                "Persist Security Info=True;" +
                "User ID=maurinogf_SQLLogin_2;" +
                "Password=4gc7o6a9rf";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
