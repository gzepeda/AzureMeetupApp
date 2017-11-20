using System;
using System.Collections.Generic;
using System.Text;

namespace AzureMeetupApp.Model
{
    public class Entidad : IEntidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Avatar { get; set; }

        public Entidad()
        {

        }
    }

    public static class EntidadFactory
    {
        public static Entidad GetEntidad(string n, string d, string a)
        {
            Entidad ent = new Entidad();
            ent.Nombre = n;
            ent.Descripcion = d;
            ent.Avatar = a;

            return ent;
        }
    }
}
