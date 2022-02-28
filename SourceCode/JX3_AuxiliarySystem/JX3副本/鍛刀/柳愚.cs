using System.Drawing;

namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 柳愚: GlobalForm {
        public 柳愚() {
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 1)
                SetProcessBar (bunPowerBar_3, 15, "沈舟刀");

            if (FightTimecount == 17) {
                panel2.Size = new Size (167, 31);
                panel3.Size = new Size (167, 31);
                SetProcessBar (bunPowerBar_2, 250, "85% _ 70%");
                SetProcessBar (bunPowerBar_3, 400, "55% _ 40% _ 25%");
            }
        }
    }
}