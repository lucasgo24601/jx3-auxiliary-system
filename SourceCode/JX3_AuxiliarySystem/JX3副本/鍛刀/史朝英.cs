using System.Drawing;

namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 史朝英: GlobalForm {
        public 史朝英() {
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount % 45 == 0 | FightTimecount == 1)
                SetProcessBar (bunPowerBar_2, 46, "AOE"); // AOE是讀條 所以實測時間不同

            if (FightTimecount % 50 == 0 | FightTimecount == 1) {
                if (BossTemp == false) {
                    panel3.Size = new Size (76, 31);
                    SetProcessBar (bunPowerBar_3, 50, "清霄衛");
                } else {
                    panel3.Size = new Size (113, 31);
                    SetProcessBar (bunPowerBar_3, 50, "落雷+耀武");
                }
                BossTemp = !BossTemp;
            }
        }
    }
}