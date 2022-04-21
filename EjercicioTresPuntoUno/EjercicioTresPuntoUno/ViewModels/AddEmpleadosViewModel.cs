using EjercicioTresPuntoUno.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EjercicioTresPuntoUno.ViewModels
{
    public class AddEmpleadosViewModel : BaseEmpleadosViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public AddEmpleadosViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();

            EmpleadoInfo = new InfoEmpleados();
        }

        private async void OnSave()
        {
            var empleado = EmpleadoInfo;
            await App.Empleados.AgregarEmpleadosAsync(empleado);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
