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
    /// Lógica interna para frmInicio.xaml
    /// </summary>
    public partial class frmInicio : Window
    {
        public frmInicio()
        {
            InitializeComponent();
        }

        public frmInicio(String nome)
        {
            InitializeComponent();
            lblBemvindo.Content = "Bem-vindo, " + nome + "!";
        }

        private void mniCadastroTitular_Click(object sender, EventArgs e)
        {
            frmCadastroTitular frmCad = new frmCadastroTitular();
            frmCad.ShowDialog();
        }

        private void mniPEETitular_Click(object sender, EventArgs e)
        {
            frmPEETitular frmPEE = new frmPEETitular();
            frmPEE.ShowDialog();
        }

        private void mniPEEBeneficiario_Click(object sender, EventArgs e)
        {
            frmPEEBeneficiarios frmPEEBenef = new frmPEEBeneficiarios();
            frmPEEBenef.ShowDialog();
        }

        private void mniCadastroEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroEmpresa frmCadEmp = new frmCadastroEmpresa();
            frmCadEmp.ShowDialog();
        }

        private void mniPEEEmpresa_Click(object sender, RoutedEventArgs e)
        {
            frmPEEEmpresa frmPEEEmp = new frmPEEEmpresa();
            frmPEEEmp.ShowDialog();
        }

        private void mniCadastroUsuario_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroUsuario frmCadUsu = new frmCadastroUsuario();
            frmCadUsu.ShowDialog();
        }
        
        private void mniPEEFunc_Click(object sender, RoutedEventArgs e)
        {
            frmPEEFunc frmPEEF = new frmPEEFunc();
            frmPEEF.ShowDialog();
        }
    }
}
