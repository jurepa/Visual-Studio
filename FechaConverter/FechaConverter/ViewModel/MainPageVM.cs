using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FechaConverter.ViewModel
{
    public class MainPageVM
    {
        private string _textoFecha { get; set; }
        private DateTimeOffset _fechaDatePicker { get; set; }





        public MainPageVM()
        {
            _fechaDatePicker = DateTimeOffset.Now;
        }
        public string textoFecha
        {
            get
            {
                return _textoFecha;
            }

            set
            {
                _textoFecha = value;
            }
        }
        public DateTimeOffset fechaDatePicker
        {
            get
            {
                return _fechaDatePicker;
            }
            set
            {
                _fechaDatePicker = value;
            }
        }
    }
}
