using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace XF.ListViewDetalle
{
    public class MainViewModel
    {
        public ObservableCollection<DatosPersona> Personas { get; set; }
        public DatosPersona personaSelected { get; set; }
        public MainViewModel()
        {
            Personas = new ObservableCollection<DatosPersona> {
            new DatosPersona{ id=1,Nombre="Jendri Ponce",IsVisible=false,Hobbie="Ajedres",Ocupacion="Freelance", Icono="down.png"},
            new DatosPersona{ id=2,Nombre="Marco Ayala",IsVisible=false,Hobbie="Voly",Ocupacion="Desarrollo Apps", Icono="down.png"},
            new DatosPersona{ id=3,Nombre="Xavier Herrera",IsVisible=false,Hobbie="Autos",Ocupacion="Analista de compras", Icono="down.png"}
            };
        }
        public void Hide(DatosPersona persona)
        {
            persona.IsVisible = true;
            persona.Icono = "up.png";
            Update(persona);
        }
        public void Update(DatosPersona persona)
        {
            int index=0;
            if (personaSelected != null)
            {
                //antiguo dato
                index = Personas.IndexOf(personaSelected);
                Personas.Remove(personaSelected);
                personaSelected.Icono = "down.png";
                personaSelected.IsVisible = false;
                Personas.Insert(index, personaSelected);
            }
            //nuevo dato
            index = Personas.IndexOf(persona);
            Personas.Remove(persona);
            Personas.Insert(index, persona);
            personaSelected = persona;
        }
    }
}
