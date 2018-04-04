using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_04_B
{
    class Presenter
    {
        Model model;
        IForm iForm;

        public Presenter(Model model, IForm iViev)
        {
            this.model = model;
            this.iForm = iViev;

            iForm.GetLeftPanel().comboBox_DiscDropDown += MinTCPanel1_LoadDrivers;
            iForm.GetRightPanel().comboBox_DiscDropDown += MinTCPanel1_LoadDrivers;
            iForm.GetLeftPanel().comboBox_DiscSelectionChange += MinTCPanel1_DriversChanged;
            iForm.GetRightPanel().comboBox_DiscSelectionChange += MinTCPanel1_DriversChanged;
            iForm.GetLeftPanel().Button_BackWardClick += MinTCPanel1_PrimaryPath;
            iForm.GetRightPanel().Button_BackWardClick += MinTCPanel1_PrimaryPath;
            iForm.GetRightPanel().TextBox_PathLostFocus += MinTCPanel1_TextBoxPathLostFocus;
            iForm.GetLeftPanel().TextBox_PathLostFocus += MinTCPanel1_TextBoxPathLostFocus;
            iForm.GetLeftPanel().Text_BoxPathEnterKey += MinTCPanel1_TextBoxPathKeyPress;
            iForm.GetRightPanel().Text_BoxPathEnterKey += MinTCPanel1_TextBoxPathKeyPress;
            iForm.GetRightPanel().ListBox_ItemDoubleClick += MinTCPanel1_ListBox_ItemDoubleClick;
            iForm.GetLeftPanel().ListBox_ItemDoubleClick += MinTCPanel1_ListBox_ItemDoubleClick;
            iForm.GetLeftPanel().ListBox_ItemClick += MinTCPanel1_ListBox_ItemClick;
            iForm.GetRightPanel().ListBox_ItemClick += MinTCPanel1_ListBox_ItemClick;

            iForm.MoveButtonClick += Form_ButtonMove;
            iForm.DeleteButtonClick += Form_ButtonDelateClick;
            iForm.CopyButtonClick += Form_ButtonCoppy;

            initPanel(iForm.GetLeftPanel());
            initPanel(iForm.GetRightPanel());

        }
        // load drives to combobox
        private void MinTCPanel1_LoadDrivers(MinTCPanel obj)
        {
            obj.DiscList = model.getListOfDrivers();
        }
        // select a Driver
        private void MinTCPanel1_DriversChanged(MinTCPanel obj,string selectDrive)
        {
            obj.CurentPath = selectDrive;

            if (model.IsAvalibleDrive(selectDrive))
            {
                obj.List = reloadList(selectDrive);
            }
            else
            {
                obj.List = new string[0];
                model.errorMesage("napęd nie jest gotowy do uzycia");
            }

        }
        // bawkwardButton clicked
        private void  MinTCPanel1_PrimaryPath(MinTCPanel obj)
        {
            try
            {
                obj.CurentPath = model.PrimaryPath(obj.CurentPath);
                obj.List = reloadList(obj.CurentPath);
            }
            catch
            {

            }
        }
        private void MinTCPanel1_TextBoxPathLostFocus(MinTCPanel obj)
        {
            //this.CheckPatchAndReloadList(obj);
            try
            {
                obj.List = reloadList(obj.CurentPath);
                obj.DiscName = model.getDriveFromPath(obj.CurentPath);
            }
            catch { }

        }
        private void MinTCPanel1_TextBoxPathKeyPress(MinTCPanel obj, KeyPressEventArgs znak)
        {
            if(znak.KeyChar==13)
            {

                obj.List = reloadList(obj.CurentPath);
                obj.DiscName = model.getDriveFromPath(obj.CurentPath);
            }

        }
        private void MinTCPanel1_ListBox_ItemClick(MinTCPanel obj)
        {
            if(!Object.ReferenceEquals(obj, iForm.GetLeftPanel()))
            {
                iForm.GetLeftPanel().ListBoxClearSelected();
            }
            else
            {
                iForm.GetRightPanel().ListBoxClearSelected();

            }
        }
        private void MinTCPanel1_ListBox_ItemDoubleClick(MinTCPanel obj)
        {
            string file = System.IO.Path.Combine(obj.CurentPath, obj.SelectedItem());
            System.IO.FileAttributes attr = System.IO.File.GetAttributes(file);
            if (attr.HasFlag(System.IO.FileAttributes.Directory))
            {
                //TODO niewszystkie pliki ozna otworzyc bez uprawnien lapac wyjate
                //obj.files = getNameFromPath(Directory.GetFileSystemEntries(file));
                obj.CurentPath = file;
                obj.List = reloadList(obj.CurentPath);
            }

        }

        private void CheckPatchAndReloadList(MinTCPanel obj)
        {
            bool error = false;
            if(obj.CurentPath=="")
            {
                //pusta sciezka
                model.errorMesage("Pusta ścieżka");
                error = true;
            }
            else if (!model.IsDriveFromPath(obj.CurentPath))
            {
                // niepoprawna sciezka
                model.errorMesage("Nie poprawny napęd");
                error = true;
            }
            else if (!model.IsAvalibleDrive(model.getDriveFromPath(obj.CurentPath)))
            {
                //dysk nie jest dostepny
                model.errorMesage("Napęd nie jest gotowy do uzycia");
                error = true;
            }
            else
            {
                obj.List = reloadList(obj.CurentPath);
            }
            if(error)
            {
                obj.List = new string[0];
            }
            
        }

        private void initPanel(MinTCPanel obj)
        {
            string [] drivers =model.getListOfAvalibleDrivers();
            if(drivers.Length>0)
            {
                obj.DiscName = drivers[0];
                obj.List = reloadList(drivers[0]);
                obj.CurentPath = drivers[0];
            }

        }
        private void Form_ButtonDelateClick(Object obj)
        {
            MinTCPanel activePanel = this.getActivePanel();
            if (activePanel != null)
            {
                string name = activePanel.SelectedItem();
                string curpath = activePanel.CurentPath;
                delete(System.IO.Path.Combine(curpath, name));
                activePanel.List = reloadList(curpath);                   
            }
        }

        private void Form_ButtonCoppy(Object obj)
        {
            if (getActivePanel() != null)
            {            
                string fromPath = getActivePanel().CurentPath;
                string toPath = getInActivePanel().CurentPath;
                string name = getActivePanel().SelectedItem();
                if (model.canCoppy(System.IO.Path.Combine(fromPath, name), System.IO.Path.Combine(toPath, name)))
                {
                    coppy(System.IO.Path.Combine(fromPath, name), System.IO.Path.Combine(toPath, name));
                    getInActivePanel().List = reloadList(getInActivePanel().CurentPath);
                }
            }

        }
        //czy to powinno byc tutaj czy w Formie
        private MinTCPanel getActivePanel()
        {
            string left = iForm.GetLeftPanel().SelectedItem();
            string right = iForm.GetRightPanel().SelectedItem();

            if (left == null && right == null) return null;
            if (left != null && right != null) return null;
            if (left != null) return iForm.GetLeftPanel();
            return iForm.GetRightPanel();

        }
        private MinTCPanel getInActivePanel()
        {
            string left = iForm.GetLeftPanel().SelectedItem();
            string right = iForm.GetRightPanel().SelectedItem();

            if (left == null && right == null) return null;
            if (left != null && right != null) return null;
            if (left == null) return iForm.GetLeftPanel();
            return iForm.GetRightPanel();
        }
        private void Form_ButtonMove(Object obj)
        {
            string fromPath = getActivePanel().CurentPath;
            string toPath = getInActivePanel().CurentPath;
            string name = getActivePanel().SelectedItem();

            if(coppy(System.IO.Path.Combine(fromPath, name), System.IO.Path.Combine(toPath, name)))
                delete(System.IO.Path.Combine(fromPath, name));

            getInActivePanel().List = reloadList(getInActivePanel().CurentPath);
            getActivePanel().List = reloadList(getActivePanel().CurentPath);

        }
        private bool coppy(string from, string to)
        {
            try
            {
                
                model.coppy(from, to);
                return true;
            }
            catch { return false; }
        }

        private string[] reloadList(string path)
        {
            try
            {
                return model.FileNameList(path);
            }
            catch
            {
                return new string[0];
            }
        }
        private bool delete(string path)
        {
            try
            {
                model.Deltete(path);
                return true;
            }
            catch { return false; }
        }



        //TODO ustawic drivera na odpowiedni po wpisani sciezki
        //TODO przy kopiowanie sprawdzac czy sciezka jest poprawna, czy tworzyc ninepoprawna sprawdzajac tylko czy driver jest odpowiedni
    }
}
