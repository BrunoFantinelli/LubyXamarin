using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TesteXamarin.ProjetoLuby;

namespace TesteXamarin.Data
{
    public class UsuarioDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public UsuarioDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            return _database.Table<Usuario>().ToListAsync();
        }

        public Task<Usuario> LoginAsync(string email, string senha)
        {
           
            return _database.Table<Usuario>()
                            .Where(p => p.Email.Equals(email) && p.Senha.Equals(senha))
                            .FirstOrDefaultAsync();
        }

        public Task<Usuario> CheckRegister(string email)
        {
            return _database.Table<Usuario>().Where(p => p.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public Task<int> SaveUsuarioAsync(Usuario user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteNoteAsync(Usuario user)
        {
            return _database.DeleteAsync(user);
        }
    }
}
