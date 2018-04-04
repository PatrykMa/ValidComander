namespace lab_04_B
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Coppy = new System.Windows.Forms.Button();
            this.minTCPanel_Right = new lab_04_B.MinTCPanel();
            this.minTCPanel_Left = new lab_04_B.MinTCPanel();
            this.button_Delete = new System.Windows.Forms.Button();
            this.button_Move = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Coppy
            // 
            this.button_Coppy.Location = new System.Drawing.Point(195, 99);
            this.button_Coppy.Name = "button_Coppy";
            this.button_Coppy.Size = new System.Drawing.Size(60, 23);
            this.button_Coppy.TabIndex = 6;
            this.button_Coppy.Text = "Coppy";
            this.button_Coppy.UseVisualStyleBackColor = true;
            this.button_Coppy.Click += new System.EventHandler(this.button_Coppy_Click);
            // 
            // minTCPanel_Right
            // 
            this.minTCPanel_Right.CurentPath = "";
            this.minTCPanel_Right.DiscName = "";
            this.minTCPanel_Right.List = new string[0];
            this.minTCPanel_Right.ListISSelected = false;
            this.minTCPanel_Right.Location = new System.Drawing.Point(269, 2);
            this.minTCPanel_Right.Name = "minTCPanel_Right";
            this.minTCPanel_Right.Size = new System.Drawing.Size(180, 328);
            this.minTCPanel_Right.TabIndex = 5;
            // 
            // minTCPanel_Left
            // 
            this.minTCPanel_Left.CurentPath = "";
            this.minTCPanel_Left.DiscName = "";
            this.minTCPanel_Left.List = new string[0];
            this.minTCPanel_Left.ListISSelected = false;
            this.minTCPanel_Left.Location = new System.Drawing.Point(8, 2);
            this.minTCPanel_Left.Name = "minTCPanel_Left";
            this.minTCPanel_Left.Size = new System.Drawing.Size(180, 328);
            this.minTCPanel_Left.TabIndex = 4;
            // 
            // button_Delete
            // 
            this.button_Delete.Location = new System.Drawing.Point(194, 129);
            this.button_Delete.Name = "button_Delete";
            this.button_Delete.Size = new System.Drawing.Size(61, 23);
            this.button_Delete.TabIndex = 7;
            this.button_Delete.Text = "Delete";
            this.button_Delete.UseVisualStyleBackColor = true;
            this.button_Delete.Click += new System.EventHandler(this.button_Delete_Click);
            // 
            // button_Move
            // 
            this.button_Move.Location = new System.Drawing.Point(194, 70);
            this.button_Move.Name = "button_Move";
            this.button_Move.Size = new System.Drawing.Size(61, 23);
            this.button_Move.TabIndex = 8;
            this.button_Move.Text = "Move";
            this.button_Move.UseVisualStyleBackColor = true;
            this.button_Move.Click += new System.EventHandler(this.button_Move_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 329);
            this.Controls.Add(this.button_Move);
            this.Controls.Add(this.button_Delete);
            this.Controls.Add(this.button_Coppy);
            this.Controls.Add(this.minTCPanel_Right);
            this.Controls.Add(this.minTCPanel_Left);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MinTCPanel minTCPanel_Left;
        private MinTCPanel minTCPanel_Right;
        private System.Windows.Forms.Button button_Coppy;
        private System.Windows.Forms.Button button_Delete;
        private System.Windows.Forms.Button button_Move;
    }
}

