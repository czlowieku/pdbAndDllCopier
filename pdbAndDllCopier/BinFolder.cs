using System;
using System.ComponentModel;

namespace pdbAndDllCopier
{
    public class BinFolder: ICloneable
    {
        [Bindable(true)]
        public bool Checked { get; set; }
        public string FullPath { get; set; }
        public string ShortPath { get; set; }
        [Bindable(true)]
        public string ProjectName { get; set; }
        public string ProjectNameNoErgo { get { return ProjectName.Replace("Ergo.ExpertBanker.", ""); } }

        public object Clone()
        {
            return new BinFolder()
            {
                Checked = Checked,
                FullPath = FullPath,
                ShortPath = ShortPath,
                ProjectName = ProjectName
            };
        }
    }
}