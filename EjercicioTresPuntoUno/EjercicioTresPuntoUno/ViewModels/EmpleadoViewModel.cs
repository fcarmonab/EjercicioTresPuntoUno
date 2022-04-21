using EjercicioTresPuntoUno.Models;
using EjercicioTresPuntoUno.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EjercicioTresPuntoUno.ViewModels
{
    public class EmpleadoViewModel : BaseEmpleadosViewModel
    {
        public Command LoadEmpleadoCommand { get; }
        public ObservableCollection<InfoEmpleados> EmpleadosInfos { get; }

        public Command AddEmpleadoComand { get; }
        public Command EmpleadoTappedEdit { get; }

        public Command EmpleadoTappedDelete { get; }

        public EmpleadoViewModel(INavigation _navigation)
        {
            LoadEmpleadoCommand = new Command(async () => await ExecuteLoadEmpleCommand());
            EmpleadosInfos = new ObservableCollection<InfoEmpleados>();
            AddEmpleadoComand = new Command(OnAddEmpleado);
            EmpleadoTappedEdit = new Command<InfoEmpleados>(OnEditEmpleado);
            EmpleadoTappedDelete = new Command<InfoEmpleados>(OnDeleteEmpleado);
            Navigation = _navigation;
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadEmpleCommand()
        {
            IsBusy = true;

            try
            {
                EmpleadosInfos.Clear();
                var prodList = await App.Empleados.GetEmpleadosAsync();
                foreach (var prod in prodList)
                {
                    EmpleadosInfos.Add(prod);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddEmpleado(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddEmpleadosPage));
        }

        private async void OnEditEmpleado(InfoEmpleados prod)
        {
            await Navigation.PushAsync(new AddEmpleadosPage(prod));
        }

        private async void OnDeleteEmpleado(InfoEmpleados prod)
        {
            if(prod == null)
            {
                return;
            }

            await App.Empleados.EliminarEmpleadosAsync(prod.Id);
            await ExecuteLoadEmpleCommand();
        }
    }
}
