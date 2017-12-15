using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FechaConverter.ViewModel
{
    public class MainPageVM:clsVMBase
    {
        private string _textoFecha { get; set; }
        private DateTimeOffset _fechaDatePicker { get; set; }
        public MainPageVM()
        {
            _fechaDatePicker = DateTimeOffset.Now;
            NotifyPropertyChanged("fechaDatePicker");
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
                NotifyPropertyChanged("textoFecha");
                _fechaDatePicker = DateTimeOffset.Parse(_textoFecha);
                NotifyPropertyChanged("fechaDatePicker");
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
                _textoFecha = _fechaDatePicker.ToString();
                NotifyPropertyChanged("textoFecha");
                NotifyPropertyChanged("fechaDatePicker");
            }
        }
    }
}
