using EjercicioTresPuntoUno.ViewModels;
using EjercicioTresPuntoUno.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EjercicioTresPuntoUno
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(AddEmpleadosPage), typeof(AddEmpleadosPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
