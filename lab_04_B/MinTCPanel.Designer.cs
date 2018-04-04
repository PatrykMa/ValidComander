namespace lab_04_B
{
    partial class MinTCPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.comboBoxDisc = new System.Windows.Forms.ComboBox();
            this.listBox_items = new System.Windows.Forms.ListBox();
            this.button_backward = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(71, 4);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(100, 20);
            this.textBox_path.TabIndex = 0;
            this.textBox_path.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_path_KeyPress);
            // 
            // comboBoxDisc
            // 
            this.comboBoxDisc.FormattingEnabled = true;
            this.comboBoxDisc.Location = new System.Drawing.Point(122, 30);
            this.comboBoxDisc.Name = "comboBoxDisc";
            this.comboBoxDisc.Size = new System.Drawing.Size(49, 21);
            this.comboBoxDisc.TabIndex = 1;
            this.comboBoxDisc.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBoxDisc.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDisc_Select);
            // 
            // listBox_items
            // 
            this.listBox_items.FormattingEnabled = true;
            this.listBox_items.Location = new System.Drawing.Point(0, 66);
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.Size = new System.Drawing.Size(171, 251);
            this.listBox_items.TabIndex = 2;
            this.listBox_items.Click += new System.EventHandler(this.listBox_items_Click);
            this.listBox_items.DoubleClick += new System.EventHandler(this.listBoxDoubleClick);
            // 
            // button_backward
            // 
            this.button_backward.Location = new System.Drawing.Point(13, 27);
            this.button_backward.Name = "button_backward";
            this.button_backward.Size = new System.Drawing.Size(26, 23);
            this.button_backward.TabIndex = 3;
            this.button_backward.Text = "<-";
            this.button_backward.UseVisualStyleBackColor = true;
            this.button_backward.Click += new System.EventHandler(this.ButtonBackward);
            // 
            // MinTCPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_backward);
            this.Controls.Add(this.listBox_items);
            this.Controls.Add(this.comboBoxDisc);
            this.Controls.Add(this.textBox_path);
            this.Name = "MinTCPanel";
            this.Size = new System.Drawing.Size(180, 328);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.ComboBox comboBoxDisc;
        private System.Windows.Forms.ListBox listBox_items;
        private System.Windows.Forms.Button button_backward;
    }
}
