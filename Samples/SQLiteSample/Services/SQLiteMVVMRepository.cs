using MVVMHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteSample.Services
{
    public class SQLiteMVVMRepository : IModelRepository
    {
        public async Task Add<T>(T itemToAdd) where T : new()
        {
            await DBServices.SQLiteConnector.InsertAsync(itemToAdd);

        }

        public async Task Remove<T>(T itemToDelete) where T : new()
        {
            await DBServices.SQLiteConnector.DeleteAsync(itemToDelete);
        }

        public async Task<IList<T>> RetrieveAll<T>() where T : new()
        {
            return await DBServices.SQLiteConnector.Table<T>().ToListAsync();
        }

        public async Task<IList<T>> RetrievePredicate<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new()
        {
            return await DBServices.SQLiteConnector.Table<T>().Where(predicate).ToListAsync();
        }
    }
}
