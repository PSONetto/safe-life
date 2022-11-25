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
    /// Lógica interna para frmPEETitular.xaml
    /// </summary>
    public partial class frmPEETitular : Window
    {
        public frmPEETitular()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();
            Titular titular = controle.pesquisarTitular(txbPesquisar.Text);

            if (controle.Mensagem.Equals(""))
            {
                txbCPF.Text = titular.Cpf.ToString();
                txbRG.Text = titular.Rg;
                txbNome.Text = titular.Nome;
                txbNomeMae.Text = titular.NomeMae;
                txbNomePai.Text = titular.NomePai;
                dtpDatNasc.Text = titular.DatNasc.ToString();
                txbTelefone.Text = titular.Telefone;
                txbCelular.Text = titular.Celular;
                txbEmail.Text = titular.Email;
                txbCEP.Text = titular.endereco.Cep;
                txbRua.Text = titular.endereco.Rua;
                txbNumero.Text = titular.endereco.Numero;
                txbComplemento.Text = titular.endereco.Complemento;
                txbBairro.Text = titular.endereco.Bairro;
                cmbEstado.Text = titular.endereco.Estado;
                txbCidade.Text = titular.endereco.Cidade;
                cmbPlano.Text = titular.Plano;
                chbCardiaco.IsChecked = titular.historico.Cardiaco;
                chbAsma.IsChecked = titular.historico.Asma;
                chbGenetica.IsChecked = titular.historico.Genetico;
                chbMental.IsChecked = titular.historico.Mental;
                chbCancer.IsChecked = titular.historico.Cancer;
                chbAlzheimer.IsChecked = titular.historico.Alzheimer;
                chbDeficiencia.IsChecked = titular.historico.Deficiente;
                dtpDatContrato.Text = titular.contrato.DatContrato.ToString();
                txbEmpresa.Text = titular.CodEmpresa;
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
                cmbPlano.Text = "";
                txbCEP.Text = "";
                txbRua.Text = "";
                txbNumero.Text = "";
                txbBairro.Text = "";
                txbComplemento.Text = "";
                cmbEstado.Text = "";
                txbCidade.Text = "";
                dtpDatContrato.Text = "";
                chbCardiaco.IsChecked = false;
                chbAsma.IsChecked = false;
                chbGenetica.IsChecked = false;
                chbMental.IsChecked = false;
                chbCancer.IsChecked = false;
                chbAlzheimer.IsChecked = false;
                chbDeficiencia.IsChecked = false;
                txbEmpresa.Text = "";
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();

            List<String> listTitular = new List<String>();
            listTitular.Add("0");
            listTitular.Add(txbNome.Text);
            listTitular.Add(dtpDatNasc.Text);
            listTitular.Add(txbCPF.Text);
            listTitular.Add(txbRG.Text);
            listTitular.Add(txbNomeMae.Text);
            listTitular.Add(txbNomePai.Text);
            listTitular.Add(txbTelefone.Text);
            listTitular.Add(txbCelular.Text);
            listTitular.Add(txbEmail.Text);
            listTitular.Add(txbCEP.Text);
            listTitular.Add(txbRua.Text);
            listTitular.Add(txbNumero.Text);
            listTitular.Add(txbBairro.Text);
            listTitular.Add(txbComplemento.Text);
            listTitular.Add(cmbEstado.Text);
            listTitular.Add(txbCidade.Text);
            listTitular.Add(cmbPlano.SelectedValue.ToString());
            listTitular.Add((bool)chbCardiaco.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbAsma.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbGenetica.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbMental.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbCancer.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbAlzheimer.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbDeficiencia.IsChecked ? "1" : "0");
            listTitular.Add(dtpDatContrato.Text);
            listTitular.Add(txbEmpresa.Text);

            controle.editarTitular(listTitular);

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
            if (txbCPF.Text != "")
            {
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Tem certeza de que deseja excluír este titular?", "Confirmação de Exclusão", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    Controle controle = new Controle();

                    controle.excluirTitular(txbCPF.Text);
                }
            }
            else
            {
                MessageBox.Show("Nenhum titular selecionado!", "Erro ao Excluír", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnAdicionarBeneficiario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroBeneficiario frmCadBenef = new frmCadastroBeneficiario(txbCPF.Text);
            frmCadBenef.ShowDialog();
        }
    }
}
