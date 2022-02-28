namespace JX3_AuxiliarySystem.JX3.狼神
{
    partial class 勒空明
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(勒空明));
            this.btnFormation = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnNormal = new Bunifu.Framework.UI.BunifuFlatButton();
            this.SuspendLayout();
            // 
            // btnFormation
            // 
            this.btnFormation.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFormation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFormation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFormation.BorderRadius = 0;
            this.btnFormation.ButtonText = "軍陣";
            this.btnFormation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormation.DisabledColor = System.Drawing.Color.Gray;
            this.btnFormation.Iconcolor = System.Drawing.Color.Transparent;
            this.btnFormation.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnFormation.Iconimage")));
            this.btnFormation.Iconimage_right = null;
            this.btnFormation.Iconimage_right_Selected = null;
            this.btnFormation.Iconimage_Selected = null;
            this.btnFormation.IconMarginLeft = 0;
            this.btnFormation.IconMarginRight = 0;
            this.btnFormation.IconRightVisible = true;
            this.btnFormation.IconRightZoom = 0D;
            this.btnFormation.IconVisible = false;
            this.btnFormation.IconZoom = 90D;
            this.btnFormation.IsTab = false;
            this.btnFormation.Location = new System.Drawing.Point(382, 53);
            this.btnFormation.Name = "btnFormation";
            this.btnFormation.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnFormation.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnFormation.OnHoverTextColor = System.Drawing.Color.White;
            this.btnFormation.selected = false;
            this.btnFormation.Size = new System.Drawing.Size(46, 44);
            this.btnFormation.TabIndex = 35;
            this.btnFormation.Text = "軍陣";
            this.btnFormation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFormation.Textcolor = System.Drawing.Color.Black;
            this.btnFormation.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnFormation.Click += new System.EventHandler(this.btnFormation_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNormal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNormal.BorderRadius = 0;
            this.btnNormal.ButtonText = "正常";
            this.btnNormal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNormal.DisabledColor = System.Drawing.Color.Gray;
            this.btnNormal.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNormal.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnNormal.Iconimage")));
            this.btnNormal.Iconimage_right = null;
            this.btnNormal.Iconimage_right_Selected = null;
            this.btnNormal.Iconimage_Selected = null;
            this.btnNormal.IconMarginLeft = 0;
            this.btnNormal.IconMarginRight = 0;
            this.btnNormal.IconRightVisible = true;
            this.btnNormal.IconRightZoom = 0D;
            this.btnNormal.IconVisible = false;
            this.btnNormal.IconZoom = 90D;
            this.btnNormal.IsTab = false;
            this.btnNormal.Location = new System.Drawing.Point(433, 53);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNormal.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btnNormal.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNormal.selected = false;
            this.btnNormal.Size = new System.Drawing.Size(46, 44);
            this.btnNormal.TabIndex = 36;
            this.btnNormal.Text = "正常";
            this.btnNormal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnNormal.Textcolor = System.Drawing.Color.Black;
            this.btnNormal.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // 勒空明
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(499, 151);
            this.Controls.Add(this.btnNormal);
            this.Controls.Add(this.btnFormation);
            this.Name = "勒空明";
            this.Controls.SetChildIndex(this.btnFormation, 0);
            this.Controls.SetChildIndex(this.btnNormal, 0);
            this.ResumeLayout(false);

        }


        private Bunifu.Framework.UI.BunifuFlatButton btnFormation;
        private Bunifu.Framework.UI.BunifuFlatButton btnNormal;
    }
}