using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHandler
{
    /// <summary>
    /// Collection Facorty
    /// 
    /// To Implement Register Type
    /// To Implement List of Registered Typea
    /// To Implement Resolve Type
    /// </summary>
    public class MVVMCollectionFactory<X> where X : IModelRepository
    {
        private IModelRepository _modelRepository;
        public MVVMCollectionFactory()
        {
            _modelRepository = Activator.CreateInstance<X>();
        }
        public MVVMCollectionFactory(MVVMCollectionSettings settings)
        {
            _modelRepository = Activator.CreateInstance<X>();
        }
        /// <summary>
        /// Generate new MVVM Collection with default settings Add Model first then UpdateView
        /// </summary>
        /// <typeparam name="T">
        /// New object type in repository X
        /// </typeparam>
        /// <typeparam name="X">
        /// Model Repository that implements IModelRepository
        /// </typeparam>
        /// <returns></returns>
        public MVVMCollection<T> NewMVVMCollection<T>()
            where T : new()
        {
            return new MVVMCollection<T>(_modelRepository);
        }

        /// <summary>
        /// Generate new MVVM Collection with the passed settings
        /// </summary>
        /// <typeparam name="T">
        /// New object type in repository X
        /// </typeparam>
        /// <typeparam name="X">
        /// Model Repository that implements IModelRepository
        /// </typeparam>
        /// <param name="settings">
        /// MVVM Collection settings whether to update model first or view first
        /// </param>
        /// <returns></returns>
        public MVVMCollection<T> NewMVVMCollection<T>(MVVMCollectionSettings settings)
            where T : new()
        {
            return new MVVMCollection<T>(_modelRepository, settings);
        }
    }
}
