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
    /// Lógica interna para frmPEEBeneficiarios.xaml
    /// </summary>
    public partial class frmPEEBeneficiarios : Window
    {
        public frmPEEBeneficiarios()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            Beneficiario beneficiario = controle.pesquisarBeneficiario(txbPesquisar.Text);

            if (controle.Mensagem.Equals(""))
            {
                txbCPF.Text = beneficiario.Cpf.ToString();
                txbRG.Text = beneficiario.Rg;
                txbNome.Text = beneficiario.Nome;
                txbNomeMae.Text = beneficiario.NomeMae;
                txbNomePai.Text = beneficiario.NomePai;
                dtpDatNasc.Text = beneficiario.DatNasc.ToString();
                txbTelefone.Text = beneficiario.Telefone;
                txbCelular.Text = beneficiario.Celular;
                txbEmail.Text = beneficiario.Email;
                txbCEP.Text = beneficiario.endereco.Cep;
                txbRua.Text = beneficiario.endereco.Rua;
                txbNumero.Text = beneficiario.endereco.Numero;
                txbComplemento.Text = beneficiario.endereco.Complemento;
                txbBairro.Text = beneficiario.endereco.Bairro;
                cmbEstado.Text = beneficiario.endereco.Estado;
                txbCidade.Text = beneficiario.endereco.Cidade;
                txbRelacionamento.Text = beneficiario.Relacao;
                txbCPFTitular.Text = beneficiario.CPFTitular;
                txbNomeTitular.Text = beneficiario.NomeTitular;
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                txbCPF.Text = "";
                txbRG.Text = "";
                txbNome.Text = "";
                txbNomeMae.Text = "";
                txbNomePai.Text = "";
                dtpDatNasc.Text = "";
                txbTelefone.Text = "";
                txbCelular.Text = "";
                txbEmail.Text = "";
                txbCEP.Text = "";
                txbRua.Text = "";
                txbNumero.Text = "";
                txbBairro.Text = "";
                txbComplemento.Text = "";
                cmbEstado.Text = "";
                txbCidade.Text = "";
                txbRelacionamento.Text = "";
                txbCPFTitular.Text = "";
                txbNomeTitular.Text = "";
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
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

            controle.cadastrarBeneficiario(listaBeneficiario, txbCPFTitular.Text);

            if (controle.Mensagem.ToLower().Contains("erro"))
            {
                MessageBox.Show(controle.Mensagem, "Erro no Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Cadastrado com Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (txbCPF.Text != "")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Tem certeza de que deseja excluír este titular?", "Confirmação de Exclusão", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Controle controle = new Controle();

                    controle.excluirBeneficiario(txbCPF.Text);
                }
            }
            else
            {
                MessageBox.Show("Nenhum titular selecionado!", "Erro ao Excluír", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
