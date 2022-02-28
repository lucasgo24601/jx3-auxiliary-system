namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 謝語: GlobalForm {
        public 謝語() {
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 1)
                SetProcessBar (bunPowerBar_3, 14, "問花"); // AOE是讀條 所以實測時間不同
            if (FightTimecount == 14)
                SetProcessBar (bunPowerBar_3, 14, "定風");
        }
    }
}