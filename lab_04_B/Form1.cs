using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab_04_B
{
    public partial class Form1 : Form, IForm
    {

        public event Action<Object> CopyButtonClick;
        public event Action<Object> DeleteButtonClick;
        public event Action<Object> MoveButtonClick;
        

        public Form1()
        {  
          
            InitializeComponent();
            GetLeftPanel().ListBox_ItemClick += MinTCPanel1_ListBox_ItemClick;
            GetRightPanel().ListBox_ItemClick += MinTCPanel1_ListBox_ItemClick;
            //minTCPanel_Left.comboBox_DiscDropDown += MinTCPanel1_LoadDrivers;
            // minTCPanel1.CurrentPath=@"c:\";

        }
        public MinTCPanel GetLeftPanel()
        {
            return minTCPanel_Left;
        }
        public MinTCPanel GetRightPanel()
        {
            return minTCPanel_Right;
        }

        private void button_Coppy_Click(object sender, EventArgs e)
        {
            if (CopyButtonClick != null)
                CopyButtonClick(this);
        }

        private void button_Move_Click(object sender, EventArgs e)
        {
            if (MoveButtonClick != null)
                MoveButtonClick(this);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (DeleteButtonClick != null)
                DeleteButtonClick(this);
        }

        private void MinTCPanel1_ListBox_ItemClick(MinTCPanel obj)
        {
            if (!Object.ReferenceEquals(obj, GetLeftPanel()))
            {
               GetLeftPanel().ListBoxClearSelected();
            }
            else
            {
                GetRightPanel().ListBoxClearSelected();

            }
        }
        public MinTCPanel getActivePanel()
        {
            string left = GetLeftPanel().SelectedItem();
            string right = GetRightPanel().SelectedItem();

            if (left == null && right == null) return null;
            if (left != null && right != null) return null;
            if (left != null) return GetLeftPanel();
            return GetRightPanel();
        }
        //czy to powinno byc tutaj czy w Formie

        public MinTCPanel getInActivePanel()
        {
            string left = GetLeftPanel().SelectedItem();
            string right = GetRightPanel().SelectedItem();

            if (left == null && right == null) return null;
            if (left != null && right != null) return null;
            if (left == null) return GetLeftPanel();
            return GetRightPanel();
        }

    }
}
