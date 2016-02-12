using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using pdbAndDllCopier.Annotations;

namespace pdbAndDllCopier
{
    public class PdbAndDllCopiermodel:INotifyPropertyChanged
    {
        public bool CopyDll
        {
            get { return _copyDll; }
            set
            {
                if (value == _copyDll) return;
                _copyDll = value;
                OnPropertyChanged();
            }
        }

        public PdbAndDllCopiermodel()
        {
            AllBinFolders=new List<BinFolder>();
            DisplayedBinFolders=new BindingList<BinFolder>();
        }
        private string _searchString;
        private string _toPath;
        private string _fromPath;
        private bool _copyDll;
        public List<BinFolder> AllBinFolders { get; set; }
        public BindingList<BinFolder> DisplayedBinFolders { get; set; }

        public string FromPath
        {
            get { return _fromPath; }
            set
            {
                if (value == _fromPath) return;
                _fromPath = value;
                OnPropertyChanged();
            }
        }

        public string ToPath
        {
            get { return _toPath; }
            set
            {
                if (value == _toPath) return;
                _toPath = value;
                OnPropertyChanged();
            }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (value == _searchString) return;
                _searchString = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}