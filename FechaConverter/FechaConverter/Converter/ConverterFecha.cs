﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace FechaConverter.Converter
{
    public class ConverterFecha:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset fecha = (DateTimeOffset)value;
            string fechaTexto = fecha.Date.ToString();

            return fechaTexto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            string fecha = (string)value;

            DateTimeOffset fechaDate = DateTimeOffset.Parse(fecha);

            return fechaDate;
        }
    }
}
