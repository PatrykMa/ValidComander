using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_04_B
{
    interface IMinTCPanel
    {
        event Action<MinTCPanel,string > comboBox_DiscSelectionChange;       // when selected a dri
        event Action<MinTCPanel> comboBox_DiscDropDown;       
        event Action<MinTCPanel> ListBox_ItemSelectFile;
        event Action<MinTCPanel> ListBox_ItemDoubleClick;
        event Action<MinTCPanel> ListBox_ItemClick;
        event Action<MinTCPanel> Button_BackWardClick;
        event Action<MinTCPanel> TextBox_PathLostFocus;
        event Action<MinTCPanel, KeyPressEventArgs> Text_BoxPathEnterKey;


        bool ListISSelected { get; set; }
        string ListSelectedName { get; }
        string[] List { get; set; } 
        string CurentPath { get; set; }
        string DiscName { get; set; }
        string[] DiscList { set; }
        void ListBoxClearSelected();
    }
}
