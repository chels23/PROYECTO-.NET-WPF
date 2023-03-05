using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Lógica de interacción para tictactoe.xaml
    /// </summary>
    public partial class tictactoe : Window
    {

        int turno;
        int puntoX, puntoO;

        public tictactoe()
        {
            InitializeComponent();
        }


        private void Window_Loader(object sender, RoutedEventArgs e)
        {
            turno = 1;
        }

        private void ganar(String botonContenido)
        {
            if ((Boton1.Content == botonContenido && Boton2.Content == botonContenido && Boton3.Content == botonContenido)

                | (Boton1.Content == botonContenido & Boton4.Content == botonContenido & Boton7.Content == botonContenido)

                | (Boton1.Content == botonContenido & Boton5.Content == botonContenido & Boton9.Content == botonContenido)

                | (Boton2.Content == botonContenido & Boton5.Content == botonContenido & Boton8.Content == botonContenido)

                | (Boton3.Content == botonContenido & Boton6.Content == botonContenido & Boton9.Content == botonContenido)

                | (Boton4.Content == botonContenido & Boton5.Content == botonContenido & Boton6.Content == botonContenido)

                | (Boton7.Content == botonContenido & Boton8.Content == botonContenido & Boton9.Content == botonContenido)

                | (Boton3.Content == botonContenido & Boton5.Content == botonContenido & Boton7.Content == botonContenido))
            {
                if (botonContenido == "O")
                {
                    MessageBox.Show("¡Ha ganado el jugador O!");
                    JugadorO.Content = ++puntoO;
                } else if (botonContenido == "X")
                {
                    MessageBox.Show("¡Ha ganado el jugador X!");
                    JugadorX.Content = ++puntoX;
                }

                resetearBotones();

            } else
            {
                foreach (Button btn in WrapPanel.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("¡Empate! Nadie gana hoy.");
                resetearBotones();
            }
        }
        private void resetearBotones()
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.IsEnabled = true;
                btn.Content = "";
            }
        }

        private void boton_jugar(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turno == 1)
            {
                btn.Content = "O";
                turnoJugador.Content = "X";
            }
            else
            {
                btn.Content = "X";
                turnoJugador.Content = "O";
            }
            btn.IsEnabled = false;
            ganar(btn.Content.ToString());
            turno += 1;
            if (turno > 2)
                turno = 1;
        }

        private void boton_resetear(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }

            JugadorO.Content = 0;
            JugadorX.Content = 0;
            turno = 1;
        }
    }
}
