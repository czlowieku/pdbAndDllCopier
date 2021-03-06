﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pdbAndDllCopier
{
    public class PdbAndDllCopierPresenter
    {
        private readonly IPdbAndDllCopierView _view;
        private readonly PdbAndDllCopiermodel _model;
        private readonly Action<string> _log;

        private string _savedlinesTxt = "SavedLines.txt";
        private string _fromToTxt= "FromTo.txt";

        public PdbAndDllCopierPresenter(IPdbAndDllCopierView view, PdbAndDllCopiermodel model,Action<string> log )
        {
            _view = view;
            _model = model;
            _log = log;
            
            _view.CopyClicked+=ViewOnCopyClicked;
            _view.FolderChecked+=ViewOnFolderChecked;
            _view.SelectAllClicked+=ViewOnSelectAllClicked;
            _view.ClearClicked+=ViewOnClearClicked;
            _model.DisplayedBinFolders.ListChanged+=DisplayedBinFoldersOnListChanged;
            _model.PropertyChanged += ModelOnPropertyChanged;

          //  _model.FromPath = @"E:\Dev\Fenergo\R7.1\WebApp\Src";
          //  _model.ToPath = @"E:\Dev\HSBC\PROJECT\Src\UI\WebUI\bin";
            GetSavedFromTo();
         
            _model.CopyDll = true;
            _model.SearchString = "";
            _view.Bind(_model);
            InitFolders();
        }

        private void InitFolders()
        {
            try
            {
                _model.DisplayedBinFolders.Clear();
                _model.AllBinFolders = GetAllBinFolders(_model.FromPath).ToList();
                LoadSavedFolders(_savedlinesTxt);
                _model.DisplayedBinFolders.AddRange(_model.AllBinFolders);
                _view.UpdateAutocompleteDataSource(_model);
                UpdateListOnView();
            }
            catch (Exception e)
            {
                _log(e.ToString());
            }
        }

        private void GetSavedFromTo()
        {
            if (File.Exists(_fromToTxt))
            {
                var llines = File.ReadAllLines(_fromToTxt);
                if (llines.Length > 1)
                {
                    _model.FromPath = llines[0];
                    _model.ToPath = llines[1];
                }
            }
        }

        private void ViewOnClearClicked(object sender, EventArgs eventArgs)
        {
            foreach (var displayedBinFolder in _model.DisplayedBinFolders)
            {
                displayedBinFolder.Checked = false;
            }
            UpdateListOnView();
        }

        private void DisplayedBinFoldersOnListChanged(object sender, ListChangedEventArgs listChangedEventArgs)
        {
            UpdateListOnView();
        }

        private void UpdateListOnView()
        {
            _view.UpdateList(
                _model.DisplayedBinFolders.Select(folder => new Tuple<string, bool>(folder.ProjectName, folder.Checked)));
        }

        private void ViewOnSelectAllClicked(object sender, EventArgs eventArgs)
        {
            foreach (var displayedBinFolder in _model.DisplayedBinFolders)
            {
                displayedBinFolder.Checked = true;
            }
            UpdateListOnView();
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(_model.SearchString))
            {
                Search(_model.SearchString);
            }

            if (propertyChangedEventArgs.PropertyName == nameof(_model.FromPath))
            {
                InitFolders();
            }
            
        }

        public void Show()
        {
            _view.Show();
        }
        private void LoadSavedFolders(string savedlinesTxt)
        {
            if (File.Exists(savedlinesTxt))
            {
                var saved = File.ReadAllLines(savedlinesTxt);

                foreach (var binFolder in _model.AllBinFolders.Where(binFolder => saved.Contains(binFolder.FullPath)))
                {
                    binFolder.Checked = true;
                }
            }
        }

        private void ViewOnFolderChecked(object sender, ItemCheckEventArgs itemCheckEventArgs)
        {
            _model.AllBinFolders.First(
                folder => folder.FullPath == _model.DisplayedBinFolders[itemCheckEventArgs.Index].FullPath).Checked =
                itemCheckEventArgs.NewValue == CheckState.Checked;
        }

        private void Copy(BinFolder selectedFolder, string toPath, string extension)
        {
            try
            {
                var pdbFrom = Path.Combine(selectedFolder.FullPath, selectedFolder.ProjectName) + "." + extension;
                var pdbTo = Path.Combine(toPath, selectedFolder.ProjectName) + "." + extension;
                if (File.Exists(pdbFrom))
                {
                    File.Copy(pdbFrom, pdbTo, true);
                }
                else
                {
                    _log("File not found:" + pdbFrom);
                }
            }
            catch (Exception e)
            {
                _log(e.ToString());
            }
        }



        private void ViewOnCopyClicked(object sender, EventArgs eventArgs)
        {
            foreach (var folder in _model.AllBinFolders.Where(folder => folder.Checked))
            {
                Copy(folder,_model.ToPath, "pdb");
                if (_model.CopyDll)
                {
                    Copy(folder, _model.ToPath, "dll");
                }
                _log("Copied " + folder.ProjectName);
            }
            File.WriteAllLines(_savedlinesTxt, _model.AllBinFolders.Where(folder => folder.Checked).Select(folder => folder.FullPath));

            File.WriteAllLines(_fromToTxt, new List<string>() {_model.FromPath, _model.ToPath});
        }

          private void Search(string searchString)
          {
              searchString = "%" + searchString + "%";
              _model.DisplayedBinFolders.Clear();
              if (string.IsNullOrEmpty(searchString))
              {
                  _model.DisplayedBinFolders.AddRange(_model.AllBinFolders);
              }
              else
              {
                  _model.DisplayedBinFolders.AddRange(
                      _model.AllBinFolders.Where(selectedFolder => selectedFolder.ProjectName.Like(searchString))
                          .ToList());
              }
           
          }

        private IEnumerable<BinFolder> GetAllBinFolders(string rootPath)
        {
            if (!Directory.Exists(rootPath)) yield break;
            foreach (var subdir in Directory.GetDirectories(rootPath))
            {
                if ((subdir.EndsWith(@"bin\Debug") ||
                     (subdir.EndsWith(@"bin") && !Directory.GetDirectories(subdir).Any(s => s.EndsWith("Debug"))))
                    && !subdir.Contains("Test") && !subdir.Contains("Mock"))
                {
                    yield return
                        new BinFolder()
                        {
                            FullPath = subdir,
                            ShortPath = subdir.Replace(rootPath, ""),
                            ProjectName = GetProjectName(subdir)
                        };
                }
                else
                {
                    foreach (var subdir2 in GetAllBinFolders(subdir))
                    {
                        yield return subdir2;
                    }
                }
            }
        }

        private string GetProjectName(string subdir)
        {
            var splited = subdir.Split(Path.DirectorySeparatorChar).ToList();
            var projectName= splited[splited.IndexOf("bin") - 1];
            return NonStandardProjectNames.ContainsKey(projectName) ? NonStandardProjectNames[projectName] : projectName;
        }

        private Dictionary<string, string> NonStandardProjectNames = new Dictionary<string, string>()
        {
            {"Ergo.ExpertBanker.Domain.LegalEntityModule.Strategies", "Ergo.ExpertBanker.Domain.LegalEntityModule.UIControlGroupStrategy"},
            {"CovenantModuleServiceImplementation","Ergo.ExpertBanker.CovenantModuleServiceImplementation" },
            {"CovenantService","Ergo.ExpertBanker.CovenantModuleService" },
            {"FenergoQueueServiceImplementation", "Fenergo.QueueServiceImplementation"},
            {"Ergo.ExpertBanker.ServiceImplementation","Ergo.ExpertBanker.MainModuleServiceImplementation" }
        };

    }
}