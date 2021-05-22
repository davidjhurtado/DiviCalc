using DiviCalc.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DiviCalc.Services {
    public static class CambioService {
        static SQLiteAsyncConnection dbConnection;
        public static async Task InitAsync() {
            if (dbConnection != null)
                return;
            // Get an absolute path to the database file
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "DiviCalc.db");

            dbConnection = new SQLiteAsyncConnection(databasePath);

            _ = await dbConnection.CreateTableAsync<Cambio>();
        }

        public static async Task AddCambioAsync(decimal tasaDeCambio, DateTime fecha) {
            await InitAsync();
            Cambio cambio = new Cambio {
                TasaDeCambio = tasaDeCambio,
                Fecha = fecha
            };
            await dbConnection.InsertAsync(cambio);
        }

        public static async Task RemoveCambioAsync(int id) {
            await InitAsync();
            _ = await dbConnection.DeleteAsync<Cambio>(id);
        }

        public static async Task<IEnumerable<Cambio>> GetCambiosListAsync() {
            await InitAsync();
            List<Cambio> result = await dbConnection.QueryAsync<Cambio>("Select Id, TasaDeCambio, Fecha From Cambios");
            return result;
        }
    }
}
