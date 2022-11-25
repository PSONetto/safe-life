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
    /// Lógica interna para frmPEEEmpresa.xaml
    /// </summary>
    public partial class frmPEEEmpresa : Window
    {
        public frmPEEEmpresa()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            Empresa empresa = controle.pesquisarEmpresa(txbPesquisar.Text);

            if (controle.Mensagem.Equals(""))
            {
                txbCNPJ.Text = empresa.CNPJ;
                txbNome.Text = empresa.Nome;
                txbTelefone.Text = empresa.Telefone;
                txbEmail.Text = empresa.Email;
                txbCEP.Text = empresa.endereco.Cep;
                txbRua.Text = empresa.endereco.Rua;
                txbNumero.Text = empresa.endereco.Numero;
                txbComplemento.Text = empresa.endereco.Complemento;
                txbBairro.Text = empresa.endereco.Bairro;
                cmbEstado.Text = empresa.endereco.Estado;
                txbCidade.Text = empresa.endereco.Cidade;
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Atenção", MessageBoxButton.OK, MessageBoxImage.Information);
                txbCNPJ.Text = "";
                txbNome.Text = "";
                txbTelefone.Text = "";
                txbEmail.Text = "";
                txbCEP.Text = "";
                txbRua.Text = "";
                txbNumero.Text = "";
                txbBairro.Text = "";
                txbComplemento.Text = "";
                cmbEstado.Text = "";
                txbCidade.Text = "";
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();

            List<String> listEmpresa = new List<String>();
            listEmpresa.Add("0");
            listEmpresa.Add(txbNome.Text);
            listEmpresa.Add(txbCNPJ.Text);
            listEmpresa.Add(txbTelefone.Text);
            listEmpresa.Add(txbEmail.Text);
            listEmpresa.Add(txbCEP.Text);
            listEmpresa.Add(txbRua.Text);
            listEmpresa.Add(txbNumero.Text);
            listEmpresa.Add(txbBairro.Text);
            listEmpresa.Add(txbComplemento.Text);
            listEmpresa.Add(cmbEstado.Text);
            listEmpresa.Add(txbCidade.Text);

            controle.cadastrarEmpresa(listEmpresa);

            if (controle.Mensagem.ToLower().Contains("erro"))
            {
                MessageBox.Show(controle.Mensagem, "Erro ao Editar", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Editado com Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (txbCNPJ.Text != "")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Tem certeza de que deseja excluír esta Empresa?", "Confirmação de Exclusão", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Controle controle = new Controle();

                    controle.excluirEmpresa(txbCNPJ.Text);
                }
            }
            else
            {
                MessageBox.Show("Nenhuma empresa selecionada!", "Erro ao Excluír", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnFuncionario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroFunc frmCadF = new frmCadastroFunc(txbPesquisar.Text);
            frmCadF.Show();
        }
    }
}
