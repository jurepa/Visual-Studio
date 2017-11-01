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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReproductorMusica.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Borgore : Page
    {
        public Borgore()
        {
            this.InitializeComponent();
        }
        private void pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotItem pivotItem = this.pivot.SelectedItem as PivotItem;
            string header;
            if (pivotItem != null)
            {
                header = pivotItem.Header.ToString();
                if (this.reproductor.CurrentState == MediaElementState.Playing)
                {
                    this.reproductor.Stop();
                }
                switch (header)
                {
                    case "Magic Trick":
                        this.reproductor.Source = new Uri("ms-appx:///Assets/Music/magic trick.mp3");
                        break;
                    case "Unicorn Zombie Apocalypse":
                        this.reproductor.Source = new Uri("ms-appx:///Assets/Music/unicorn.mp3");
                        break;
                    case "Domino":
                        this.reproductor.Source = new Uri("ms-appx:///Assets/Music/domino.mp3");
                        break;
                    case "Blasphemy":
                        this.reproductor.Source = new Uri("ms-appx:///Assets/Music/blasphemy.mp3");
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
