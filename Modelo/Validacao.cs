using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SafeLife.Modelo
{
    internal class Validacao
    {
        public String Mensagem { get; set; }

        private static Regex apenasNumeros = new Regex(@"^[0-9]*$", RegexOptions.IgnorePatternWhitespace);
        private static Regex apenasLetras = new Regex(@"^[\p{L}\s]+$", RegexOptions.IgnorePatternWhitespace);

        public bool validaCPF(String cpf)
        {
            if (cpf.Length != 11 || !apenasNumeros.IsMatch(cpf))
            {
                return false;
            }

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    igual = false;
                }
            }

            if (igual || cpf == "12345678909")
            {
                return false;
            }

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(cpf[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return false;
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return false;
                }
            }

            else
            {
                if (numeros[10] != 11 - resultado)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidaCep(string cep)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(cep, ("[0-9]{5}[0-9]{3}"));
        }

        public void validarUsuario(String login, String senha)
        {
            this.Mensagem = "";
            try
            {
                if (login.Equals(""))
                    this.Mensagem = "Insira um login!";
                if (senha.Equals(""))
                    this.Mensagem = "Insira uma senha!";
            }
            catch
            {
                this.Mensagem = "Login ou Senha inválidos!";
            }

        }
        public void validarTitular(List<String> titular)
        {
            this.Mensagem = "";
            try
            {
                DateTime hoje = DateTime.UtcNow.Date;
                DateTime dataMaxima = hoje.AddYears(-18);
                DateTime dataMinima = new DateTime(1900, 01, 01);




                if (titular[1] == "")
                {
                    this.Mensagem = "O campo nome é obrigatório!";
                    return;
                }
                else
                {
                    if (!apenasLetras.IsMatch(titular[1]))
                    {
                        this.Mensagem = "O campo nome deve conter apenas letras!";
                        return;
                    }
                }

                if (titular[2] == "")
                {
                    this.Mensagem = "O campo data de nascimento é obrigatório!";
                    return;
                }
                else
                {
                    if (DateTime.Compare(DateTime.Parse(titular[2]), dataMaxima) >= 0)
                    {
                        this.Mensagem = "O titular deve mais que 18 anos!";
                        return;
                    }
                    else if (DateTime.Compare(DateTime.Parse(titular[2]), dataMinima) <= 0)
                    {
                        this.Mensagem = "A data de nascimento deve ser posterior a 1900!";
                        return;
                    }
                }

                if (titular[3] == "")
                {
                    this.Mensagem = "O campo CPF é obrigatório!";
                    return;
                }
                else
                {
                    if (!validaCPF(titular[3]))
                    {
                        this.Mensagem = "CPF inválido!";
                        return;
                    }
                }

                if (titular[4] == "")
                {
                    this.Mensagem = "O campo RG é obrigatório!";
                    return;
                }

                if (titular[5] == "")
                {
                    this.Mensagem = "O campo Nome Mãe é obrigatório!";
                    return;
                }
                else
                {
                    if (!apenasLetras.IsMatch(titular[5]))
                    {
                        this.Mensagem = "O campo Nome Mãe deve conter apenas letras!";
                        return;
                    }
                }

                if (titular[6] != "")
                {
                    if (!apenasLetras.IsMatch(titular[6]))
                    {
                        this.Mensagem = "O campo Nome Pai deve conter apenas letras!";
                        return;
                    }
                }

                if (!apenasNumeros.IsMatch(titular[7]))
                {
                    this.Mensagem = "O campo Telefone deve conter apenas números!";
                    return;
                }

                if (titular[8] == "")
                {
                    this.Mensagem = "O campo Celular é obrigatório!";
                    return;
                }
                else
                {
                    if (!apenasNumeros.IsMatch(titular[8]))
                    {
                        this.Mensagem = "O campo Celular deve conter apenas números!";
                        return;
                    }
                }

                if (titular[9] == "")
                {
                    this.Mensagem = "O campo E-mail é obrigatório!";
                    return;
                }
                else
                {
                    if (!titular[9].Contains('@') || !titular[9].Contains(".com"))
                    {
                        this.Mensagem = "Email inválido!";
                        return;
                    }
                }

                if (titular[10] == "")
                {
                    this.Mensagem = "O campo CEP é obrigatório!";
                    return;
                }
                else
                {
                    if (!apenasNumeros.IsMatch(titular[10]))
                    {
                        this.Mensagem = "O campo CEP deve conter apenas números!";
                        return;
                    }
                    else
                    {
                        if (!ValidaCep(titular[10]))
                        {
                            this.Mensagem = "CEP inválido!";
                            return;
                        }
                    }
                }

                if (titular[11] == "")
                {
                    this.Mensagem = "O campo Rua é orbigatório!";
                    return;
                }

                if (titular[12] == "")
                {
                    this.Mensagem = "O campo Número é orbigatório!";
                    return;
                }
                else
                {
                    if (!apenasNumeros.IsMatch(titular[12]))
                    {
                        this.Mensagem = "O campo Número deve conter apenas números!";
                        return;
                    }
                }

                if (titular[13] == "")
                {
                    this.Mensagem = "O campo Bairro é obrigatório!";
                    return;
                }

                if (titular[15] == "")
                {
                    this.Mensagem = "O campo Estado é obrigatório!";
                    return;
                }

                if (titular[16] == "")
                {
                    this.Mensagem = "O campo Cidade é obrigatório!";
                    return;
                }
                else
                {
                    if (!apenasLetras.IsMatch(titular[16]))
                    {
                        this.Mensagem = "O campo Cidade deve conter apenas letras!";
                        return;
                    }
                }
            }
            catch
            {
                this.Mensagem = "Login ou Senha inválidos!";
            }
        }

        public void validarEmpresa(List<String> listaEmpresa)
        {
            this.Mensagem = "";


        }

        public void validarUsuario(List<String> listaUsuario)
        {
            this.Mensagem = "";
        }
    }
}
