using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using EjercicioTresPuntoUno.Models;

namespace EjercicioTresPuntoUno.Service
{
    public class MockDataStore: DataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "1er. item", Description="Detalle o descripción de Empleado." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "2do. item", Description="Detalle o descripción de Empleado." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "3er. item", Description="Detalle o descripción de Empleado." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "4to. item", Description="Detalle o descripción de Empleado."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "5to. item", Description="Detalle o descripción de Empleado."},
                new Item { Id = Guid.NewGuid().ToString(), Text = "6to. item", Description="Detalle o descripción de Empleado." }
            };
        }

        public async Task<bool> AgregarItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> ActualizarItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> EliminarItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
