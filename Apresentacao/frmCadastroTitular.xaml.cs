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
    /// Lógica interna para frmCadastroTitular.xaml
    /// </summary>
    public partial class frmCadastroTitular : Window
    {
        String Estado;
        String Plano;

        public frmCadastroTitular()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string content = ((ComboBoxItem)cmbEstado.SelectedItem).Content as string;
            if (content != null)
                this.Estado = content;
        }

        private void comboBox_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {
            string content = ((ComboBoxItem)cmbPlano.SelectedItem).Content as string;
            if (content != null)
                this.Plano = content;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
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
            listTitular.Add(cmbPlano.Text);
            listTitular.Add((bool)chbCardiaco.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbAsma.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbGenetica.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbMental.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbCancer.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbAlzheimer.IsChecked ? "1" : "0");
            listTitular.Add((bool)chbDeficiencia.IsChecked ? "1" : "0");
            listTitular.Add(dtpDatContrato.Text);

            controle.cadastrarTitular(listTitular);

            if (controle.Mensagem.ToLower().Contains("erro"))
            {
                MessageBox.Show(controle.Mensagem, "Erro no Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Cadastrado com Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
