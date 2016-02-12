using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdbAndDllCopier
{
    public partial class Form1 : Form, IPdbAndDllCopierView
    {
        public string FromRoot => textBoxFrom.Text;
        public string ToFolder => textBoxToPath.Text;
        public event EventHandler CopyClicked;
        public event EventHandler SelectAllClicked;
        public event EventHandler ClearClicked;
        public event ItemCheckEventHandler FolderChecked;

        
        public Form1()
        {
            InitializeComponent();
        }

        public void Log(string s)
        {
            richTextBox1.Text += s + Environment.NewLine;
        }

        public void Bind(PdbAndDllCopiermodel model)
        {
           
            textBoxSearch.DataBindings.Add(nameof(textBoxToPath.Text), model, nameof(model.SearchString) , false,
                DataSourceUpdateMode.OnPropertyChanged);

            textBoxFrom.DataBindings.Add(nameof(textBoxToPath.Text), model, nameof(model.FromPath) , false,
               DataSourceUpdateMode.OnPropertyChanged);

            textBoxToPath.DataBindings.Add(nameof(textBoxToPath.Text), model, nameof(model.ToPath) , false,
              DataSourceUpdateMode.OnPropertyChanged);

            checkBoxCopyDll.DataBindings.Add(nameof(checkBoxCopyDll.Checked), model, nameof(model.CopyDll) , false,
              DataSourceUpdateMode.OnPropertyChanged);

         
        }

        public void UpdateAutocompleteDataSource(PdbAndDllCopiermodel model)
        {
            textBoxSearch.AutoCompleteCustomSource.AddRange(
                model.AllBinFolders.Select(folder => folder.ProjectNameNoErgo).ToArray());
        }

        public void UpdateList(IEnumerable<Tuple<string, bool>> list)
        {
            checkedListBox1.Items.Clear();
            foreach (var tuple in list)
            {
                checkedListBox1.Items.Add(tuple.Item1, tuple.Item2);
            }
        }



        private void buttonCopy_Click(object sender, EventArgs e)
        {
            CopyClicked?.Invoke(sender, e);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            FolderChecked?.Invoke(sender, e);
           //var obj = checkedListBox1.Items[e.Index] as BinFolder;
           //if (e.NewValue == CheckState.Checked)
           //{
           //    obj.Checked = true;
           //}
           //else
           //{
           //    obj.Checked = false;
           //}

        }


        private void buttonAll_Click_1(object sender, EventArgs e)
        {
            SelectAllClicked?.Invoke(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
           ClearClicked?.Invoke(sender, e);
        }
    }


 
}
