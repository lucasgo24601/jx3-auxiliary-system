using System;

namespace JX3_AuxiliarySystem.JX3.狼神 {
    public partial class 史思明: GlobalForm {
        private bool P2 = false;
        private int Count = 0;

        public 史思明() {
            InitializeComponent ();
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (P2 == false) {
                if ((FightTimecount % 10 == 0 | FightTimecount == 1) & FightTimecount < 85)
                    SetProcessBar (bunPowerBar_3, 10, "回龍");
                if ((FightTimecount % 35 == 0 | FightTimecount == 1) & Count < 2) {
                    Count++;
                    if (Count > 1)
                        SetProcessBar (bunPowerBar_1, 15, "獻寄");
                    SetProcessBar (bunPowerBar_2, 35, "練血");
                }

                if (FightTimecount == 70)
                    SetProcessBar (bunPowerBar_2, 15, "獻寄");

                if (FightTimecount == 85) {
                    SetProcessBar (bunPowerBar_2, 10, "鱷魚出");
                    SetProcessBar (bunPowerBar_3, 10, "血奴-1");
                }

                //---------------------- P2 Same

                if (FightTimecount == 94) {
                    FightTimecount = 0;
                    P2 = true;
                }

            } else {
                if (FightTimecount == 1) {
                    SetProcessBar (bunPowerBar_3, 15, "血奴-2");
                    SetProcessBar (bunPowerBar_2, 15, "鱷魚OT");
                    SetProcessBar (bunPowerBar_1, 15, "獻寄-1");
                }

                if (FightTimecount == 15) {
                    SetProcessBar (bunPowerBar_3, 15, "P3");
                    SetProcessBar (bunPowerBar_2, 15, "轉火鱷魚");
                    SetProcessBar (bunPowerBar_1, 15, "獻寄-2");
                }
                if (FightTimecount == 40)
                    SetProcessBar (bunPowerBar_3, 10, "回龍");
                if (FightTimecount == 50)
                    SetProcessBar (bunPowerBar_3, 12, "回龍換坦");
                if (FightTimecount == 62) {
                    SetProcessBar (bunPowerBar_1, 16, "回龍");
                    SetProcessBar (bunPowerBar_2, 8, "鱷魚");
                    SetProcessBar (bunPowerBar_3, 10, "血液感染");
                }

                if (FightTimecount == 78) {
                    SetProcessBar (bunPowerBar_1, 18, "綠球");
                    SetProcessBar (bunPowerBar_2, 23, "藍技能");
                    SetProcessBar (bunPowerBar_3, 13, "回龍換坦");
                }

                if (FightTimecount == 91)
                    SetProcessBar (bunPowerBar_3, 12, "鱷魚");

            }

        }

        private void btnP2_65_Click (object sender, EventArgs e) {
            P2 = true;
            FightTimecount = 0;
            TimerMainCount.Start ();
        }
    }
}