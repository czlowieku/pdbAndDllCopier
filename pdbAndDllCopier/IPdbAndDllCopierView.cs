using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace pdbAndDllCopier
{
    public interface IPdbAndDllCopierView
    {

        event EventHandler SelectAllClicked;
        event EventHandler CopyClicked;
         event EventHandler ClearClicked;
        event ItemCheckEventHandler FolderChecked;
        void Bind(PdbAndDllCopiermodel folders);
        void Show();

        void UpdateList(IEnumerable<Tuple<string, bool>> list);
        void UpdateAutocompleteDataSource(PdbAndDllCopiermodel model);
    }
}