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

namespace _03_HelloWorld_UWP
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

        /// <summary>
        /// Este método será ejecutado cuando se pulse el botón
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boton_Click(object sender, RoutedEventArgs e)
        {
            String mensaje = texto.Text;

            if (String.IsNullOrWhiteSpace(mensaje))
            {
                mostrarError();
            }
            else
            {
                mostrarOk(mensaje);
            }
        }
        /// <summary>
        /// Se ejecutará cuando se clickee el botón y haya espacios en blanco o no se escriba nada
        /// </summary>
        private async void mostrarError()
        {
            ContentDialog error = new ContentDialog
            {
                Title = "Error",
                Content = "Debe introducir un nombre",
                CloseButtonText = "Vale maquina",
            };
            ContentDialogResult result = await error.ShowAsync();
        }
        /// <summary>
        /// Se ejecutará cuando se clickee el botón correctamente
        /// </summary>
        /// <param name="mensaje"></param>
        private async void mostrarOk(String mensaje)
        {
            ContentDialog mensajeOk = new ContentDialog
            {
                Title = "Hey crack",
                Content = $"Hola {mensaje}",
                CloseButtonText = "Vale maquina",
            };
            ContentDialogResult result = await mensajeOk.ShowAsync();
        }

    }
}
