using System;
using System.Collections.Generic;
using System.Text;

namespace AzureMeetupApp.Model
{
    public static class MockEntidad
    {
        public static Entidad[] GetEntidades()
        {
            return new Entidad[] {
                EntidadFactory.GetEntidad("Guillermo Zepeda", "Speaker 2", "https://lh4.googleusercontent.com/-beJhsrHrMEE/AAAAAAAAAAI/AAAAAAAABj8/hmoQOKfetPk/photo.jpg"),
                EntidadFactory.GetEntidad("David Ayala", "Speaker 1", "https://lh4.googleusercontent.com/-beJhsrHrMEE/AAAAAAAAAAI/AAAAAAAABj8/hmoQOKfetPk/photo.jpg"),
                EntidadFactory.GetEntidad("Christian Melendez", "Host ", "https://lh4.googleusercontent.com/-beJhsrHrMEE/AAAAAAAAAAI/AAAAAAAABj8/hmoQOKfetPk/photo.jpg"),
            };
        }
    }
}
