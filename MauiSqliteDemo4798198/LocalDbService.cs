using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiSqliteDemo4798198
{
    public class LocalDbService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            //Le indica al sistema que crea la tabla de nuestro contexto 
            _connection.CreateTableAsync<Clientes>();
        }
        //Método para lista los registros de nuestra tabla
        public async Task<List<Clientes>> GetClientes()
        {
            return await _connection.Table<Clientes>().ToListAsync();
        }
        //Método para listar los registros por id
        public async Task<Clientes> GetById(int id)
        {
            return await _connection.Table<Clientes>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        //Método para  crear registro
        public async Task Create(Clientes clientes)
        {
            await _connection.InsertAsync(clientes);
        }
        //Método para actualizar
        public async Task Update(Clientes clientes)
        {
            await _connection.UpdateAsync(clientes);
        }
        //Método  para eliminar
        public async Task Delete(Clientes clientes)
        {
            await _connection.DeleteAsync(clientes);
        }

    }
}
