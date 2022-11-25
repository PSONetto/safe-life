using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeLife.DAL
{
    internal class FuncDAO
    {
        Conexao con = new Conexao();
        SqlDataReader dr;

        public String Mensagem = "";

        public void cadastrarFunc(Titular titular)
        {
            SqlCommand cmd = new SqlCommand();

            int codPessoa;
            int codHistorico;
            int codContrato;
            int idEmpresa;

            cmd.CommandText = @"select top 1 id_pessoajuridica from pessoasjuridicas where cnpj = @cnpj" +
                "; SELECT SCOPE_IDENTITY();";
            cmd.Parameters.AddWithValue("@cnpj", titular.CodEmpresa);

            try
            {
                cmd.Connection = con.Conectar();
                idEmpresa = Convert.ToInt32(cmd.ExecuteScalar());

                cmd.Parameters.Clear();

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

                                cmd.CommandText = @"insert into titulares (cod_pessoafisica, cod_contrato, cod_historico, id_pessoajuridica)" +
                                    "values (@cod_pessoafisica, @cod_contrato, @cod_historico, @id_pessoajuridica)";

                                cmd.Parameters.AddWithValue("@cod_pessoafisica", codPessoa);
                                cmd.Parameters.AddWithValue("@cod_contrato", codContrato);
                                cmd.Parameters.AddWithValue("@cod_historico", codHistorico);
                                cmd.Parameters.AddWithValue("@id_pessoajuridica", idEmpresa);

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
            catch (Exception e)
            {
                this.Mensagem = "Erro no cadastro.\n" + e.Message;
            }

        }

        public void excluirFunc(String cpf)
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
