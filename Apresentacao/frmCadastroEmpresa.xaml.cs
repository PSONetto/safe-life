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
    /// Lógica interna para frmCadastroEmpresa.xaml
    /// </summary>
    public partial class frmCadastroEmpresa : Window
    {
        String Estado;
        public frmCadastroEmpresa()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string content = ((ComboBoxItem)cmbEstado.SelectedItem).Content as string;
            if (content != null)
                this.Estado = content;
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();

            List<String> listEmpresa = new List<String>();
            listEmpresa.Add("0");
            listEmpresa.Add(txbNome.Text);
            listEmpresa.Add(txbCNPJ.Text);
            listEmpresa.Add(txbTelefone.Text);
            listEmpresa.Add(txbEmail.Text);
            listEmpresa.Add(txbRua.Text);
            listEmpresa.Add(txbNumero.Text);
            listEmpresa.Add(txbBairro.Text);
            listEmpresa.Add(txbComplemento.Text);
            listEmpresa.Add(this.Estado);
            listEmpresa.Add(txbCidade.Text);

            controle.cadastrarEmpresa(listEmpresa);

            MessageBox.Show(controle.Mensagem, "Erro no Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
