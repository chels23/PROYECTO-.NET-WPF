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
    /// Lógica de interacción para Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        // Abrir el juego del ahorcado (te abre a una ventana en blanco)
        private void abrir_ahorcado(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            ahorcado ahorcado = new ahorcado();
            ahorcado.Show();
        }

        // Abrir el juego de la sopa de letras (te abre a una ventana en blanco)
        private void abrir_sopa(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            sopa sopa = new sopa();
            sopa.Show();
        }

        // Abrir el jeugo de tres en raya (te abre a una ventana nueva en la que puedes jugar al tres en raya)
        private void abrir_tresenraya(object sender, RoutedEventArgs e)
        {
            // Abrimos una ventana nueva modal
            tresenraya tresenraya = new tresenraya();
            tresenraya.Show();
        }
    }
}
