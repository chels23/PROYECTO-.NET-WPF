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

namespace PROYECTO_WPF.NET
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

        // Los comandos definidos siempre se pueden ejecutar con este método que asigna el valor True a CanExecute
        private void MyCommands_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Este método se llama desde el menú New y desde el botón situado a la izquierda
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            // El contenido central se cambia con la nueva pantalla
            //myFrame.Navigate(new Page1());
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            Window1 window1 = new Window1();
            window1.Owner = this;
            window1.Show();
        }
    }
}
