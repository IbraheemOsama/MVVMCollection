using MVVMHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureMobileServiceSample.Services
{
    public class MobileServiceRepository : IModelRepository
    {
        public async Task Add<T>(T itemToAdd) where T : new()
        {
            await App.MobileService.GetTable<T>().InsertAsync(itemToAdd);
        }

        public async Task Remove<T>(T itemToDelete) where T : new()
        {
            await App.MobileService.GetTable<T>().DeleteAsync(itemToDelete);
        }

        public async Task<IList<T>> RetrieveAll<T>() where T : new()
        {
            return await App.MobileService.GetTable<T>().ToListAsync();
        }

        public async Task<IList<T>> RetrievePredicate<T>(System.Linq.Expressions.Expression<Func<T, bool>> predicate) where T : new()
        {
            return await App.MobileService.GetTable<T>().Where(predicate).ToListAsync();
        }

    }
}
