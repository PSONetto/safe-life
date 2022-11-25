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
    /// Lógica interna para frmCadastroUsuario.xaml
    /// </summary>
    public partial class frmCadastroUsuario : Window
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }


        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Controle controle = new Controle();

            List<String> listTitular = new List<String>();
            listTitular.Add("0");
            listTitular.Add(txbUsuario.Text);
            listTitular.Add(txbEmail.Text);
            listTitular.Add(txbSenha.Text);

            controle.cadastrarUsuario(listTitular);

            MessageBox.Show(controle.Mensagem, "Erro no Cadastro", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
