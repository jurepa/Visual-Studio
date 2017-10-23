using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _05_Controls
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string[] sugerencias = new String[] { "Jackelyn Kulpa","Holly Garman","Julio Deckert","Sherrell Medcalf","Misha Enfinger","Rufus Klock","Carrol Thatcher","Audry Izquierdo","Sabrina Hinderliter","Arianna Grinnell","Armando Wilder","Venice Devita","Rema Linehan","Nena Woodberry","Marcella Boone","Lawrence Kneip","Bradly Racey","Leonardo Suttle","Nydia Caplan","Faith Turrell","Jere Singleton","Carleen Barrette","Benita Belgarde","Dede Bellows","Ethel Beaty","Gianna Epperly","Maxwell Wareham","Samantha Mielke","Tia Espinoza","Bryon Bankhead","Malinda Cuenca","Ming Conyer","Madonna Wear","Zachery Wymer","Ralph Turco","Trudi Chewning","Waneta Theriault","Jaleesa Callas","Penney Wold","Shirleen Blackwater","Rosendo Selman","Larue Galaz","Sulema Lavigne","Krista Macfarlane","Ferne Halls","Helga Burstein","Julee Oliveros","German Dixson","Floria Holdeman","Romelia Mcleish" };
        public MainPage()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Detecta cuando cambia el tecto del autosuggestbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                if (sender.Text.Length > 1)
                {
                    sender.ItemsSource = this.getSugerencias(sender.Text);
                }
                else
                {
                    sender.ItemsSource = new String[] { "No hay sugerencias" };
                }
            }
        }
        /// <summary>
        /// Muestra las sugerencias
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        private string[] getSugerencias(string texto)
        {
            string[] resultado = null;
            resultado = sugerencias.Where(x => x.Contains(texto)).ToArray();
            return resultado;
        }

        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            MediaPlayerElement media = this.video;
            Slider slider = this.Slider;

            if (slider != null)
            {
                media.MediaPlayer.Volume = slider.Value;
            }
        }

    }
}
