using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Kopiowanie usuwanie, przenoszenie 

namespace lab_04_B
{
    public partial class MinTCPanel : UserControl, IMinTCPanel
    {
        public event Action<MinTCPanel,string> comboBox_DiscSelectionChange; //
        public event Action<MinTCPanel> comboBox_DiscDropDown; //
        public event Action<MinTCPanel> ListBox_ItemSelectFile;
        public event Action<MinTCPanel> ListBox_ItemClick;
        public event Action<MinTCPanel> ListBox_ItemDoubleClick;
        public event Action<MinTCPanel> Button_BackWardClick;
        public event Action<MinTCPanel> TextBox_PathLostFocus;
        public event Action<MinTCPanel, KeyPressEventArgs> Text_BoxPathEnterKey;
      


        public MinTCPanel()
        {
            /*To show hint
             * System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                ToolTip1.SetToolTip(this.Button1, "Button Info");
             * 
             */
            InitializeComponent();    
            //czy podbpiecie w ten sposób metody do eventu jest w dobre?
            //dlaczego event leave nie działa
            textBox_path.LostFocus += new EventHandler(PathLostFocus);
        }
        public bool ListISSelected
        {
            get{
                if (listBox_items.SelectedItems.Count == 0)
                    return false;
                return true;
            }
            set{
              
                    listBox_items.SelectedItems.Clear();
            }
        }
        public string ListSelectedName {
            get {
                return listBox_items.GetItemText(listBox_items.SelectedItem);                
            }
        }
        public string[] List
        { 
            get{
                string[] lista=new string[listBox_items.Items.Count];
                for (int loop = 0; loop < listBox_items.Items.Count; loop++)
                    lista[loop] = listBox_items.Items[loop].ToString();
                return lista;
            }
            set{
                listBox_items.Items.Clear();
                listBox_items.Items.AddRange(value);  

            }

        }
        public string CurentPath
        {
            get { return textBox_path.Text; }
            set { textBox_path.Text = value; }
        }
        public string DiscName
        {
            get{
                return comboBoxDisc.Text;        
            }
            set{
                comboBoxDisc.Text = value;
            }
        }
        public string[] DiscList
        {
            set{
                comboBoxDisc.Items.Clear();
                comboBoxDisc.Items.AddRange(value);
            }
        }

        public void ListBoxClearSelected()
        {
            listBox_items.ClearSelected();
        }
      


        // zwraca tekst comboboxa
        public string ComboBoxText()
        {
            return comboBoxDisc.GetItemText(comboBoxDisc.SelectedItem);
        }
        //zwraca zaznaczony przedmiot
        public string SelectedItem()
        {
            if (listBox_items.SelectedItem!=null)
                return listBox_items.SelectedItem.ToString();
            return null;
        }
        
        //przypisanie do eventu klikniecia na listboxa ewantu
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            if (comboBox_DiscDropDown != null)
                comboBox_DiscDropDown(this);
        }
         private void comboBoxDisc_Select(object sender, EventArgs e)
        {
            if (comboBox_DiscSelectionChange != null)
                comboBox_DiscSelectionChange(this,comboBoxDisc.GetItemText(comboBoxDisc.SelectedItem));
        }
         private void listBoxDoubleClick(object sender, EventArgs e)
         {
             if (ListBox_ItemDoubleClick != null)
                 ListBox_ItemDoubleClick(this);

         }
        private void ButtonBackward(object sender, EventArgs e)
         {
            if(Button_BackWardClick!= null)       
                  Button_BackWardClick(this);            
         }
        private void PathLostFocus(object sender, EventArgs e)
        {
            if (TextBox_PathLostFocus != null)
                TextBox_PathLostFocus(this);   
            
        }

        private void textBox_path_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Text_BoxPathEnterKey != null)
                
                Text_BoxPathEnterKey(this,e); 
        }

        private void listBox_items_Click(object sender, EventArgs e)
        {
            if (ListBox_ItemClick != null)
                ListBox_ItemClick(this);
        }


    }
}
