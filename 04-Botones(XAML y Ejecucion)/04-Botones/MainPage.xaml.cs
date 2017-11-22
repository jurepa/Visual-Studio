using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _04_Botones
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        { 
            this.InitializeComponent();
            Button boton = new Button();
            Border borde = new Border();
            StackPanel stack = this.stkBotones;
            boton.Content = "Boton 3";
            boton.HorizontalAlignment = HorizontalAlignment.Center;
            boton.VerticalAlignment = VerticalAlignment.Center;
            boton.Height = 70;
            boton.Width = 200;
            boton.FontFamily = new FontFamily("Verdana");
            boton.FontSize = 16;
            borde.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Yellow);
            boton.Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            boton.FontWeight = FontWeights.Bold;
            boton.BorderBrush = borde.BorderBrush;
            
            stack.Children.Add(boton);

            /* boton.Click += (sender, args) =>
               {
                   //Método a ejecutar cuando se hace click sobre el botón

               };*/
            boton.Click += Boton3_Click; //Cuando se haga click sobre ese boton, se llamará al método boton3_click
        }

        private void Boton3_Click(object sender, RoutedEventArgs e)
        {
            this.boton1.Content = "Cambiado";
        }
    }
}