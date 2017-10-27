using PasarDatosAlControlador.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasarDatosAlControlador.Models.Lists
{
    public class ListDepartamento
    {
        public List<Departamento> lista { get; set; }
        public ListDepartamento()
        {
            Departamento d1 = new Departamento(1,"Alergología");
            Departamento d2 = new Departamento(2, "Podología");
            Departamento d3 = new Departamento(3,"Odontología");
            Departamento d4 = new Departamento(4, "Cardiología");
            Departamento d5 = new Departamento(5, "Dermatología");
            lista = new List<Departamento>();
            lista.Add(d1);
            lista.Add(d2);
            lista.Add(d3);
            lista.Add(d4);
            lista.Add(d5);
        }
        public void addDepartamento(Departamento p)
        {
            lista.Add(p);
        }
        public void dropDepartamento(int pos)
        {
            lista.RemoveAt(pos);
        }
        public int size()
        {
            return lista.Count;
        }
        public Departamento getDepartamentoPorId(int id)
        {
            Departamento d=null;
            for (int i = 1; i <= lista.Count(); i++)
            {
                if (i == lista.ElementAt(i).idDepartamento)
                {
                    d = lista.ElementAt(i);
                }
            }
            return d;
        }
        public Departamento getDepartamento(int pos)
        {
            return lista.ElementAt(pos);
        }
    }
}