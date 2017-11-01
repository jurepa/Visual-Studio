using ReproductorMusica.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace ReproductorMusica
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string artista;
            ComboBoxItem selected = this.SelectList.SelectedItem as ComboBoxItem;
            if (selected != null)
            {
                artista = selected.Content.ToString();
                switch (artista)
                {
                    case "Lucky Chops":
                        this.Frame.Navigate(typeof(LuckyChop));
                        break;
                    case "Borgore":
                        this.Frame.Navigate(typeof(Borgore));
                        break;
                    case "Alvarillolag1":
                        mostrarAlvarillo();
                        break;
                    case "Oliver Heldens":
                        this.Frame.Navigate(typeof(OliverHeldens));
                        break;
                    case "David Guetta":
                        this.Frame.Navigate(typeof(DavidGuetta));
                        break;
                }
            }
            else
            {
                mostrarError();
            }
            
        }
        private async void mostrarError()
        {
            MessageDialog message = new MessageDialog("No has seleccionado ningun artista crack", "Error");
            await message.ShowAsync();
        }
        private async void mostrarAlvarillo()
        {
            MessageDialog message = new MessageDialog("Este kién é","What");
            await message.ShowAsync();
        }

    }
}
