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
        private void Update(DatosPersona persona)
        {
            if (personaSelected != null)
            {
                //antiguo dato
                int index_old = Personas.IndexOf(personaSelected);
                Personas.Remove(personaSelected);
                personaSelected.Icono = "down.png";
                personaSelected.IsVisible = false;
                Personas.Insert(index_old, personaSelected);

                //nuevo dato
                int index = Personas.IndexOf(persona);
                Personas.Remove(persona);
                Personas.Insert(index, persona);

                personaSelected = persona;
            }
            else
            {
                //nuevo dato
                int index = Personas.IndexOf(persona);
                Personas.Remove(persona);
                Personas.Insert(index, persona);
                personaSelected = persona;
            }
            
            
            
            
            
            //if (personaSelected == persona)
            //{
            //    persona.IsVisible = !persona.IsVisible;
            //    Update(persona);
            //}
            //else
            //{
            //    if (personaSelected != null)
            //    {
            //        personaSelected.IsVisible = true;
            //        Update(personaSelected);
            //    }
            //    persona.IsVisible = true;
            //    Update(persona);
            //}
            //personaSelected = persona;

            
        }
    }
}
