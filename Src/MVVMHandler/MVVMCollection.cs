using MVVMHandler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHandler
{
    public class MVVMCollection<T> :
        ObservableCollection<T>
        where T : new()
    {
        private MVVMCollectionSettings _settings;
        private IModelRepository _externalModelRepository;

        #region Constructors
        /// <summary>
        /// Create new MVVM Collection with default settings
        /// </summary>
        /// <param name="externalRepository"></param>
        internal MVVMCollection(IModelRepository externalModelRepository)
        {
            _externalModelRepository = externalModelRepository;
            _settings = new MVVMCollectionSettings();
        }
        /// <summary>
        /// Create new MVVM Collections with predefined settings
        /// </summary>
        /// <param name="externalRepository"></param>
        /// <param name="settings"></param>
        internal MVVMCollection(IModelRepository externalModelRepository,
            MVVMCollectionSettings settings
            )
        {
            _settings = settings;
            _externalModelRepository = externalModelRepository;
        }

        #endregion

        #region Runtime Updates
        /// <summary>
        /// Change the Collection Settings in runtime
        /// </summary>
        /// <param name="settings"></param>
        public void UpdateSettings(MVVMCollectionSettings settings)
        {
            _settings = settings;
        }

        /// <summary>
        /// Update the collection model repository at runtime
        /// </summary>
        /// <param name="externalRepository"></param>
        public void UpdateModel(IModelRepository externalModelRepository)
        {
            _externalModelRepository = externalModelRepository;
        }

        #endregion

        /// <summary>
        /// Load All Model data into the MVVM Collection
        /// </summary>
        /// <returns></returns>
        public async Task<MVVMCollection<T>> LoadAllModelData()
        {

            Add(await _externalModelRepository.RetrieveAll<T>());
            return this;
        }

        /// <summary>
        /// Load Model data with Predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<MVVMCollection<T>> Where(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            this.Clear();
            Add(await _externalModelRepository.RetrievePredicate<T>(predicate));
            return this;
        }

        public new async Task Add(T itemToAdd)
        {
            if (_settings.ActionsSettings ==
                MVVMCollectionActionSettings.UpdateModelFirst)
            {
                await _externalModelRepository.Add<T>(itemToAdd);
                base.Add(itemToAdd);
            }
            else if (_settings.ActionsSettings ==
                MVVMCollectionActionSettings.UpdateViewFirst)
            {
                base.Add(itemToAdd);
                await _externalModelRepository.Add<T>(itemToAdd);
            }
            else
            {
                throw new Exception("Unknown settings");
            }
        }

        public new async Task Remove(T itemToAdd)
        {
            if (_settings.ActionsSettings ==
                MVVMCollectionActionSettings.UpdateModelFirst)
            {
                await _externalModelRepository.Remove<T>(itemToAdd);
                base.Remove(itemToAdd);
            }
            else if (_settings.ActionsSettings ==
                MVVMCollectionActionSettings.UpdateViewFirst)
            {
                base.Remove(itemToAdd);
                await _externalModelRepository.Remove<T>(itemToAdd);
            }
            else
            {
                throw new Exception("Unknown settings");
            }
        }


        #region Private Functions
        private void Add(IList<T> list)
        {
            foreach (var itemToAdd in list)
            {
                base.Add(itemToAdd);
            }
        }
        #endregion

    }
}
