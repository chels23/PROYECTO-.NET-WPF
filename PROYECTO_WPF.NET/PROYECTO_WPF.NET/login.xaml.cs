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

namespace PROYECTO_WPF.NET
{
    /// <summary>
    /// Lógica de interacción para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            String usuario = txtUser.Text;
            String password = txtPass.Password.ToString();

            if (usuario.Equals("user") && password.Equals("1234"))
            {
                // Abrimos una ventana nueva modal
                Window1 window1 = new Window1();
              
                window1.Show();
                this.Close();

            }
            else {
                MessageBox.Show("Usuario incorrecto");
            }
        }


    }
}
