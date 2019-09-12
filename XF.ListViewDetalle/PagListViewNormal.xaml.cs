using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.ListViewDetalle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagListViewNormal : ContentPage
    {
        public ObservableCollection<DatosPersona> Personas { get; set; }
        public DatosPersona personaSelected { get; set; }
        public PagListViewNormal()
        {
            InitializeComponent();
            Personas = new ObservableCollection<DatosPersona>();
            for (int i = 0; i <= 100; i++)
            {
                Personas.Add(new DatosPersona { id = i, Nombre = "Jendri Ponce", IsVisible = false, Hobbie = "Ajedres", Ocupacion = "Freelance", Icono = "down.png" });
            }

            //Personas = new ObservableCollection<DatosPersona> {
         
            //new DatosPersona{ id=1,Nombre="Jendri Ponce",IsVisible=false,Hobbie="Ajedres",Ocupacion="Freelance", Icono="down.png"},
            //new DatosPersona{ id=2,Nombre="Marco Ayala",IsVisible=false,Hobbie="Voly",Ocupacion="Desarrollo Apps", Icono="down.png"},
            //new DatosPersona{ id=3,Nombre="Xavier Herrera",IsVisible=false,Hobbie="Autos",Ocupacion="Analista de compras", Icono="down.png"}
            //};
            lvDatos.ItemsSource = Personas;
        }

        private void LvDatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var persona = e.Item as DatosPersona;

            Hide(persona);
        }
        public void Hide(DatosPersona persona)
        {
            persona.IsVisible = true;
            persona.Icono = "up.png";
            Update(persona);
        }
        public void Update(DatosPersona persona)
        {
            int index = 0;
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
            lvDatos.ItemsSource = Personas;
        }
    }
}