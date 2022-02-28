namespace JX3_AuxiliarySystem.JX3.鍛刀 {
    public partial class 柳時清: GlobalForm {
        public 柳時清() {
            InitializeComponent ();
        }

        internal override void MainTimerProcess () {
            FightTimecount++;

            if (FightTimecount == 1) {
                SetProcessBar (bunPowerBar_2, 300, "65%   15%");
                SetProcessBar (bunPowerBar_3, 30, "飛刃");
            }
        }
    }
}