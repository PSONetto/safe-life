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

        public String Mensagem = "";

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
                    this.Mensagem = "Nenhum titular encontrado";
                }
            }
            catch (Exception e)
            {
                this.Mensagem = e.Message;
            }

            con.Desconectar();
            return clientes;
        }

        public void cadastrarTitular(Titular titular)
        {
            SqlCommand cmd = new SqlCommand();

            int codPessoa;
            int codHistorico;
            int codContrato;

            cmd.CommandText = @"insert into pessoasfisicas (cpf, rg, nome, nome_mae, nome_pai, data_nasc, email, telefone, celular)" +
                "values (@cpf, @rg, @nome,  @nome_mae, @nome_pai, @data_nasc, @email, @telefone, @celular)" +
                "; SELECT SCOPE_IDENTITY();";

            cmd.Parameters.AddWithValue("@cpf", titular.Cpf);
            cmd.Parameters.AddWithValue("@rg", titular.Rg);
            cmd.Parameters.AddWithValue("@nome", titular.Nome);
            cmd.Parameters.AddWithValue("@nome_mae", titular.NomeMae);
            cmd.Parameters.AddWithValue("@nome_pai", titular.NomePai);
            cmd.Parameters.AddWithValue("@data_nasc", titular.DatNasc);
            cmd.Parameters.AddWithValue("@email", titular.Email);
            cmd.Parameters.AddWithValue("@telefone", titular.Telefone);
            cmd.Parameters.AddWithValue("@celular", titular.Celular);

            try
            {
                cmd.Connection = con.Conectar();
                codPessoa = Convert.ToInt32(cmd.ExecuteScalar());
                //con.Desconectar();

                cmd.Parameters.Clear();

                cmd.CommandText = @"insert into enderecos (cep, rua, numero, bairro, complemento, cidade, estado, cod_pessoa)" +
                    "values (@cep, @rua, @numero, @bairro, @complemento, @cidade, @estado, @cod_pessoa);";

                cmd.Parameters.AddWithValue("@cep", titular.endereco.Cep);
                cmd.Parameters.AddWithValue("@rua", titular.endereco.Rua);
                cmd.Parameters.AddWithValue("@numero", titular.endereco.Numero);
                cmd.Parameters.AddWithValue("@bairro", titular.endereco.Bairro);
                cmd.Parameters.AddWithValue("@complemento", titular.endereco.Complemento);
                cmd.Parameters.AddWithValue("@cidade", titular.endereco.Cidade);
                cmd.Parameters.AddWithValue("@estado", titular.endereco.Estado);
                cmd.Parameters.AddWithValue("@cod_pessoa", codPessoa);

                try
                {
                    //cmd.Connection = con.Conectar();
                    cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into historicomedico (cardiaco, asma, genetico, deficiente, mental, cancer, alzheimer)" +
                        "values (@cardiaco, @asma, @genetico, @deficiente, @mental, @cancer, @alzheimer);" +
                        "; SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@cardiaco", titular.historico.Cardiaco);
                    cmd.Parameters.AddWithValue("@asma", titular.historico.Asma);
                    cmd.Parameters.AddWithValue("@genetico", titular.historico.Genetico);
                    cmd.Parameters.AddWithValue("@deficiente", titular.historico.Deficiente);
                    cmd.Parameters.AddWithValue("@mental", titular.historico.Mental);
                    cmd.Parameters.AddWithValue("@cancer", titular.historico.Cancer);
                    cmd.Parameters.AddWithValue("@alzheimer", titular.historico.Alzheimer);

                    try
                    {
                        codHistorico = Convert.ToInt32(cmd.ExecuteScalar());

                        cmd.Parameters.Clear();

                        cmd.CommandText = @"insert into contratos (data_contrato, cod_plano, cod_pessoafisica, status)" +
                            "values (@data_contrato, @cod_plano, @cod_pessoafisica, 1)" +
                            "; SELECT SCOPE_IDENTITY();";

                        cmd.Parameters.AddWithValue("@data_contrato", titular.contrato.DatContrato);
                        cmd.Parameters.AddWithValue("@cod_plano", titular.Plano);
                        cmd.Parameters.AddWithValue("@cod_pessoafisica", codPessoa);

                        try
                        {
                            codContrato = Convert.ToInt32(cmd.ExecuteScalar());

                            cmd.Parameters.Clear();

                            cmd.CommandText = @"insert into titulares (cod_pessoafisica, cod_contrato, cod_historico)" +
                                "values (@cod_pessoafisica, @cod_contrato, @cod_historico)";

                            cmd.Parameters.AddWithValue("@cod_pessoafisica", codPessoa);
                            cmd.Parameters.AddWithValue("@cod_contrato", codContrato);
                            cmd.Parameters.AddWithValue("@cod_historico", codHistorico);

                            try
                            {
                                cmd.ExecuteNonQuery();

                                con.Desconectar();

                                this.Mensagem = "Titular cadastrado";
                            }
                            catch (Exception e)
                            {
                                this.Mensagem = "Erro no cadastro.\n" + e.Message;
                            }
                        }
                        catch (Exception e)
                        {
                            this.Mensagem = "Erro no cadastro.\n" + e.Message;
                        }
                    }
                    catch (Exception e)
                    {
                        this.Mensagem = "Erro no cadastro.\n" + e.Message;
                    }
                }
                catch (Exception e)
                {
                    this.Mensagem = "Erro no cadastro.\n" + e.Message;
                }
            }
            catch (Exception e)
            {
                this.Mensagem = "Erro no cadastro.\n" + e.Message;
            }
        }

        public Titular pesquisarTitular(String cpf)
        {
            SqlCommand cmd = new SqlCommand();

            Titular titular = new Titular();

            cmd.CommandText = @"SELECT TOP 1
	            A.id_titular,
	            B.nome,
	            B.cpf,
	            B.rg,
	            B.data_nasc,
	            B.nome_mae,
	            B.nome_pai,
	            B.telefone,
	            B.celular,
	            B.email,
	            C.cep,
	            C.rua,
	            C.numero,
	            C.bairro,
	            C.complemento,
	            C.estado,
	            C.cidade,
	            D.data_contrato,
	            D.[status],
	            E.nome_plano,
	            E.preco_plano,
	            E.tipo_plano,
	            F.cardiaco,
	            F.asma,
	            F.genetico,
	            F.mental,
	            F.cancer,
	            F.alzheimer,
	            F.deficiente
            FROM titulares A INNER JOIN pessoasfisicas B ON
	            A.cod_pessoafisica = B.id_pessoafisica
            INNER JOIN enderecos C ON
	            A.cod_pessoafisica = C.cod_pessoa
            INNER JOIN contratos D ON
	            A.cod_contrato = D.id_contrato
            INNER JOIN planos E ON
	            D.cod_plano = E.id_plano
            INNER JOIN historicomedico F ON
	            A.cod_historico = F.id_historico
            WHERE
                B.cpf = @cpf AND
                D.[status] = 1";

            cmd.Parameters.AddWithValue("@cpf", cpf);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    titular.Cpf = dr["cpf"].ToString();
                    titular.Rg = dr["rg"].ToString();
                    titular.Nome = dr["nome"].ToString();
                    titular.NomeMae = dr["nome_mae"].ToString();
                    titular.NomePai = dr["nome_pai"].ToString();
                    titular.DatNasc = DateTime.Parse(dr["data_nasc"].ToString());
                    titular.Telefone = dr["telefone"].ToString();
                    titular.Celular = dr["celular"].ToString();
                    titular.Email = dr["email"].ToString();
                    titular.Plano = dr["nome_plano"].ToString();
                    titular.endereco.Cep = dr["cep"].ToString();
                    titular.endereco.Rua = dr["rua"].ToString();
                    titular.endereco.Numero = dr["numero"].ToString();
                    titular.endereco.Complemento = dr["complemento"].ToString();
                    titular.endereco.Bairro = dr["bairro"].ToString();
                    titular.endereco.Estado = dr["estado"].ToString();
                    titular.endereco.Cidade = dr["cidade"].ToString();
                    titular.historico.Cardiaco = (bool)dr["cardiaco"];
                    titular.historico.Asma = (bool)dr["asma"];
                    titular.historico.Genetico = (bool)dr["genetico"];
                    titular.historico.Mental = (bool)dr["mental"];
                    titular.historico.Cancer = (bool)dr["cancer"];
                    titular.historico.Alzheimer = (bool)dr["alzheimer"];
                    titular.historico.Deficiente = (bool)dr["deficiente"];
                    titular.contrato.DatContrato = DateTime.Parse(dr["data_contrato"].ToString());
                    titular.contrato.Status = (bool)dr["status"];

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

            return titular;
        }

        public void excluirTitular(String cpf)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = @"update pessoasfisicas set cpf = 0 where cpf = @cpf;";

            cmd.Parameters.AddWithValue("@cpf", cpf);

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