namespace JX3_AuxiliarySystem.JX3.狼神 {
    public partial class 烏索: GlobalForm {
        public 烏索() {
            CheckForIllegalCrossThreadCalls = false;
            TimerSupCount.Start ();
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 120)
                SetProcessBar (bunPowerBar_2, 40, "旋石"); // AOE是讀條 所以實測時間不同

            if (FightTimecount == 300)
                SetProcessBar (bunPowerBar_2, 40, "旋石"); // AOE是讀條 所以實測時間不同
        }

        internal override void SupTimerProcess () {
            POINTFX p;
            GetCursorPos (out p);
            if (p.X.fract == 0 | p.Y.fract == 0)
                SetProcessBar (bunPowerBar_3, 20, "蟲-減傷"); // AOE是讀條 所以實測時間不同
        }

        private void InitializeComponent () {
            this.SuspendLayout ();
            // 
            // 烏索
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF (6F, 12F);
            this.ClientSize = new System.Drawing.Size (499, 151);
            this.Name = "烏索";
            this.ResumeLayout (false);

        }
    }
}