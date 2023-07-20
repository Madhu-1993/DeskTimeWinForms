namespace DeskTimeWinForms
{
    partial class User_LogTime
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActivetime = new System.Windows.Forms.Label();
            this.lblInactivetime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Inactive";
            // 
            // lblActivetime
            // 
            this.lblActivetime.AutoSize = true;
            this.lblActivetime.Location = new System.Drawing.Point(266, 197);
            this.lblActivetime.Name = "lblActivetime";
            this.lblActivetime.Size = new System.Drawing.Size(59, 13);
            this.lblActivetime.TabIndex = 2;
            this.lblActivetime.Text = "Active time";
            // 
            // lblInactivetime
            // 
            this.lblInactivetime.AutoSize = true;
            this.lblInactivetime.Location = new System.Drawing.Point(266, 264);
            this.lblInactivetime.Name = "lblInactivetime";
            this.lblInactivetime.Size = new System.Drawing.Size(71, 13);
            this.lblInactivetime.TabIndex = 3;
            this.lblInactivetime.Text = "In Active time";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // User_LogTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblInactivetime);
            this.Controls.Add(this.lblActivetime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "User_LogTime";
            this.Text = "User_LogTime";
            this.Load += new System.EventHandler(this.User_LogTime_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActivetime;
        private System.Windows.Forms.Label lblInactivetime;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
    }
}