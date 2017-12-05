using _13_DataContext.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
/*
 * ANOTACIONES:
 * -Sólo funciona la imagen de la izquierda, básicamente porque no me ha dado tiempo al no darme cuenta de que lo suyo era hacer x:bind
 * 
 * -Algunos círculos están mal colocados, pero bueno, es lo menos importante creo
 * 
 * -elipsedif1img1 significa elipse de la diferencia 1 en la imagen 1, lo mismo para las demás
 * 
 * -No hay nada de código behind
 * 
 * -Recalcar que sólo me quedaba hacer la imagen de la izquierda, el código es el mismo que el del viewmodel pero aplicado a la segunda imagen.
 * */
namespace ExamenPrimeraEv.ViewModel
{
    public class MainPageVM :clsVMBase
    {
        private double _elipsedif1img1;
        private double _elipsedif2img1;
        private double _elipsedif3img1;
        private double _elipsedif4img1;
        private double _elipsedif5img1;
        private double _elipsedif6img1;
        private double _elipsedif7img1;
        private int _diferenciasEncontradas;

        public MainPageVM()
        {
            _diferenciasEncontradas = 0;
            _elipsedif2img1 = 0;
            _elipsedif3img1 = 0;
            _elipsedif4img1 = 0;
            _elipsedif5img1 = 0;
            _elipsedif6img1 = 0;
            _elipsedif7img1 = 0;
            _elipsedif1img1 = 0;
            NotifyPropertyChanged("elipsedif1img1");
            NotifyPropertyChanged("elipsedif2img1");
            NotifyPropertyChanged("elipsedif3img1");
            NotifyPropertyChanged("elipsedif4img1");
            NotifyPropertyChanged("elipsedif5img1");
            NotifyPropertyChanged("elipsedif6img1");
            NotifyPropertyChanged("elipsedif7img1");
        }
        public double elipsedif1img1
        {
            get
            {
                return _elipsedif1img1;
            }
            set
            {
                _elipsedif1img1 = value;
                NotifyPropertyChanged("elipsedif1img1");

            }
        }
        public double elipsedif2img1
        {
            get
            {
                return _elipsedif2img1;
            }
            set
            {
                _elipsedif2img1 = value;
                NotifyPropertyChanged("elipsedif2img1");
            }
        }
        public double elipsedif3img1
        {
            get
            {
                return _elipsedif3img1;
            }
            set
            {
                _elipsedif3img1 = value;
                NotifyPropertyChanged("elipsedif3img1");
            }
        }
        public double elipsedif4img1
        {
            get
            {
                return _elipsedif4img1;
            }
            set
            {
                _elipsedif4img1 = value;
                NotifyPropertyChanged("elipsedif4img1");
            }
        }
        public double elipsedif5img1
        {
            get
            {
                return _elipsedif5img1;
            }
            set
            {
                _elipsedif5img1 = value;
                NotifyPropertyChanged("elipsedif5img1");
            }
        }
        public double elipsedif6img1
        {
            get
            {
                return _elipsedif6img1;
            }
            set
            {
                _elipsedif6img1 = value;
                NotifyPropertyChanged("elipsedif6img1");
            }
        }
        public double elipsedif7img1
        {
            get
            {
                return _elipsedif7img1;
            }
            set
            {
                _elipsedif7img1 = value;
                NotifyPropertyChanged("elipsedif7img1");
            }
        }

        public int diferenciasEncontradas
        {
            get
            {
                return _diferenciasEncontradas;
            }
            set
            {
                _diferenciasEncontradas = value;
            }
        }
        /// <summary>
        /// Aquí notificamos que se ha pulsado la elipse que corresponde a la diferencia 1 de la imagen 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Diferencia1_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif1img1 != 1)
            {
                _elipsedif1img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif1img1");
            }
            mostrarVolverAJugarAsync();

        }
        public void Diferencia2_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Ellipse elipse = (Ellipse)sender;
            if(elipse.Opacity!=1)
            {
                elipse.Opacity = 1;
                diferenciasEncontradas++;
            }
        }
        public void Diferencia3_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif3img1 != 1)
            {
                _elipsedif3img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif3img1");
            }
            mostrarVolverAJugarAsync();
        }
        public void Diferencia4_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif4img1 != 1)
            {
                _elipsedif4img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif4img1");
            }
            mostrarVolverAJugarAsync();
        }
        public void Diferencia5_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif5img1 != 1)
            {
                _elipsedif5img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif5img1");
            }
            mostrarVolverAJugarAsync();
        }
        public void Diferencia6_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif6img1 != 1)
            {
                _elipsedif6img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif6img1");
            }
            mostrarVolverAJugarAsync();
        }
        public void Diferencia7_1_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (_elipsedif7img1 != 1)
            {
                _elipsedif7img1 = 1;
                _diferenciasEncontradas++;
                NotifyPropertyChanged("elipsedif7img1");
            }
            mostrarVolverAJugarAsync();
        }

        public async void mostrarVolverAJugarAsync()
        {
            if (_diferenciasEncontradas == 7)
            {
                ContentDialog volverAJugar = new ContentDialog();
                volverAJugar.Title = "Volver a Jugar";
                volverAJugar.Content = "¿Desea volver a jugar?";
                volverAJugar.PrimaryButtonText = "Si";
                volverAJugar.SecondaryButtonText = "No";
                ContentDialogResult resultado = await volverAJugar.ShowAsync();
                if (resultado == ContentDialogResult.Primary)
                {
                    _diferenciasEncontradas = 0;
                    _elipsedif2img1 = 0;
                    _elipsedif3img1 = 0;
                    _elipsedif4img1 = 0;
                    _elipsedif5img1 = 0;
                    _elipsedif6img1 = 0;
                    _elipsedif7img1 = 0;
                    _elipsedif1img1 = 0;
                    NotifyPropertyChanged("elipsedif1img1");
                    NotifyPropertyChanged("elipsedif2img1");
                    NotifyPropertyChanged("elipsedif3img1");
                    NotifyPropertyChanged("elipsedif4img1");
                    NotifyPropertyChanged("elipsedif5img1");
                    NotifyPropertyChanged("elipsedif6img1");
                    NotifyPropertyChanged("elipsedif7img1");
                }
            }
        }
    }
}
