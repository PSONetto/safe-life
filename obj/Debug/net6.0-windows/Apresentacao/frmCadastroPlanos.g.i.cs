#pragma checksum "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "696087737C42A21CF6AAB57017219D5E08284BBF"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using SafeLife.Apresentacao;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SafeLife.Apresentacao {
    
    
    /// <summary>
    /// frmCadastroPlanos
    /// </summary>
    public partial class frmCadastroPlanos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNome;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPreco;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbTipo;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCadastrar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnVoltar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SafeLife;component/apresentacao/frmcadastroplanos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txbNome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txbPreco = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txbTipo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.btnCadastrar = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
            this.btnCadastrar.Click += new System.Windows.RoutedEventHandler(this.btnCadastrar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnVoltar = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\..\Apresentacao\frmCadastroPlanos.xaml"
            this.btnVoltar.Click += new System.Windows.RoutedEventHandler(this.btnVoltar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

