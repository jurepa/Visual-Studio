using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ListaPersonas.Models
{
    public class ListPersona
    {
        public ObservableCollection<Persona> listado;
        public ListPersona()
        {
            Persona persona1 = new Persona();
            Persona persona2 = new Persona();
            Persona persona3 = new Persona();
            persona1.idPersona = 1;
            persona1.nombre = "Pablo";
            persona1.apellidos = "Jarana";
            persona1.direccion = "Aquí";
            persona1.telefono = "No tengo";
            persona2.idPersona = 2;
            persona2.nombre = "Iván";
            persona2.apellidos = "Ivienen";
            persona2.direccion = "Allí";
            persona2.telefono = "Tampoco tiene";
            persona3.idPersona = 3;
            persona3.nombre = "Manu";
            persona3.apellidos = "Werty0LaBala";
            persona3.direccion = "No jave ni ond bibe hulio";
            persona3.telefono = "Jo k é";
            listado = new ObservableCollection<Persona>();
            listado.Add(persona1);
            listado.Add(persona2);
            listado.Add(persona3);
        }
        public void addPersona(Persona p)
        {
            listado.Add(p);
        }
        public void dropPersona(int pos)
        {
            listado.RemoveAt(pos);
        }
        public int size()
        {
            return listado.Count;
        }

        public Persona getPersona(int pos)
        {
            return listado.ElementAt(pos);
        }
    }
}