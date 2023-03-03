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

namespace WPF_Prueba
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


        /*
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            Window1 window1 = new Window1();
            window1.Owner = this;
            window1.Show();
        }
        */
        private void Open_Login(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            Window2 window2 = new Window2();
            window2.Owner = this;
            window2.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            var result = MessageBox.Show("¿Estás seguro de que deseas irte?",
                                            "Question",
                                            MessageBoxButton.YesNo,
                                            MessageBoxImage.Question) ;

            // User doesn't want to close, cancel closure
            if (result == MessageBoxResult.No)
                e.Cancel = true;
        }
    }
}
