using SafeLife.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SafeLife.Apresentacao
{
    /// <summary>
    /// Lógica interna para frmCadastroBeneficiario.xaml
    /// </summary>
    public partial class frmCadastroBeneficiario : Window
    {
        public String CPF;
        public frmCadastroBeneficiario()
        {
            InitializeComponent();
        }

        public frmCadastroBeneficiario(String cpf)
        {
            this.CPF = cpf;
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();

            List<String> listaBeneficiario = new List<String>();
            listaBeneficiario.Add("0");
            listaBeneficiario.Add(txbNome.Text);
            listaBeneficiario.Add(dtpDatNasc.Text);
            listaBeneficiario.Add(txbCPF.Text);
            listaBeneficiario.Add(txbRG.Text);
            listaBeneficiario.Add(txbNomeMae.Text);
            listaBeneficiario.Add(txbNomePai.Text);
            listaBeneficiario.Add(txbTelefone.Text);
            listaBeneficiario.Add(txbCelular.Text);
            listaBeneficiario.Add(txbEmail.Text);
            listaBeneficiario.Add(txbCEP.Text);
            listaBeneficiario.Add(txbRua.Text);
            listaBeneficiario.Add(txbNumero.Text);
            listaBeneficiario.Add(txbBairro.Text);
            listaBeneficiario.Add(txbComplemento.Text);
            listaBeneficiario.Add(cmbEstado.Text);
            listaBeneficiario.Add(txbCidade.Text);
            listaBeneficiario.Add(txbRelacionamento.Text);

            controle.cadastrarBeneficiario(listaBeneficiario, this.CPF);

            if (controle.Mensagem.ToLower().Contains("erro"))
            {
                MessageBox.Show(controle.Mensagem, "Erro no Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Cadastrado com Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
