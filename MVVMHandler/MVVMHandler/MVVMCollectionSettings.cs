using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMHandler
{
    public class MVVMCollectionSettings
    {
        private MVVMCollectionActionSettings _actionsSettings;

        public MVVMCollectionActionSettings ActionsSettings
        {
            get { return _actionsSettings; }
            set { _actionsSettings = value; }
        }

        public MVVMCollectionSettings(MVVMCollectionActionSettings actionsSettings)
        {
            _actionsSettings = actionsSettings;
        }

        /// <summary>
        /// Default settings is UpdateModelFirst Setting
        /// </summary>
        public MVVMCollectionSettings()
        {
            _actionsSettings = MVVMCollectionActionSettings.UpdateModelFirst;
        }
    }

    public enum MVVMCollectionActionSettings
    {
        UpdateModelFirst,
        UpdateViewFirst
    }
}
