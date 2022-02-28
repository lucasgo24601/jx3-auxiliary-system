namespace JX3_AuxiliarySystem.ImageLearnSystem
{
    public partial class ImageLearnSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageLearnSystem));
            this.picSourceImage = new System.Windows.Forms.PictureBox();
            this.txtDecode_All_Good = new System.Windows.Forms.TextBox();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.btnCutImage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDecode = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnStorage = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lblImage_X = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtImage_X = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.txtImage_Y = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblImage_Y = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtImage_W = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblImage_W = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.txtImage_H = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.lblImage_H = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnFixLocation = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSynchronize = new Bunifu.Framework.UI.BunifuFlatButton();
            this.Download_ProcessBar = new Bunifu.Framework.UI.BunifuSlider();
            this.pnlOutMessage = new System.Windows.Forms.Panel();
            this.pnlInputMessage = new System.Windows.Forms.Panel();
            this.TimerPanelScroll = new System.Windows.Forms.Timer(this.components);
            this.txtGraphical_All = new System.Windows.Forms.TextBox();
            this.txtDownload_Message = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSourceImage
            // 
            this.picSourceImage.Location = new System.Drawing.Point(9, 96);
            this.picSourceImage.Name = "picSourceImage";
            this.picSourceImage.Size = new System.Drawing.Size(628, 32);
            this.picSourceImage.TabIndex = 11;
            this.picSourceImage.TabStop = false;
            // 
            // txtDecode_All_Good
            // 
            this.txtDecode_All_Good.Location = new System.Drawing.Point(324, 993);
            this.txtDecode_All_Good.Multiline = true;
            this.txtDecode_All_Good.Name = "txtDecode_All_Good";
            this.txtDecode_All_Good.Size = new System.Drawing.Size(432, 53);
            this.txtDecode_All_Good.TabIndex = 27;
            // 
            // cboDatabase
            // 
            this.cboDatabase.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Items.AddRange(new object[] {
            "Timer",
            "HP",
            "科舉",
            "喊話"});
            this.cboDatabase.Location = new System.Drawing.Point(535, 59);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(89, 29);
            this.cboDatabase.TabIndex = 39;
            // 
            // btnCutImage
            // 
            this.btnCutImage.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCutImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCutImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCutImage.BorderRadius = 0;
            this.btnCutImage.ButtonText = "截圖";
            this.btnCutImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCutImage.DisabledColor = System.Drawing.Color.Gray;
            this.btnCutImage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnCutImage.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnCutImage.Iconimage")));
            this.btnCutImage.Iconimage_right = null;
            this.btnCutImage.Iconimage_right_Selected = null;
            this.btnCutImage.Iconimage_Selected = null;
            this.btnCutImage.IconMarginLeft = 0;
            this.btnCutImage.IconMarginRight = 0;
            this.btnCutImage.IconRightVisible = true;
            this.btnCutImage.IconRightZoom = 0D;
            this.btnCutImage.IconVisible = false;
            this.btnCutImage.IconZoom = 90D;
            this.btnCutImage.IsTab = false;
            this.btnCutImage.Location = new System.Drawing.Point(9, 3);
            this.btnCutImage.Name = "btnCutImage";
            this.btnCutImage.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnCutImage.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnCutImage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnCutImage.selected = false;
            this.btnCutImage.Size = new System.Drawing.Size(122, 40);
            this.btnCutImage.TabIndex = 41;
            this.btnCutImage.Text = "截圖";
            this.btnCutImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnCutImage.Textcolor = System.Drawing.Color.White;
            this.btnCutImage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCutImage.Click += new System.EventHandler(this.btnCutImage_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDecode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDecode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDecode.BorderRadius = 0;
            this.btnDecode.ButtonText = "解析";
            this.btnDecode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecode.DisabledColor = System.Drawing.Color.Gray;
            this.btnDecode.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDecode.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnDecode.Iconimage")));
            this.btnDecode.Iconimage_right = null;
            this.btnDecode.Iconimage_right_Selected = null;
            this.btnDecode.Iconimage_Selected = null;
            this.btnDecode.IconMarginLeft = 0;
            this.btnDecode.IconMarginRight = 0;
            this.btnDecode.IconRightVisible = true;
            this.btnDecode.IconRightZoom = 0D;
            this.btnDecode.IconVisible = false;
            this.btnDecode.IconZoom = 90D;
            this.btnDecode.IsTab = false;
            this.btnDecode.Location = new System.Drawing.Point(265, 3);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnDecode.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnDecode.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDecode.selected = false;
            this.btnDecode.Size = new System.Drawing.Size(122, 40);
            this.btnDecode.TabIndex = 42;
            this.btnDecode.Text = "解析";
            this.btnDecode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDecode.Textcolor = System.Drawing.Color.White;
            this.btnDecode.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnStorage
            // 
            this.btnStorage.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStorage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStorage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStorage.BorderRadius = 0;
            this.btnStorage.ButtonText = "入庫";
            this.btnStorage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStorage.DisabledColor = System.Drawing.Color.Gray;
            this.btnStorage.Iconcolor = System.Drawing.Color.Transparent;
            this.btnStorage.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnStorage.Iconimage")));
            this.btnStorage.Iconimage_right = null;
            this.btnStorage.Iconimage_right_Selected = null;
            this.btnStorage.Iconimage_Selected = null;
            this.btnStorage.IconMarginLeft = 0;
            this.btnStorage.IconMarginRight = 0;
            this.btnStorage.IconRightVisible = true;
            this.btnStorage.IconRightZoom = 0D;
            this.btnStorage.IconVisible = false;
            this.btnStorage.IconZoom = 90D;
            this.btnStorage.IsTab = false;
            this.btnStorage.Location = new System.Drawing.Point(393, 3);
            this.btnStorage.Name = "btnStorage";
            this.btnStorage.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStorage.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnStorage.OnHoverTextColor = System.Drawing.Color.White;
            this.btnStorage.selected = false;
            this.btnStorage.Size = new System.Drawing.Size(122, 40);
            this.btnStorage.TabIndex = 43;
            this.btnStorage.Text = "入庫";
            this.btnStorage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStorage.Textcolor = System.Drawing.Color.White;
            this.btnStorage.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStorage.Click += new System.EventHandler(this.btnStorage_Click);
            // 
            // lblImage_X
            // 
            this.lblImage_X.AutoSize = true;
            this.lblImage_X.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImage_X.Location = new System.Drawing.Point(13, 67);
            this.lblImage_X.Name = "lblImage_X";
            this.lblImage_X.Size = new System.Drawing.Size(50, 21);
            this.lblImage_X.TabIndex = 45;
            this.lblImage_X.Text = "X ：";
            // 
            // txtImage_X
            // 
            this.txtImage_X.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImage_X.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.txtImage_X.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImage_X.HintForeColor = System.Drawing.Color.Empty;
            this.txtImage_X.HintText = "";
            this.txtImage_X.isPassword = false;
            this.txtImage_X.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtImage_X.LineIdleColor = System.Drawing.Color.Gray;
            this.txtImage_X.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtImage_X.LineThickness = 4;
            this.txtImage_X.Location = new System.Drawing.Point(72, 56);
            this.txtImage_X.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtImage_X.Name = "txtImage_X";
            this.txtImage_X.Size = new System.Drawing.Size(54, 32);
            this.txtImage_X.TabIndex = 46;
            this.txtImage_X.Text = "308";
            this.txtImage_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtImage_Y
            // 
            this.txtImage_Y.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImage_Y.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.txtImage_Y.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImage_Y.HintForeColor = System.Drawing.Color.Empty;
            this.txtImage_Y.HintText = "";
            this.txtImage_Y.isPassword = false;
            this.txtImage_Y.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtImage_Y.LineIdleColor = System.Drawing.Color.Gray;
            this.txtImage_Y.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtImage_Y.LineThickness = 4;
            this.txtImage_Y.Location = new System.Drawing.Point(194, 56);
            this.txtImage_Y.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtImage_Y.Name = "txtImage_Y";
            this.txtImage_Y.Size = new System.Drawing.Size(54, 32);
            this.txtImage_Y.TabIndex = 48;
            this.txtImage_Y.Text = "113";
            this.txtImage_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblImage_Y
            // 
            this.lblImage_Y.AutoSize = true;
            this.lblImage_Y.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImage_Y.Location = new System.Drawing.Point(135, 67);
            this.lblImage_Y.Name = "lblImage_Y";
            this.lblImage_Y.Size = new System.Drawing.Size(50, 21);
            this.lblImage_Y.TabIndex = 47;
            this.lblImage_Y.Text = "Y ：";
            // 
            // txtImage_W
            // 
            this.txtImage_W.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImage_W.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.txtImage_W.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImage_W.HintForeColor = System.Drawing.Color.Empty;
            this.txtImage_W.HintText = "";
            this.txtImage_W.isPassword = false;
            this.txtImage_W.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtImage_W.LineIdleColor = System.Drawing.Color.Gray;
            this.txtImage_W.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtImage_W.LineThickness = 4;
            this.txtImage_W.Location = new System.Drawing.Point(321, 56);
            this.txtImage_W.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtImage_W.Name = "txtImage_W";
            this.txtImage_W.Size = new System.Drawing.Size(54, 32);
            this.txtImage_W.TabIndex = 50;
            this.txtImage_W.Text = "39";
            this.txtImage_W.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblImage_W
            // 
            this.lblImage_W.AutoSize = true;
            this.lblImage_W.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImage_W.Location = new System.Drawing.Point(257, 67);
            this.lblImage_W.Name = "lblImage_W";
            this.lblImage_W.Size = new System.Drawing.Size(55, 21);
            this.lblImage_W.TabIndex = 49;
            this.lblImage_W.Text = "W ：";
            // 
            // txtImage_H
            // 
            this.txtImage_H.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtImage_H.Font = new System.Drawing.Font("新細明體", 15.75F);
            this.txtImage_H.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtImage_H.HintForeColor = System.Drawing.Color.Empty;
            this.txtImage_H.HintText = "";
            this.txtImage_H.isPassword = false;
            this.txtImage_H.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtImage_H.LineIdleColor = System.Drawing.Color.Gray;
            this.txtImage_H.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtImage_H.LineThickness = 4;
            this.txtImage_H.Location = new System.Drawing.Point(443, 56);
            this.txtImage_H.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtImage_H.Name = "txtImage_H";
            this.txtImage_H.Size = new System.Drawing.Size(54, 32);
            this.txtImage_H.TabIndex = 52;
            this.txtImage_H.Text = "11";
            this.txtImage_H.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblImage_H
            // 
            this.lblImage_H.AutoSize = true;
            this.lblImage_H.Font = new System.Drawing.Font("新細明體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblImage_H.Location = new System.Drawing.Point(384, 67);
            this.lblImage_H.Name = "lblImage_H";
            this.lblImage_H.Size = new System.Drawing.Size(50, 21);
            this.lblImage_H.TabIndex = 51;
            this.lblImage_H.Text = "H ：";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnFixLocation);
            this.pnlMain.Controls.Add(this.btnSynchronize);
            this.pnlMain.Controls.Add(this.btnCutImage);
            this.pnlMain.Controls.Add(this.txtImage_H);
            this.pnlMain.Controls.Add(this.picSourceImage);
            this.pnlMain.Controls.Add(this.lblImage_H);
            this.pnlMain.Controls.Add(this.cboDatabase);
            this.pnlMain.Controls.Add(this.txtImage_W);
            this.pnlMain.Controls.Add(this.btnDecode);
            this.pnlMain.Controls.Add(this.lblImage_W);
            this.pnlMain.Controls.Add(this.btnStorage);
            this.pnlMain.Controls.Add(this.txtImage_Y);
            this.pnlMain.Controls.Add(this.lblImage_X);
            this.pnlMain.Controls.Add(this.lblImage_Y);
            this.pnlMain.Controls.Add(this.txtImage_X);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(650, 132);
            this.pnlMain.TabIndex = 53;
            // 
            // btnFixLocation
            // 
            this.btnFixLocation.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFixLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFixLocation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFixLocation.BorderRadius = 0;
            this.btnFixLocation.ButtonText = "修正位置";
            this.btnFixLocation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFixLocation.DisabledColor = System.Drawing.Color.Gray;
            this.btnFixLocation.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFixLocation.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFixLocation.Iconimage")));
            this.btnFixLocation.Iconimage_right = null;
            this.btnFixLocation.Iconimage_right_Selected = null;
            this.btnFixLocation.Iconimage_Selected = null;
            this.btnFixLocation.IconMarginLeft = 0;
            this.btnFixLocation.IconMarginRight = 0;
            this.btnFixLocation.IconRightVisible = true;
            this.btnFixLocation.IconRightZoom = 0D;
            this.btnFixLocation.IconVisible = false;
            this.btnFixLocation.IconZoom = 90D;
            this.btnFixLocation.IsTab = false;
            this.btnFixLocation.Location = new System.Drawing.Point(137, 3);
            this.btnFixLocation.Name = "btnFixLocation";
            this.btnFixLocation.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFixLocation.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnFixLocation.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFixLocation.selected = false;
            this.btnFixLocation.Size = new System.Drawing.Size(122, 40);
            this.btnFixLocation.TabIndex = 54;
            this.btnFixLocation.Text = "修正位置";
            this.btnFixLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFixLocation.Textcolor = System.Drawing.Color.White;
            this.btnFixLocation.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFixLocation.Click += new System.EventHandler(this.btnFixLocation_Click);
            // 
            // btnSynchronize
            // 
            this.btnSynchronize.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSynchronize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSynchronize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSynchronize.BorderRadius = 0;
            this.btnSynchronize.ButtonText = "更新數據庫";
            this.btnSynchronize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSynchronize.DisabledColor = System.Drawing.Color.Gray;
            this.btnSynchronize.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSynchronize.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSynchronize.Iconimage")));
            this.btnSynchronize.Iconimage_right = null;
            this.btnSynchronize.Iconimage_right_Selected = null;
            this.btnSynchronize.Iconimage_Selected = null;
            this.btnSynchronize.IconMarginLeft = 0;
            this.btnSynchronize.IconMarginRight = 0;
            this.btnSynchronize.IconRightVisible = true;
            this.btnSynchronize.IconRightZoom = 0D;
            this.btnSynchronize.IconVisible = false;
            this.btnSynchronize.IconZoom = 90D;
            this.btnSynchronize.IsTab = false;
            this.btnSynchronize.Location = new System.Drawing.Point(521, 3);
            this.btnSynchronize.Name = "btnSynchronize";
            this.btnSynchronize.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnSynchronize.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnSynchronize.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSynchronize.selected = false;
            this.btnSynchronize.Size = new System.Drawing.Size(122, 40);
            this.btnSynchronize.TabIndex = 53;
            this.btnSynchronize.Text = "更新數據庫";
            this.btnSynchronize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSynchronize.Textcolor = System.Drawing.Color.White;
            this.btnSynchronize.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSynchronize.Click += new System.EventHandler(this.btnSynchronize_Click);
            // 
            // Download_ProcessBar
            // 
            this.Download_ProcessBar.BackColor = System.Drawing.Color.Transparent;
            this.Download_ProcessBar.BackgroudColor = System.Drawing.Color.DarkGray;
            this.Download_ProcessBar.BorderRadius = 0;
            this.Download_ProcessBar.IndicatorColor = System.Drawing.Color.SeaGreen;
            this.Download_ProcessBar.Location = new System.Drawing.Point(0, 383);
            this.Download_ProcessBar.MaximumValue = 8;
            this.Download_ProcessBar.Name = "Download_ProcessBar";
            this.Download_ProcessBar.Size = new System.Drawing.Size(630, 28);
            this.Download_ProcessBar.TabIndex = 58;
            this.Download_ProcessBar.Value = 1;
            this.Download_ProcessBar.Visible = false;
            // 
            // pnlOutMessage
            // 
            this.pnlOutMessage.AutoScroll = true;
            this.pnlOutMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOutMessage.Location = new System.Drawing.Point(0, 430);
            this.pnlOutMessage.Name = "pnlOutMessage";
            this.pnlOutMessage.Size = new System.Drawing.Size(650, 298);
            this.pnlOutMessage.TabIndex = 55;
            this.pnlOutMessage.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Panel_Scroll);
            // 
            // pnlInputMessage
            // 
            this.pnlInputMessage.AutoScroll = true;
            this.pnlInputMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputMessage.Location = new System.Drawing.Point(0, 728);
            this.pnlInputMessage.Name = "pnlInputMessage";
            this.pnlInputMessage.Size = new System.Drawing.Size(650, 70);
            this.pnlInputMessage.TabIndex = 56;
            this.pnlInputMessage.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Panel_Scroll);
            // 
            // TimerPanelScroll
            // 
            this.TimerPanelScroll.Enabled = true;
            this.TimerPanelScroll.Interval = 300;
            this.TimerPanelScroll.Tick += new System.EventHandler(this.TimerPanelScroll_Tick);
            // 
            // txtGraphical_All
            // 
            this.txtGraphical_All.AcceptsReturn = true;
            this.txtGraphical_All.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtGraphical_All.Font = new System.Drawing.Font("細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtGraphical_All.Location = new System.Drawing.Point(0, 132);
            this.txtGraphical_All.Multiline = true;
            this.txtGraphical_All.Name = "txtGraphical_All";
            this.txtGraphical_All.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGraphical_All.Size = new System.Drawing.Size(650, 298);
            this.txtGraphical_All.TabIndex = 54;
            this.txtGraphical_All.WordWrap = false;
            // 
            // txtDownload_Message
            // 
            this.txtDownload_Message.Font = new System.Drawing.Font("細明體", 12F);
            this.txtDownload_Message.Location = new System.Drawing.Point(3, 350);
            this.txtDownload_Message.Name = "txtDownload_Message";
            this.txtDownload_Message.Size = new System.Drawing.Size(627, 27);
            this.txtDownload_Message.TabIndex = 59;
            this.txtDownload_Message.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDownload_Message.Visible = false;
            // 
            // ImageLearnSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(650, 798);
            this.Controls.Add(this.txtDownload_Message);
            this.Controls.Add(this.Download_ProcessBar);
            this.Controls.Add(this.pnlInputMessage);
            this.Controls.Add(this.pnlOutMessage);
            this.Controls.Add(this.txtGraphical_All);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.txtDecode_All_Good);
            this.Name = "ImageLearnSystem";
            this.Text = "影像學習系統";
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picSourceImage;
        private System.Windows.Forms.TextBox txtDecode_All_Good;
        private System.Windows.Forms.ComboBox cboDatabase;
        private Bunifu.Framework.UI.BunifuFlatButton btnCutImage;
        private Bunifu.Framework.UI.BunifuFlatButton btnDecode;
        private Bunifu.Framework.UI.BunifuFlatButton btnStorage;
        private Bunifu.Framework.UI.BunifuCustomLabel lblImage_X;
        private Bunifu.Framework.UI.BunifuCustomLabel lblImage_Y;
        private Bunifu.Framework.UI.BunifuCustomLabel lblImage_W;
        private Bunifu.Framework.UI.BunifuCustomLabel lblImage_H;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtImage_X;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtImage_Y;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtImage_W;
        public Bunifu.Framework.UI.BunifuMaterialTextbox txtImage_H;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlOutMessage;
        private System.Windows.Forms.Panel pnlInputMessage;
        private System.Windows.Forms.Timer TimerPanelScroll;
        private Bunifu.Framework.UI.BunifuFlatButton btnSynchronize;
        private Bunifu.Framework.UI.BunifuSlider Download_ProcessBar;
        private System.Windows.Forms.TextBox txtGraphical_All;
        private Bunifu.Framework.UI.BunifuFlatButton btnFixLocation;
        private System.Windows.Forms.TextBox txtDownload_Message;
    }
}