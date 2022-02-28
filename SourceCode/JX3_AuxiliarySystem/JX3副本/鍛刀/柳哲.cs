namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 柳哲: GlobalForm {
        public 柳哲() {
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 1)
                SetProcessBar (bunPowerBar_3, 11, "落楓斬");

            if (FightTimecount == 10)
                SetProcessBar (bunPowerBar_3, 11, "冰火刀");

            if (FightTimecount == 20)
                SetProcessBar (bunPowerBar_3, 8, "冰圈");

            if (FightTimecount == 29)
                SetProcessBar (bunPowerBar_2, 14, "跑圈");

            if (FightTimecount == 57)
                FightTimecount = 0;
        }
    }
}