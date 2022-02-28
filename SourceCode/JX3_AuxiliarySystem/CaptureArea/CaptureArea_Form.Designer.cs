namespace JX3_AuxiliarySystem.CaptureArea {
    partial class CaptureArea_Form {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager (typeof (CaptureArea_Form));
            this.picCanvas = new System.Windows.Forms.PictureBox ();
            this.btnExist = new Bunifu.Framework.UI.BunifuFlatButton ();
            ((System.ComponentModel.ISupportInitialize) (this.picCanvas)).BeginInit ();
            this.SuspendLayout ();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point (0, 0);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size (347, 235);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler (this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler (this.picCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler (this.picCanvas_MouseUp);
            // 
            // btnExist
            // 
            this.btnExist.Activecolor = System.Drawing.Color.FromArgb (((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnExist.BackColor = System.Drawing.Color.FromArgb (((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnExist.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExist.BorderRadius = 0;
            this.btnExist.ButtonText = "離開";
            this.btnExist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExist.DisabledColor = System.Drawing.Color.Gray;
            this.btnExist.Iconcolor = System.Drawing.Color.Transparent;
            this.btnExist.Iconimage = ((System.Drawing.Image) (resources.GetObject ("btnExist.Iconimage")));
            this.btnExist.Iconimage_right = null;
            this.btnExist.Iconimage_right_Selected = null;
            this.btnExist.Iconimage_Selected = null;
            this.btnExist.IconMarginLeft = 0;
            this.btnExist.IconMarginRight = 0;
            this.btnExist.IconRightVisible = true;
            this.btnExist.IconRightZoom = 0D;
            this.btnExist.IconVisible = false;
            this.btnExist.IconZoom = 90D;
            this.btnExist.IsTab = false;
            this.btnExist.Location = new System.Drawing.Point (238, 515);
            this.btnExist.Name = "btnExist";
            this.btnExist.Normalcolor = System.Drawing.Color.FromArgb (((int) (((byte) (46)))), ((int) (((byte) (139)))), ((int) (((byte) (87)))));
            this.btnExist.OnHovercolor = System.Drawing.Color.FromArgb (((int) (((byte) (36)))), ((int) (((byte) (129)))), ((int) (((byte) (77)))));
            this.btnExist.OnHoverTextColor = System.Drawing.Color.White;
            this.btnExist.selected = false;
            this.btnExist.Size = new System.Drawing.Size (148, 47);
            this.btnExist.TabIndex = 23;
            this.btnExist.Text = "離開";
            this.btnExist.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnExist.Textcolor = System.Drawing.Color.White;
            this.btnExist.TextFont = new System.Drawing.Font ("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btnExist.Click += new System.EventHandler (this.btnExist_Click);
            // 
            // CaptureArea_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size (520, 574);
            this.Controls.Add (this.btnExist);
            this.Controls.Add (this.picCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CaptureArea_Form";
            this.Text = "Form1";
            this.Shown += new System.EventHandler (this.CaptureArea_Form_Shown);
            ((System.ComponentModel.ISupportInitialize) (this.picCanvas)).EndInit ();
            this.ResumeLayout (false);

        }

        #endregion

        public System.Windows.Forms.PictureBox picCanvas;
        private Bunifu.Framework.UI.BunifuFlatButton btnExist;
    }
}