namespace JX3_AuxiliarySystem.考試
{
    partial class ImperialExamination
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
            this.TimerIdentification = new System.Windows.Forms.Timer(this.components);
            this.lblAns = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimerIdentification
            // 
            this.TimerIdentification.Interval = 250;
            this.TimerIdentification.Tick += new System.EventHandler(this.TimerIdentification_Tick);
            // 
            // lblAns
            // 
            this.lblAns.AutoSize = true;
            this.lblAns.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(209)))), ((int)(((byte)(195)))));
            this.lblAns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAns.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblAns.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblAns.Location = new System.Drawing.Point(0, 0);
            this.lblAns.Name = "lblAns";
            this.lblAns.Size = new System.Drawing.Size(47, 24);
            this.lblAns.TabIndex = 0;
            this.lblAns.Text = "Null";
            // 
            // ImperialExamination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(209)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(47, 24);
            this.Controls.Add(this.lblAns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(113, 553);
            this.Name = "ImperialExamination";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.Shown += new System.EventHandler(this.ImperialExamination_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimerIdentification;
        private System.Windows.Forms.Label lblAns;
    }
}