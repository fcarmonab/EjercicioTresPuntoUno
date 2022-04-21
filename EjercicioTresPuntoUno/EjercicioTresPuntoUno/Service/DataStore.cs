using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioTresPuntoUno.Service
{
    public interface DataStore<T>
    {
        Task<bool> AgregarItemAsync(T item);
        Task<bool> ActualizarItemAsync(T item);
        Task<bool> EliminarItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
