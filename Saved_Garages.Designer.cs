namespace Parking_Finder
{
    partial class Saved_Garages
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
            this.YourGarages = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // YourGarages
            // 
            this.YourGarages.FormattingEnabled = true;
            this.YourGarages.ItemHeight = 16;
            this.YourGarages.Location = new System.Drawing.Point(56, 33);
            this.YourGarages.Margin = new System.Windows.Forms.Padding(2);
            this.YourGarages.Name = "YourGarages";
            this.YourGarages.Size = new System.Drawing.Size(173, 164);
            this.YourGarages.TabIndex = 0;
            this.YourGarages.SelectedIndexChanged += new System.EventHandler(this.YourGarages_SelectedIndexChanged);
            this.YourGarages.DoubleClick += new System.EventHandler(this.YourGarages_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your Saved Garages:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 209);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Saved_Garages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 245);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YourGarages);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Saved_Garages";
            this.Text = "Saved_Garages";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Saved_Garages_FormClosed);
            this.Load += new System.EventHandler(this.Saved_Garages_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox YourGarages;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}