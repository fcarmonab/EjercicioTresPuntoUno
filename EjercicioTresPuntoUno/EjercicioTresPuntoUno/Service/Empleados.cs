using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using EjercicioTresPuntoUno.Models;
using System.Threading.Tasks;


namespace EjercicioTresPuntoUno.Service
{
    public class Empleados : CrudEmpleados
    {
        public SQLiteAsyncConnection _database;

        public Empleados(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<InfoEmpleados>().Wait();
        }

        public Empleados()
        {

        }

        public async Task<bool> AgregarEmpleadosAsync(InfoEmpleados infoEmpleados)
        {
            if (infoEmpleados.Id > 0)
            {
                await _database.UpdateAsync(infoEmpleados);
            }
            else
            {
                await _database.InsertAsync(infoEmpleados);
            }

            return await Task.FromResult(true);
        }

        public async Task<bool> EliminarEmpleadosAsync(int id)
        {
            await _database.DeleteAsync<InfoEmpleados>(id);
            return await Task.FromResult(true);
        }

        public async Task<InfoEmpleados> GetEmpleadoAsync(int id)
        {
            return await _database.Table<InfoEmpleados>()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<InfoEmpleados>> GetEmpleadosAsync()
        {
            return await Task.FromResult(await _database.Table<InfoEmpleados>().ToListAsync());
        }

        public Task<bool> UpdateEmpleadoAsync(InfoEmpleados infoEmpleados)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarEmpleadoAsync(InfoEmpleados infoEmpleados)
        {
            throw new NotImplementedException();
        }

        public Task<InfoEmpleados> GetEmpleadosAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ActualizarEmpleadosAsync(InfoEmpleados infoEmpleados)
        {
            throw new NotImplementedException();
        }
    }
}
