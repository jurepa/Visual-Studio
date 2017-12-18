using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FechaConverter.Converter
{
    public class ConverterStringToFecha
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string fecha = (string)value;

            DateTimeOffset fechaDate = DateTimeOffset.Parse(fecha);

            return fechaDate;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
