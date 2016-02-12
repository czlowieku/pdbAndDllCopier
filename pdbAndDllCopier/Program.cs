using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pdbAndDllCopier
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new Form1();
            var presenter=new PdbAndDllCopierPresenter(form,new PdbAndDllCopiermodel(),form.Log);
            
            Application.Run(form);
        }
    }

    // end public class CheckedComboBox
}
