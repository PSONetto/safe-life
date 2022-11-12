using SafeLife.Apresentacao;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SafeLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();

            controle.buscarUsuario(txbUsuario.Text, pwbSenha.Password);
            if (controle.Mensagem.Equals(""))
            {
                frmInicio frmI = new frmInicio();
                frmI.ShowDialog();
            }
            else
            {
                MessageBox.Show(controle.Mensagem, "Erro no Login", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
