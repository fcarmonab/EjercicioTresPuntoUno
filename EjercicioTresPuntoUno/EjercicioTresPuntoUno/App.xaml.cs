using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EjercicioTresPuntoUno.Models;
using EjercicioTresPuntoUno.Service;
using EjercicioTresPuntoUno.Views;
using System.IO;

namespace EjercicioTresPuntoUno
{
    public partial class App : Application
    {
            static Empleados _empleados;

            public static Empleados Empleados
        {
                get
                {
                    if (_empleados == null)
                    {
                    _empleados = new Empleados(Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empleados.db3"));
                    }

                    return _empleados;
                }
            }


            public App()
            {
                InitializeComponent();

                DependencyService.Register<MockDataStore>();
                MainPage = new AppShell();
            }

            protected override void OnStart()
            {
            }

            protected override void OnSleep()
            {
            }

            protected override void OnResume()
            {
            }
        }
    }
