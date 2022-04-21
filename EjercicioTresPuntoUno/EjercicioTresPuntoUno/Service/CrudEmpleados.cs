using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EjercicioTresPuntoUno.Models;

namespace EjercicioTresPuntoUno.Service
{
    public interface CrudEmpleados
    {
        Task<bool> AgregarEmpleadosAsync(InfoEmpleados infoEmpleados);
        Task<bool> ActualizarEmpleadosAsync(InfoEmpleados infoEmpleados);
        Task<bool> EliminarEmpleadosAsync(int id);
        Task<InfoEmpleados> GetEmpleadosAsync(int id);
        Task<IEnumerable<InfoEmpleados>> GetEmpleadosAsync();
    }
}
