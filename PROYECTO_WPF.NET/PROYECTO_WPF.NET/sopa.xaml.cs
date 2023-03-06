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
using System.Windows.Threading;
using static System.Formats.Asn1.AsnWriter;


namespace PROYECTO_WPF.NET
{
    /// <summary>
    /// Lógica de interacción para sopa.xaml
    /// </summary>
    public partial class sopa : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer(); // crea una nueva instancia del tiempo del despachador llamada gameTimer
        List<Ellipse> removeThis = new List<Ellipse>(); //  una lista de elipse llamada remove this se usará para eliminar los círculos en los que hacemos clic del juego
                                                        // se encuentran todas las variables necesarios declarados para este juego
        int spawnRate = 60; // esta es la tasa de generación predeterminada de los círculos
        int currentRate; // la tasa actual ayudará a agregar un intervalo entre el desove de los círculos
        int lastScore = 0; // esto contendrá la última puntuación jugada para este juego
        int health = 350; // salud total del jugador al comienzo del juego
        int posX; // x posicion en x de los circulos
        int posY; // y posicion en y de los circulos
        int score = 0; // puntuacion
        double growthRate = 0.6; // la tasa de crecimiento predeterminada para cada círculo en el juego
        Random rand = new Random(); // a random number generator
                                    // a continuación se encuentran las dos clases de reproductores multimedia, una para el sonido pulsado y otra para el sonido pop
        MediaPlayer playClickSound = new MediaPlayer();
        MediaPlayer playerPopSound = new MediaPlayer();
        // a continuación se encuentran los dos buscadores de ubicación URI para ambos archivos mp3 que importamos para este juego
        Uri ClickedSound;
        Uri PoppedSound;
        // color de los circulos
        Brush brush;
        public sopa()
        {
            InitializeComponent();

            gameTimer.Tick += GameLoop;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start(); // iniciar el temporizador
            currentRate = spawnRate; // establece la tasa actual en el número de tasa de generación

            // ubique ambos archivos mp3 dentro de la carpeta de sonido y agréguelos al URI correcto a continuación
            ClickedSound = new Uri("C:\\Users\\arist\\Downloads\\PROYECTO_WPF.NET\\PROYECTO_WPF.NET\\PROYECTO_WPF.NET\\clickedpop.mp3");
            PoppedSound = new Uri("C:\\Users\\arist\\Downloads\\PROYECTO_WPF.NET\\PROYECTO_WPF.NET\\PROYECTO_WPF.NET\\pop.mp3");

        }

        private void GameLoop(object? sender, EventArgs e)
        {
            // este es el evento del bucle del juego, todas las instrucciones dentro de este evento se ejecutarán cada vez que el temporizador marque
            // primero actualizamos la puntuación y mostramos la última puntuación en las etiquetas
            txtScore.Content = "Score: " + score;
            txtLastScore.Content = "Last Score: " + lastScore;
            // reducir 2 de la tasa actual a medida que pasa el tiempo
            currentRate -= 2;
            // si la tasa actual es inferior a 1
            if (currentRate < 1)
            {
                // restablecer la tasa actual a la tasa de generación
                currentRate = spawnRate;
                // generar un número aleatorio para el valor X e Y de los círculos
                posX = rand.Next(15, 700);
                posY = rand.Next(50, 350);
                // generar un color aleatorio para los círculos y guardarlo dentro del pincel
                brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));
                // crea una nueva elipse llamada circulo
                // este círculo tendrá una etiqueta, altura y ancho predeterminados, color de borde y relleno
                Ellipse circle = new Ellipse
                {
                    Tag = "circle",
                    Height = 10,
                    Width = 10,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = brush
                };
                //coloca el círculo recién creado en el lienzo con la posición X e Y generada anteriormente
                Canvas.SetLeft(circle, posX);
                Canvas.SetTop(circle, posY);
                // añadir el circulo a canvas
                MyCanvas.Children.Add(circle);
            }
            // el for cada bucle de abajo encontrará cada elipse dentro de canvas
            foreach (var x in MyCanvas.Children.OfType<Ellipse>())
            {
                // buscamos en el canvas y encontramos la elipse que existe dentro de el
                x.Height += growthRate; // aumentar la altura del circulo
                                        // aumentar el ancho del circulo
                x.Width += growthRate;
                x.RenderTransformOrigin = new Point(0.5, 0.5); // grow from the centre of the circle by resetting the transform origin
                                                               // si el ancho del círculo supera los 70 queremos hacer estallar el círculo
                if (x.Width > 70)
                {
                    // si el ancho es superior a 70, agregue este círculo para eliminar esta lista
                    removeThis.Add(x);
                    health -= 15; // reduce la puntuacion de salud a 15 
                    playerPopSound.Open(PoppedSound); // cargar el uri de sonido reventado dentro del reproductor de medios de sonido reventado
                    playerPopSound.Play(); // ahora reproduce el sonido pop
                }
            }// final de cada ciclo
             // si la salud está por encima de 1
            if (health > 1)
            {
                // vincular el rectángulo de la barra de salud al entero de salud
                healthBar.Width = health;
            }
            else
            {
                // si la salud está por debajo de 1, ejecute la función game over
                GameOverFunction();
            }
            // para eliminar la elipse del juego necesitamos otra para cada bucle
            foreach (Ellipse i in removeThis)
            {
                // esto para cada bucle buscará cada elipse que exista dentro de la lista de eliminar esta
                MyCanvas.Children.Remove(i); // cuando encuentre uno lo eliminará del canvas
            }
            // si la puntuación es superior a 5
            if (score > 5)
            {
                // acelerar la tasa de generación
                spawnRate = 25;
            }
            // si la puntuación es superior a 20
            if (score > 20)
            {
                // acelerar el crecimiento y la tasa de generación
                spawnRate = 15;
                growthRate = 1.5;
            }
        }

        private void CanvasClicking(object sender, MouseButtonEventArgs e)
        {
            // este evento de clic está vinculado dentro del lienzo, debemos verificar si hemos hecho clic en la elipse
            // si la fuente original en la que se hizo clic es una elipse
            if (e.OriginalSource is Ellipse)
            {
                // crea una elipse local y la vincula a la fuente original
                Ellipse circle = (Ellipse)e.OriginalSource;
                // ahora elimine esa elipse en la que hicimos clic del lienzo
                MyCanvas.Children.Remove(circle);
                // sumamos 1 al puntaje
                score++;
                // carga el uri de sonido en el que se hizo clic en el reproductor multimedia de sonido de clic de reproducción y reproduce el archivo de sonido
                playClickSound.Open(ClickedSound);
                playClickSound.Play();
            }


        }
        private void GameOverFunction()
        {
            // esta es la función de fin del juego
            gameTimer.Stop(); // primero detiene el cronómetro del juego
            // mostrar un cuadro de mensaje en la pantalla final y esperar a que el jugador haga clic en Aceptar
            MessageBox.Show("Game Over" + Environment.NewLine + "Puntuación: " + score + Environment.NewLine + "Acepta para jugar de nuevo!", "CCJ GAMELAB: ");
            // después de que el jugador hizo clic en Aceptar ahora necesitamos hacer un para cada ciclo
            foreach (var y in MyCanvas.Children.OfType<Ellipse>())
            {
                // encuentra todas las elipses existentes que están en la pantalla y las agrega a eliminar esta lista
                removeThis.Add(y);
            }
            // aquí necesitamos otro para cada bucle para eliminar todo lo que está dentro de la lista eliminar esta
            foreach (Ellipse i in removeThis)
            {
                MyCanvas.Children.Remove(i);
            }
            // restablece todos los valores del juego a los valores predeterminados, incluida la eliminación de todos los puntos suspensivos de eliminar esta lista
            growthRate = .6;
            spawnRate = 60;
            lastScore = score;
            score = 0;
            currentRate = 5;
            health = 350;
            removeThis.Clear();
            gameTimer.Start();
        }
    }
}
