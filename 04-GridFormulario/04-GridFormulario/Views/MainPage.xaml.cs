using _04_GridFormulario.Models;
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

namespace _04_GridFormulario
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
        /// Este método se ejecutará al hacer click sobre el botón enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime temp;
            string nombre = this.nombre.Text.ToString();
            string apellidos = this.apellidos.Text.ToString();
            string fecha = this.fechaNacimiento.Text.ToString();
            Persona persona = new Persona();
            persona = (Persona)this.DataContext;

            if (String.IsNullOrWhiteSpace(nombre))
            {
                this.errorNombre.Text = "Introduzca un nombre válido";
            }
            else
            {
                this.errorNombre.Text = "";
            }
            if (String.IsNullOrWhiteSpace(apellidos))
            {
                this.errorApellidos.Text = "Introduzca apellidos válidos";
            }
            else
            {
                this.errorApellidos.Text = "";
            }
            if (!DateTime.TryParse(fecha, out temp))
            {
                this.errorFecha.Text = "Introduce una fecha válida";
            }
            else
            {
                this.errorFecha.Text = "";

            }
            if (!String.IsNullOrWhiteSpace(nombre) && !String.IsNullOrWhiteSpace(apellidos) && DateTime.TryParse(fecha, out temp))
            {
                mostrarOk();
            }
        }
        /// <summary>
        /// Este método se ejecutará al haber introducido correctamente
        /// </summary>
        private async void mostrarOk()
        {
            MessageDialog message = new MessageDialog("'Yo juego una y me voy' - Manuá, 2017");
            await message.ShowAsync();
        }
    }
}
