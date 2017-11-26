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
                EntidadFactory.GetEntidad("Guillermo Zepeda", "Speaker 2", "https://pbs.twimg.com/profile_images/893926592493346821/PA0V37ui_400x400.jpg"),
                EntidadFactory.GetEntidad("David Ayala", "Speaker 1", "https://pbs.twimg.com/profile_images/378800000234578545/caddd07dbed2fdcd862a0bd0cacaf2b3_400x400.jpeg"),
                EntidadFactory.GetEntidad("Christian Melendez", "Host ", "https://pbs.twimg.com/profile_images/773551145029505025/WQzb4ngh_400x400.jpg"),
            };
        }
    }
}
