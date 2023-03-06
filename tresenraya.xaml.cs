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
    public partial class tresenraya : Window
    {
        // Contadores para los puntos de cada jugador y para saber cuál es cada turno
        int turno;
        int puntoX, puntoO;

        public tresenraya()
        {
            InitializeComponent();
        }

        // Un diálogo que te habla de las instrucciones
        private void show_mensaje(object sender, RoutedEventArgs e)
        {
            // Para que salga el mensaje
            MessageBoxResult result = MessageBox.Show("¿Cóooomo? ¿Que no sabes jugar al Tres en raya? ¿Quieres que te enseñe?", "Instrucciones del tres en raya", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                // Si le da a Yes (Sí), da las instrucciones
                case MessageBoxResult.Yes:
                    MessageBox.Show("Estas son las instrucciones tú: \n" +
                        "Es un juego de dos personas, el jugador X y el jugador O. \n" +
                        "Para ganar tienes que tener tres X o tres O en línea (horizontal, vertical o diagonal).\n" +
                        "Y ya, no hay más misterio, no te rayes y empieza a jugar, al final del día vas a entenderlo.", "Instrucciones del tres en raya");
                    break;
                // Si le da a No, sale del diálogo pero con un texto diferente
                case MessageBoxResult.No:
                    MessageBox.Show("Vale, vale, no hacía falta ser tan borde.", "Instrucciones del tres en raya");
                    break;
                // Si le da a Cancelar, hace lo mismo que no pero con otro texto diferente
                case MessageBoxResult.Cancel:
                    MessageBox.Show("¿Okaaay? Tampoco quería enseñarte.", "Instrucciones del tres en raya");
                    break;
            }
        }

        // Cuando carga la ventana, por defecto empieza el turno 1 (X)
        private void Window_Loader(object sender, RoutedEventArgs e)
        {
            turno = 1;
        }

        // Para ganar, hay que poner los botones en cierto orden
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
                // Si los botones en raya son O
                if (botonContenido == "O")
                {
                    // Sale un mensaje de que ha ganado O
                    MessageBox.Show("¡Ha ganado el jugador O!");
                    // Y se suman al contador 1 punto
                    JugadorO.Content = ++puntoO;
                } else if (botonContenido == "X")
                {
                    // Si los botones son X, gana X y se envia un mensaje
                    MessageBox.Show("¡Ha ganado el jugador X!");
                    // Y se suman al contador 1 punto
                    JugadorX.Content = ++puntoX;
                }

                // Se resetean los botones
                resetearBotones();

            } else
            {
                // Para cada botón dentro del wrap panel
                foreach (Button btn in WrapPanel.Children)
                {
                    // Si todos los botones han sido pulsado
                    if (btn.IsEnabled == true)
                        return;
                }
                // Y ningún O o X han ganado, es empate
                MessageBox.Show("¡Empate! Nadie gana hoy.");
                resetearBotones();
            }
        }
        private void resetearBotones()
        {
            foreach (Button btn in WrapPanel.Children)
            {
                // Por cada botón hacer que puedan ser cliqueables
                btn.IsEnabled = true;
                // Y poner su contenido a vacío
                btn.Content = "";
            }
        }

        // Jugar
        private void boton_jugar(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            
            // Dependiendo del turno que se ponga X u O
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
            // Y hacer que el botón no puedas ser cliqueable
            btn.IsEnabled = false;
            ganar(btn.Content.ToString());
            turno += 1;
            if (turno > 2)
                turno = 1;
        }

        // Se resetea todo, tanto el juego como los puntos y el turno
        private void boton_resetear(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in WrapPanel.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }

            JugadorO.Content = 0;
            puntoO = 0;
            JugadorX.Content = 0;
            puntoX = 0;
            turno = 2;
            turnoJugador.Content = "X";
        }
    }
}
