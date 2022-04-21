using EjercicioTresPuntoUno.Models;
using EjercicioTresPuntoUno.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EjercicioTresPuntoUno.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEmpleadosPage : ContentPage
    {
        public InfoEmpleados InfoEmpleados { get; set; }

        public AddEmpleadosPage()
        {
            InitializeComponent();
            BindingContext = new AddEmpleadosViewModel();
        }

        public AddEmpleadosPage(InfoEmpleados empleadoInfo)
        {
            InitializeComponent();
            BindingContext = new AddEmpleadosViewModel();

            if(empleadoInfo != null)
            {
                ((AddEmpleadosViewModel)BindingContext).EmpleadoInfo = empleadoInfo;
            }
        }
    }
}