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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show("¿Estás seguro de que deseas irte?",
                                            "Question",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question);

            // User doesn't want to close, cancel closure
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void Close_Window1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Open_Page2(object sender, RoutedEventArgs e)
        {
            // El contenido central se cambia con la nueva pantalla
            myFrame.Navigate(new Page1());
        }

        private void Open_Juegos(object sender, RoutedEventArgs e)
        {
         

            // Otra opción es dejar el Frame a null
            myFrame.Content= null;
        }
    }
}
