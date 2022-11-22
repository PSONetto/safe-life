using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class BeneficiarioDAO
    {
        Conexao con = new Conexao();
        SqlDataReader dr;

        public String Mensagem = "";

        public void cadastrarBeneficiario(Beneficiario beneficiario, String cpf)
        {
            SqlCommand cmd = new SqlCommand();

            int codPessoa;
            int codTitular;

            cmd.CommandText = @"select top 1 a.id_titular from titulares a inner join pessoasfisicas b on " +
                "a.cod_pessoafisica = b.id_pessoafisica " +
                "where b.cpf = @cpf;";

            cmd.Parameters.AddWithValue("@cpf", cpf);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    codTitular = int.Parse(dr["id_titular"].ToString());
                    cmd.Parameters.Clear();

                    cmd.CommandText = @"insert into pessoasfisicas (cpf, rg, nome, nome_mae, nome_pai, data_nasc, email, telefone, celular)" +
                        "values (@cpf, @rg, @nome,  @nome_mae, @nome_pai, @data_nasc, @email, @telefone, @celular)" +
                        "; SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("@cpf", beneficiario.Cpf);
                    cmd.Parameters.AddWithValue("@rg", beneficiario.Rg);
                    cmd.Parameters.AddWithValue("@nome", beneficiario.Nome);
                    cmd.Parameters.AddWithValue("@nome_mae", beneficiario.NomeMae);
                    cmd.Parameters.AddWithValue("@nome_pai", beneficiario.NomePai);
                    cmd.Parameters.AddWithValue("@data_nasc", beneficiario.DatNasc);
                    cmd.Parameters.AddWithValue("@email", beneficiario.Email);
                    cmd.Parameters.AddWithValue("@telefone", beneficiario.Telefone);
                    cmd.Parameters.AddWithValue("@celular", beneficiario.Celular);

                    dr.Close();

                    try
                    {
                        cmd.Connection = con.Conectar();
                        codPessoa = Convert.ToInt32(cmd.ExecuteScalar());
                        //con.Desconectar();

                        cmd.Parameters.Clear();

                        cmd.CommandText = @"insert into enderecos (cep, rua, numero, bairro, complemento, cidade, estado, cod_pessoa)" +
                            "values (@cep, @rua, @numero, @bairro, @complemento, @cidade, @estado, @cod_pessoa);";

                        cmd.Parameters.AddWithValue("@cep", beneficiario.endereco.Cep);
                        cmd.Parameters.AddWithValue("@rua", beneficiario.endereco.Rua);
                        cmd.Parameters.AddWithValue("@numero", beneficiario.endereco.Numero);
                        cmd.Parameters.AddWithValue("@bairro", beneficiario.endereco.Bairro);
                        cmd.Parameters.AddWithValue("@complemento", beneficiario.endereco.Complemento);
                        cmd.Parameters.AddWithValue("@cidade", beneficiario.endereco.Cidade);
                        cmd.Parameters.AddWithValue("@estado", beneficiario.endereco.Estado);
                        cmd.Parameters.AddWithValue("@cod_pessoa", codPessoa);

                        try
                        {
                            cmd.ExecuteNonQuery();

                            cmd.Parameters.Clear();

                            cmd.CommandText = @"insert into beneficiarios (relacao_titular, cod_pessoafisica, cod_titular)" +
                                        "values (@relacao_titular, @cod_pessoafisica, @cod_titular)";

                            cmd.Parameters.AddWithValue("@relacao_titular", beneficiario.Relacao);
                            cmd.Parameters.AddWithValue("@cod_pessoafisica", codPessoa);
                            cmd.Parameters.AddWithValue("@cod_titular", codTitular);

                            try
                            {
                                cmd.ExecuteNonQuery();

                                con.Desconectar();

                                this.Mensagem = "Beneficiário cadastrado";
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
                else
                {
                    this.Mensagem = "Registro não encontrado";
                }

            }
            catch (Exception e)
            {
                this.Mensagem = "Erro de conexão com banco de dados\n" + e.Message;
            }
        }

        public Beneficiario pesquisarBeneficiario(String cpf)
        {
            SqlCommand cmd = new SqlCommand();

            Beneficiario beneficiario = new Beneficiario();

            cmd.CommandText = @"SELECT TOP 1
	                A.id_beneficiario,
                    A.relacao_titular,
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
	                nome_titular = E.nome,
	                cpf_titular = E.cpf
                FROM beneficiarios A INNER JOIN pessoasfisicas B ON
	                A.cod_pessoafisica = B.id_pessoafisica
                INNER JOIN enderecos C ON
	                A.cod_pessoafisica = C.cod_pessoa
                INNER JOIN titulares D ON
	                A.cod_titular = D.id_titular
                INNER JOIN pessoasfisicas E ON
	                D.cod_pessoafisica = E.id_pessoafisica
                WHERE
                    B.cpf = @cpf";

            cmd.Parameters.AddWithValue("@cpf", cpf);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    beneficiario.Cpf = dr["cpf"].ToString();
                    beneficiario.Rg = dr["rg"].ToString();
                    beneficiario.Nome = dr["nome"].ToString();
                    beneficiario.NomeMae = dr["nome_mae"].ToString();
                    beneficiario.NomePai = dr["nome_pai"].ToString();
                    beneficiario.DatNasc = DateTime.Parse(dr["data_nasc"].ToString());
                    beneficiario.Telefone = dr["telefone"].ToString();
                    beneficiario.Celular = dr["celular"].ToString();
                    beneficiario.Email = dr["email"].ToString();
                    beneficiario.endereco.Cep = dr["cep"].ToString();
                    beneficiario.endereco.Rua = dr["rua"].ToString();
                    beneficiario.endereco.Numero = dr["numero"].ToString();
                    beneficiario.endereco.Complemento = dr["complemento"].ToString();
                    beneficiario.endereco.Bairro = dr["bairro"].ToString();
                    beneficiario.endereco.Estado = dr["estado"].ToString();
                    beneficiario.endereco.Cidade = dr["cidade"].ToString();
                    beneficiario.Relacao = dr["relacao_titular"].ToString();
                    beneficiario.NomeTitular = dr["nome_titular"].ToString();
                    beneficiario.CPFTitular = dr["cpf_titular"].ToString();

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

            return beneficiario;
        }

        public void excluirBeneficiario(String cpf)
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
