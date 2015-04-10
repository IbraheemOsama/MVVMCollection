using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHandler
{
    /// <summary>
    /// The interface to be implements by the model repository class
    /// </summary>
    public interface IModelRepository
    {
        /// <summary>
        /// Add new item to the model repository 
        /// </summary>
        /// <typeparam name="T">
        /// Model type that must be initated
        /// </typeparam>
        /// <param name="itemToAdd">
        /// New item of type T
        /// </param>
        /// <returns></returns>
        Task Add<T>(object itemToAdd) where T : new();

        /// <summary>
        /// Remove item from the model repository 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemToDelete"></param>
        /// <returns></returns>
        Task Remove<T>(object itemToDelete) where T : new();

        /// <summary>
        /// Retrieve all items of type T from the model repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// IList of type T
        /// </returns>
        Task<IList<T>> RetrieveAll<T>() where T : new();

        /// <summary>
        /// Retrieve all items of type T from the model repository with certain predicate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        /// IList of type T with certain predicate
        /// </returns>
        Task<IList<T>> RetrievePredicate<T>(Expression<Func<T, bool>> predicate) where T : new();
    }
}
