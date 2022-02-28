using System;
using System.Drawing;

namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 謝語_25 : GlobalForm {
        public 謝語_25 () {
            InitializeComponent ();
            CheckForIllegalCrossThreadCalls = false;
        }

        int temp = 1;

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (temp == 1) {
                if (FightTimecount == 1) {
                    SetProcessBar (bunPowerBar_2, 25, "定風");
                    SetProcessBar (bunPowerBar_3, 16, "車出");
                }
                if (FightTimecount == 16)
                    SetProcessBar (bunPowerBar_3, 6, "躲車");

                if (FightTimecount == 25) {
                    SetProcessBar (bunPowerBar_2, 38, "蝶骨");
                    SetProcessBar (bunPowerBar_3, 22, "牽絲");
                }

                if (FightTimecount == 47) {
                    SetProcessBar (bunPowerBar_1, 30, "轉階?");
                    SetProcessBar (bunPowerBar_3, 28, "躲車");
                }

                if (FightTimecount == 65)
                    SetProcessBar (bunPowerBar_2, 27, "定風");

                if (FightTimecount == 92) {
                    panel2.Size = new Size (118, 31);
                    SetProcessBar (bunPowerBar_2, 16, "躲車+牽絲");
                }

            }

            if (temp == 2) {

                if (FightTimecount == 1)
                    SetProcessBar (bunPowerBar_3, 19, "躲車");
                if (FightTimecount == 20)
                    SetProcessBar (bunPowerBar_3, 18, "雙牽絲");
                if (FightTimecount == 38) {
                    panel3.Size = new Size (96, 31);
                    SetProcessBar (bunPowerBar_3, 11, "牽絲(鎮");
                }

                if (FightTimecount == 49) {
                    panel3.Size = new Size (76, 31);
                    SetProcessBar (bunPowerBar_1, 25, "蝶骨");
                    SetProcessBar (bunPowerBar_2, 17, "定風");
                    SetProcessBar (bunPowerBar_3, 14, "牽絲爆");
                }

                if (FightTimecount == 63) {
                    panel3.Size = new Size (105, 31);
                    SetProcessBar (bunPowerBar_3, 60, "轉階?(車");
                }
            }

            if (temp == 3) {
                if (FightTimecount == 1)
                    SetProcessBar (bunPowerBar_3, 11, "牽絲爆");
                if (FightTimecount == 15)
                    SetProcessBar (bunPowerBar_3, 10, "牽絲爆");
                if (FightTimecount == 30) {
                    panel2.Size = new Size (158, 31);
                    SetProcessBar (bunPowerBar_2, 21, "轉P蝶骨或定風");
                    SetProcessBar (bunPowerBar_3, 18, "躲車");
                }

                if (FightTimecount == 48) {
                    panel2.Size = new Size (172, 31);
                    SetProcessBar (bunPowerBar_3, 12, "轉P蝶骨或單牽絲");
                }

            }

            if (temp == 4) {
                if (FightTimecount == 1) {
                    SetProcessBar (bunPowerBar_2, 29, "蝶骨");
                    SetProcessBar (bunPowerBar_3, 11, "牽絲爆");
                }

                if (FightTimecount == 15)
                    SetProcessBar (bunPowerBar_3, 10, "牽絲爆");
                if (FightTimecount == 25) {
                    SetProcessBar (bunPowerBar_1, 18, "小怪");
                    SetProcessBar (bunPowerBar_3, 16, "躲車");
                }
            }
        }

        private void btnP2_Click (object sender, EventArgs e) {
            temp = 2;
            FightTimecount = 0;
            TimerMainCount.Start ();
            panel1.Size = new Size (76, 31);
            panel2.Size = new Size (76, 31);
            panel3.Size = new Size (76, 31);
            PanelSkill_1.Visible = false;
            PanelSkill_2.Visible = false;
            PanelSkill_3.Visible = false;
        }

        private void btnP3_Click (object sender, EventArgs e) {
            temp = 3;
            FightTimecount = 0;
            TimerMainCount.Start ();
            panel1.Size = new Size (76, 31);
            panel2.Size = new Size (76, 31);
            panel3.Size = new Size (76, 31);
            PanelSkill_1.Visible = false;
            PanelSkill_2.Visible = false;
            PanelSkill_3.Visible = false;

        }

        private void bunifuFlatButton1_Click (object sender, EventArgs e) {
            temp = 4;
            FightTimecount = 0;
            TimerMainCount.Start ();
            panel1.Size = new Size (76, 31);
            panel2.Size = new Size (76, 31);
            panel3.Size = new Size (76, 31);
            PanelSkill_1.Visible = false;
            PanelSkill_2.Visible = false;
            PanelSkill_3.Visible = false;
        }
    }
}