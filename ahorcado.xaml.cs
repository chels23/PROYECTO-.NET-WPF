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
    /// Lógica de interacción para ahorcado.xaml
    /// </summary>
    /// 
    public partial class ahorcado : Window
    {
        // ATRIBUTOS
        private int numeroAleatorio;
        private int intentosRestantes = 5;

        public ahorcado()
        {
            InitializeComponent();
            // Generar un número aleatorio del 1 al 100
            Random random = new Random();
            numeroAleatorio = random.Next(1, 101);

        }

        private void btnComprobar_Click(object sender, RoutedEventArgs e)
        {
            int numero;

            // Intentar convertir el número ingresado a entero
            try
            {
                numero = Convert.ToInt32(txtNumero.Text);
            }
            catch (FormatException)
            {
                lblResultado.Text = "Ingrese un número válido.";
                return;
            }

            // Comprobar si el número es correcto o no
            if (numero == numeroAleatorio)
            {
                lblResultado.Text = "¡Correcto! ¡Has ganado!";
                btnComprobar.IsEnabled = false;
                btnReiniciar.IsEnabled = true;
            }
            else
            {
                intentosRestantes--;

                if (intentosRestantes == 0)
                {
                    lblResultado.Text = "Lo siento, has perdido. El número era " + numeroAleatorio;
                    btnComprobar.IsEnabled = false;
                    btnReiniciar.IsEnabled = true;
                }
                else if (numero < numeroAleatorio)
                {
                    lblResultado.Text = "El número es demasiado bajo. Intentos restantes: " + intentosRestantes;
                }
                else
                {
                    lblResultado.Text = "El número es demasiado alto. Intentos restantes: " + intentosRestantes;
                }
            }
        }

        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            // Generar un número aleatorio nuevo y reiniciar los intentos restantes
            Random random = new Random();
            numeroAleatorio = random.Next(1, 101);
            intentosRestantes = 5;

            // Limpiar el cuadro de texto y el resultado anterior
            txtNumero.Text = "";
            lblResultado.Text = "";

            // Habilitar el botón de comprobar
            btnComprobar.IsEnabled = true;
            btnReiniciar.IsEnabled = false;
        }
    }
}
