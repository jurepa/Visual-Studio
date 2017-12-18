using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ListaPersonas.Models
{
    public class ConverterPersona : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            Persona p = (Persona)value;
            return p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
