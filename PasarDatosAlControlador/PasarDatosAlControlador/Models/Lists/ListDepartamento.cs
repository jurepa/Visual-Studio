﻿using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasarDatosAlControlador.Models.Lists
{   /// <summary>
/// Clase ListDepartamento, la cual es una lista de departamentos
/// </summary>
    public class ListDepartamento
    {
        public List<Departamento> lista { get; set; }
        /// <summary>
        /// Constructor vacío. Cargamos la lista de departamentos, del tirón
        /// </summary>
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
        /// <summary>
        /// Métodos chorra
        /// </summary>
        /// <param name="p"></param>
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
        /// <summary>
        /// Devuelve un objeto Departamento dependiendo el id pasado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departamento getDepartamentoPorId(int id)
        {
            Departamento d=null;
            bool encontrado = false;
            for (int i = 1; i <= lista.Count()&&encontrado==false; i++)
            {
                if (i == lista.ElementAt(i).idDepartamento)
                {
                    d = lista.ElementAt(i);
                    encontrado = true;
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