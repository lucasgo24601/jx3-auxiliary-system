using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JX3_AuxiliarySystem.JX3;

namespace JX3_AuxiliarySystem.JX3.戰獸 {
    public partial class 報九楓: GlobalForm {
        public 報九楓() {
            InitializeComponent ();
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 1) {
                SetProcessBar (bunPowerBar_3, 18, "躲圈");

            }
            if (FightTimecount == 18) {
                SetProcessBar (bunPowerBar_1, 21, "出蝴蝶");
                SetProcessBar (bunPowerBar_2, 23, "上水");
                SetProcessBar (bunPowerBar_3, 18, "下水");
            }

            if (FightTimecount == 39)
                SetProcessBar (bunPowerBar_1, 4, "打蝴蝶");

            if (FightTimecount == 41) {
                SetProcessBar (bunPowerBar_1, 21, "出蝴蝶");
                SetProcessBar (bunPowerBar_2, 23, "上水");
                SetProcessBar (bunPowerBar_3, 18, "下水");
            }

        }
    }
}