using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace ExamenPrimeraEvEj2.Model
{
    public class ListPersona
    {
        public ObservableCollection<Persona> curso1;
        public ObservableCollection<Persona> curso2;
        public ListPersona()
        {
            Persona persona1 = new Persona();
            Persona persona2 = new Persona();
            Persona persona3 = new Persona();
            Persona persona4 = new Persona();
            Persona persona5 = new Persona();
            Persona persona6 = new Persona();
            persona1.idPersona = 1;
            persona1.nombre = "David Abraham";
            persona1.apellidos = "Aguilar";
            persona2.idPersona = 2;
            persona2.nombre = "Carlos";
            persona2.apellidos = "Alberto Vadillo";
            persona3.idPersona = 3;
            persona3.nombre = "Daniel";
            persona3.apellidos = "Gordillo Rodríguez";
            persona4.idPersona = 1;
            persona4.nombre = "Pablo";
            persona4.apellidos = "Jarana";
            persona5.idPersona = 2;
            persona5.nombre = "Manuel";
            persona5.apellidos = "González Quirós";
            persona6.idPersona = 3;
            persona6.nombre = "Iván";
            persona6.apellidos = "Castillo Calle";
            curso2 = new ObservableCollection<Persona>();
            curso2.Add(persona4);
            curso2.Add(persona5);
            curso2.Add(persona6);
            curso1 = new ObservableCollection<Persona>();
            curso1.Add(persona1);
            curso1.Add(persona2);
            curso1.Add(persona3);
        }
        public void addPersonaListado1(Persona p)
        {
            curso1.Add(p);
        }
        public void dropPersonaListado1(int pos)
        {
            curso1.RemoveAt(pos);
        }
        public int sizeListado1()
        {
            return curso1.Count;
        }

        public Persona getPersonaListado1(int pos)
        {
            return curso1.ElementAt(pos);
        }
    }
}