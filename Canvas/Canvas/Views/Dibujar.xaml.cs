using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace Canvas.Views
{

    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Dibujar : Page
    {
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        public Dibujar()
        {
            this.InitializeComponent();
            
        }
        private void dibujar_Click(Object o, RoutedEventArgs r)
        {
            inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Touch;
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;
            drawingAttributes.Color = Windows.UI.Colors.Black;
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
            cambiaColor.Visibility = Visibility.Visible;
        }
        private void borrar_Click(Object o, RoutedEventArgs r)
        {
            inkCanvas.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Erasing;
            cambiaColor.Visibility = Visibility.Collapsed;
        }
        private void cambiarColor_Click(Object o, RoutedEventArgs r)
        {
            if (drawingAttributes.Color == Colors.Black)
            {
                drawingAttributes.Color = Colors.Cyan;
            }
            else
            {
                drawingAttributes.Color = Colors.Black;
            }
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
        }
        private void atras_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
