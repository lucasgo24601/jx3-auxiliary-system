using System;

namespace JX3_AuxiliarySystem.JX3.狼神 {
    public partial class 勒空明: GlobalForm {
        private bool Arrary = false;

        public 勒空明() {
            InitializeComponent ();
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess () {
            FightTimecount++;
            if (Arrary == false) {
                if (FightTimecount == 1)
                    SetProcessBar (bunPowerBar_3, 9, "面相"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 9)
                    SetProcessBar (bunPowerBar_3, 14, "隨機"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 23)
                    SetProcessBar (bunPowerBar_3, 21, "隨機"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 33)
                    SetProcessBar (bunPowerBar_2, 10, "70% 30% ?"); // AOE是讀條 所以實測時間不同

                if (FightTimecount == 46)
                    SetProcessBar (bunPowerBar_3, 9, "面相"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 54)
                    SetProcessBar (bunPowerBar_3, 13, "隨機"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 67)
                    SetProcessBar (bunPowerBar_3, 23, "隨機"); // AOE是讀條 所以實測時間不同
            } else {
                if (FightTimecount == 1)
                    SetProcessBar (bunPowerBar_3, 17, "列陣"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 18)
                    SetProcessBar (bunPowerBar_3, 27, "狙擊"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 45)
                    SetProcessBar (bunPowerBar_3, 45, "狙擊"); // AOE是讀條 所以實測時間不同
                if (FightTimecount == 90)
                    SetProcessBar (bunPowerBar_3, 999, "速度(一隻"); // AOE是讀條 所以實測時間不同

            }
        }

        private void btnFormation_Click (object sender, EventArgs e) {
            Arrary = true;
            FightTimecount = 0;
            TimerMainCount.Start ();
        }

        private void btnNormal_Click (object sender, EventArgs e) {
            Arrary = false;
            FightTimecount = 0;
            TimerMainCount.Start ();
        }
    }
}