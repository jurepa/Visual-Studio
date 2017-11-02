﻿using System;
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

namespace Solarizr.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.MyFrame.Navigate(typeof(Inicio));
        }

        private void toggleButton_Click(object sender, RoutedEventArgs e)
        {
            mySplitView.IsPaneOpen = !mySplitView.IsPaneOpen;
        }

        private void btnlogout_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

        private void btn3_Click(System.Object sender, RoutedEventArgs e)
        {
            this.MyFrame.Navigate(typeof(About));
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.MyFrame.Navigate(typeof(Inicio));
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.MyFrame.Navigate(typeof(Appointments));
        }
    }
}
