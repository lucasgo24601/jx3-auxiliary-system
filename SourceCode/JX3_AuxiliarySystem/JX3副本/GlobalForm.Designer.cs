namespace JX3_AuxiliarySystem.JX3
{
    partial class GlobalForm
    {

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
        internal void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlobalForm));
            this.lblSkillCount_1 = new System.Windows.Forms.Label();
            this.bunPowerBar_1 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.lblSkillName_1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PanelSkill_1 = new System.Windows.Forms.Panel();
            this.PanelSkill_2 = new System.Windows.Forms.Panel();
            this.lblSkillCount_2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblSkillName_2 = new System.Windows.Forms.Label();
            this.bunPowerBar_2 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.PanelSkill_3 = new System.Windows.Forms.Panel();
            this.lblSkillCount_3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSkillName_3 = new System.Windows.Forms.Label();
            this.bunPowerBar_3 = new Bunifu.Framework.UI.BunifuProgressBar();
            this.TimerMainCount = new System.Windows.Forms.Timer(this.components);
            this.btnFast = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRewind = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStartStop = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnRe = new Bunifu.Framework.UI.BunifuFlatButton();
            this.TimerSupCount = new System.Windows.Forms.Timer(this.components);
            this.btnExist = new System.Windows.Forms.Button();
            this.TimerCaptureCount = new System.Windows.Forms.Timer(this.components);
            this.TimerStartFight = new System.Windows.Forms.Timer(this.components);
            this.TimerShout = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.PanelSkill_1.SuspendLayout();
            this.PanelSkill_2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelSkill_3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSkillCount_1
            // 
            this.lblSkillCount_1.AutoSize = true;
            this.lblSkillCount_1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSkillCount_1.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillCount_1.Location = new System.Drawing.Point(258, 16);
            this.lblSkillCount_1.Name = "lblSkillCount_1";
            this.lblSkillCount_1.Size = new System.Drawing.Size(43, 21);
            this.lblSkillCount_1.TabIndex = 22;
            this.lblSkillCount_1.Text = "60 s";
            // 
            // bunPowerBar_1
            // 
            this.bunPowerBar_1.BackColor = System.Drawing.Color.DarkGray;
            this.bunPowerBar_1.BorderRadius = 5;
            this.bunPowerBar_1.Location = new System.Drawing.Point(1, 6);
            this.bunPowerBar_1.MaximumValue = 60;
            this.bunPowerBar_1.Name = "bunPowerBar_1";
            this.bunPowerBar_1.ProgressColor = System.Drawing.Color.Teal;
            this.bunPowerBar_1.Size = new System.Drawing.Size(313, 42);
            this.bunPowerBar_1.TabIndex = 21;
            this.bunPowerBar_1.Value = 60;
            // 
            // lblSkillName_1
            // 
            this.lblSkillName_1.AutoSize = true;
            this.lblSkillName_1.BackColor = System.Drawing.Color.Transparent;
            this.lblSkillName_1.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillName_1.Location = new System.Drawing.Point(7, 6);
            this.lblSkillName_1.Name = "lblSkillName_1";
            this.lblSkillName_1.Size = new System.Drawing.Size(56, 21);
            this.lblSkillName_1.TabIndex = 23;
            this.lblSkillName_1.Text = "Temp";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OrangeRed;
            this.panel1.Controls.Add(this.lblSkillName_1);
            this.panel1.Location = new System.Drawing.Point(6, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(76, 31);
            this.panel1.TabIndex = 24;
            // 
            // PanelSkill_1
            // 
            this.PanelSkill_1.Controls.Add(this.lblSkillCount_1);
            this.PanelSkill_1.Controls.Add(this.panel1);
            this.PanelSkill_1.Controls.Add(this.bunPowerBar_1);
            this.PanelSkill_1.Location = new System.Drawing.Point(6, 5);
            this.PanelSkill_1.Name = "PanelSkill_1";
            this.PanelSkill_1.Size = new System.Drawing.Size(319, 53);
            this.PanelSkill_1.TabIndex = 25;
            this.PanelSkill_1.Visible = false;
            // 
            // PanelSkill_2
            // 
            this.PanelSkill_2.Controls.Add(this.lblSkillCount_2);
            this.PanelSkill_2.Controls.Add(this.panel2);
            this.PanelSkill_2.Controls.Add(this.bunPowerBar_2);
            this.PanelSkill_2.Location = new System.Drawing.Point(6, 48);
            this.PanelSkill_2.Name = "PanelSkill_2";
            this.PanelSkill_2.Size = new System.Drawing.Size(319, 53);
            this.PanelSkill_2.TabIndex = 26;
            this.PanelSkill_2.Visible = false;
            // 
            // lblSkillCount_2
            // 
            this.lblSkillCount_2.AutoSize = true;
            this.lblSkillCount_2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSkillCount_2.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillCount_2.Location = new System.Drawing.Point(258, 16);
            this.lblSkillCount_2.Name = "lblSkillCount_2";
            this.lblSkillCount_2.Size = new System.Drawing.Size(43, 21);
            this.lblSkillCount_2.TabIndex = 22;
            this.lblSkillCount_2.Text = "60 s";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OrangeRed;
            this.panel2.Controls.Add(this.lblSkillName_2);
            this.panel2.Location = new System.Drawing.Point(6, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(76, 31);
            this.panel2.TabIndex = 24;
            // 
            // lblSkillName_2
            // 
            this.lblSkillName_2.AutoSize = true;
            this.lblSkillName_2.BackColor = System.Drawing.Color.Transparent;
            this.lblSkillName_2.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillName_2.Location = new System.Drawing.Point(7, 6);
            this.lblSkillName_2.Name = "lblSkillName_2";
            this.lblSkillName_2.Size = new System.Drawing.Size(56, 21);
            this.lblSkillName_2.TabIndex = 23;
            this.lblSkillName_2.Text = "Temp";
            // 
            // bunPowerBar_2
            // 
            this.bunPowerBar_2.BackColor = System.Drawing.Color.DarkGray;
            this.bunPowerBar_2.BorderRadius = 5;
            this.bunPowerBar_2.Location = new System.Drawing.Point(1, 6);
            this.bunPowerBar_2.MaximumValue = 60;
            this.bunPowerBar_2.Name = "bunPowerBar_2";
            this.bunPowerBar_2.ProgressColor = System.Drawing.Color.Teal;
            this.bunPowerBar_2.Size = new System.Drawing.Size(313, 42);
            this.bunPowerBar_2.TabIndex = 21;
            this.bunPowerBar_2.Value = 60;
            // 
            // PanelSkill_3
            // 
            this.PanelSkill_3.Controls.Add(this.lblSkillCount_3);
            this.PanelSkill_3.Controls.Add(this.panel3);
            this.PanelSkill_3.Controls.Add(this.bunPowerBar_3);
            this.PanelSkill_3.Location = new System.Drawing.Point(6, 95);
            this.PanelSkill_3.Name = "PanelSkill_3";
            this.PanelSkill_3.Size = new System.Drawing.Size(319, 53);
            this.PanelSkill_3.TabIndex = 27;
            this.PanelSkill_3.Visible = false;
            // 
            // lblSkillCount_3
            // 
            this.lblSkillCount_3.AutoSize = true;
            this.lblSkillCount_3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblSkillCount_3.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillCount_3.Location = new System.Drawing.Point(258, 16);
            this.lblSkillCount_3.Name = "lblSkillCount_3";
            this.lblSkillCount_3.Size = new System.Drawing.Size(43, 21);
            this.lblSkillCount_3.TabIndex = 22;
            this.lblSkillCount_3.Text = "60 s";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.OrangeRed;
            this.panel3.Controls.Add(this.lblSkillName_3);
            this.panel3.Location = new System.Drawing.Point(6, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(76, 31);
            this.panel3.TabIndex = 24;
            // 
            // lblSkillName_3
            // 
            this.lblSkillName_3.AutoSize = true;
            this.lblSkillName_3.BackColor = System.Drawing.Color.Transparent;
            this.lblSkillName_3.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.lblSkillName_3.Location = new System.Drawing.Point(7, 6);
            this.lblSkillName_3.Name = "lblSkillName_3";
            this.lblSkillName_3.Size = new System.Drawing.Size(56, 21);
            this.lblSkillName_3.TabIndex = 23;
            this.lblSkillName_3.Text = "Temp";
            // 
            // bunPowerBar_3
            // 
            this.bunPowerBar_3.BackColor = System.Drawing.Color.DarkGray;
            this.bunPowerBar_3.BorderRadius = 5;
            this.bunPowerBar_3.Location = new System.Drawing.Point(1, 6);
            this.bunPowerBar_3.MaximumValue = 60;
            this.bunPowerBar_3.Name = "bunPowerBar_3";
            this.bunPowerBar_3.ProgressColor = System.Drawing.Color.Teal;
            this.bunPowerBar_3.Size = new System.Drawing.Size(313, 42);
            this.bunPowerBar_3.TabIndex = 21;
            this.bunPowerBar_3.Value = 60;
            // 
            // TimerMainCount
            // 
            this.TimerMainCount.Interval = 1000;
            this.TimerMainCount.Tick += new System.EventHandler(this.TimerMainCount_Tick);
            // 
            // btnFast
            // 
            this.btnFast.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFast.BorderRadius = 0;
            this.btnFast.ButtonText = "<<";
            this.btnFast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFast.DisabledColor = System.Drawing.Color.Gray;
            this.btnFast.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFast.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFast.Iconimage")));
            this.btnFast.Iconimage_right = null;
            this.btnFast.Iconimage_right_Selected = null;
            this.btnFast.Iconimage_Selected = null;
            this.btnFast.IconMarginLeft = 0;
            this.btnFast.IconMarginRight = 0;
            this.btnFast.IconRightVisible = true;
            this.btnFast.IconRightZoom = 0D;
            this.btnFast.IconVisible = false;
            this.btnFast.IconZoom = 90D;
            this.btnFast.IsTab = false;
            this.btnFast.Location = new System.Drawing.Point(331, 5);
            this.btnFast.Name = "btnFast";
            this.btnFast.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFast.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnFast.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFast.selected = false;
            this.btnFast.Size = new System.Drawing.Size(46, 44);
            this.btnFast.TabIndex = 30;
            this.btnFast.Text = "<<";
            this.btnFast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFast.Textcolor = System.Drawing.Color.Black;
            this.btnFast.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnRewind
            // 
            this.btnRewind.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRewind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRewind.BorderRadius = 0;
            this.btnRewind.ButtonText = ">>";
            this.btnRewind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRewind.DisabledColor = System.Drawing.Color.Gray;
            this.btnRewind.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRewind.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRewind.Iconimage")));
            this.btnRewind.Iconimage_right = null;
            this.btnRewind.Iconimage_right_Selected = null;
            this.btnRewind.Iconimage_Selected = null;
            this.btnRewind.IconMarginLeft = 0;
            this.btnRewind.IconMarginRight = 0;
            this.btnRewind.IconRightVisible = true;
            this.btnRewind.IconRightZoom = 0D;
            this.btnRewind.IconVisible = false;
            this.btnRewind.IconZoom = 90D;
            this.btnRewind.IsTab = false;
            this.btnRewind.Location = new System.Drawing.Point(434, 5);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRewind.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnRewind.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRewind.selected = false;
            this.btnRewind.Size = new System.Drawing.Size(46, 44);
            this.btnRewind.TabIndex = 31;
            this.btnRewind.Text = ">>";
            this.btnRewind.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRewind.Textcolor = System.Drawing.Color.Black;
            this.btnRewind.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRewind.Click += new System.EventHandler(this.btnRewind_Click);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStartStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStartStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartStop.BorderRadius = 0;
            this.btnStartStop.ButtonText = "口";
            this.btnStartStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStartStop.DisabledColor = System.Drawing.Color.Gray;
            this.btnStartStop.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStartStop.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStartStop.Iconimage")));
            this.btnStartStop.Iconimage_right = null;
            this.btnStartStop.Iconimage_right_Selected = null;
            this.btnStartStop.Iconimage_Selected = null;
            this.btnStartStop.IconMarginLeft = 0;
            this.btnStartStop.IconMarginRight = 0;
            this.btnStartStop.IconRightVisible = true;
            this.btnStartStop.IconRightZoom = 0D;
            this.btnStartStop.IconVisible = false;
            this.btnStartStop.IconZoom = 90D;
            this.btnStartStop.IsTab = false;
            this.btnStartStop.Location = new System.Drawing.Point(382, 5);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStartStop.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnStartStop.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStartStop.selected = false;
            this.btnStartStop.Size = new System.Drawing.Size(46, 44);
            this.btnStartStop.TabIndex = 32;
            this.btnStartStop.Text = "口";
            this.btnStartStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStartStop.Textcolor = System.Drawing.Color.Black;
            this.btnStartStop.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // btnRe
            // 
            this.btnRe.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRe.BorderRadius = 0;
            this.btnRe.ButtonText = "Re";
            this.btnRe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRe.DisabledColor = System.Drawing.Color.Gray;
            this.btnRe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRe.Iconcolor = System.Drawing.Color.Transparent;
            this.btnRe.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnRe.Iconimage")));
            this.btnRe.Iconimage_right = null;
            this.btnRe.Iconimage_right_Selected = null;
            this.btnRe.Iconimage_Selected = null;
            this.btnRe.IconMarginLeft = 0;
            this.btnRe.IconMarginRight = 0;
            this.btnRe.IconRightVisible = true;
            this.btnRe.IconRightZoom = 0D;
            this.btnRe.IconVisible = false;
            this.btnRe.IconZoom = 90D;
            this.btnRe.IsTab = false;
            this.btnRe.Location = new System.Drawing.Point(382, 103);
            this.btnRe.Name = "btnRe";
            this.btnRe.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnRe.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnRe.OnHoverTextColor = System.Drawing.Color.White;
            this.btnRe.selected = false;
            this.btnRe.Size = new System.Drawing.Size(46, 44);
            this.btnRe.TabIndex = 33;
            this.btnRe.Text = "Re";
            this.btnRe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRe.Textcolor = System.Drawing.Color.Black;
            this.btnRe.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRe.Click += new System.EventHandler(this.btnRe_Click);
            // 
            // TimerSupCount
            // 
            this.TimerSupCount.Tick += new System.EventHandler(this.TimerSupCount_Tick);
            // 
            // btnExist
            // 
            this.btnExist.BackColor = System.Drawing.Color.SeaGreen;
            this.btnExist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExist.FlatAppearance.BorderSize = 0;
            this.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnExist.Location = new System.Drawing.Point(434, 103);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(46, 44);
            this.btnExist.TabIndex = 35;
            this.btnExist.Text = "Exist";
            this.btnExist.UseVisualStyleBackColor = false;
            this.btnExist.Click += new System.EventHandler(this.btnExist_Click);
            // 
            // TimerCaptureCount
            // 
            this.TimerCaptureCount.Tick += new System.EventHandler(this.TimerHPCount_Tick);
            // 
            // TimerStartFight
            // 
            this.TimerStartFight.Interval = 200;
            this.TimerStartFight.Tick += new System.EventHandler(this.TimerStartFight_Tick);
            // 
            // TimerShout
            // 
            this.TimerShout.Tick += new System.EventHandler(this.TimerShout_Tick);
            // 
            // GlobalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(330, 151);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.btnRe);
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnRewind);
            this.Controls.Add(this.btnFast);
            this.Controls.Add(this.PanelSkill_3);
            this.Controls.Add(this.PanelSkill_2);
            this.Controls.Add(this.PanelSkill_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(0, 180);
            this.Name = "GlobalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.Shown += new System.EventHandler(this.GlobalForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelSkill_1.ResumeLayout(false);
            this.PanelSkill_1.PerformLayout();
            this.PanelSkill_2.ResumeLayout(false);
            this.PanelSkill_2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelSkill_3.ResumeLayout(false);
            this.PanelSkill_3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblSkillCount_1;
        internal Bunifu.Framework.UI.BunifuProgressBar bunPowerBar_1;
        internal System.Windows.Forms.Label lblSkillName_1;
        internal System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Panel PanelSkill_1;
        internal System.Windows.Forms.Panel PanelSkill_2;
        internal System.Windows.Forms.Label lblSkillCount_2;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Label lblSkillName_2;
        internal Bunifu.Framework.UI.BunifuProgressBar bunPowerBar_2;
        internal System.Windows.Forms.Panel PanelSkill_3;
        internal System.Windows.Forms.Label lblSkillCount_3;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.Label lblSkillName_3;
        internal Bunifu.Framework.UI.BunifuProgressBar bunPowerBar_3;
        internal System.Windows.Forms.Timer TimerMainCount;
        internal Bunifu.Framework.UI.BunifuFlatButton btnFast;
        internal Bunifu.Framework.UI.BunifuFlatButton btnRewind;
        internal Bunifu.Framework.UI.BunifuFlatButton btnStartStop;
        internal Bunifu.Framework.UI.BunifuFlatButton btnRe;
        internal System.Windows.Forms.Timer TimerSupCount;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Timer TimerCaptureCount;
        private System.Windows.Forms.Timer TimerStartFight;
        private System.Windows.Forms.Timer TimerShout;
    }
}