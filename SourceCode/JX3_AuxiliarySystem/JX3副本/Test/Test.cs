
namespace JX3_AuxiliarySystem.JX3.Test
{
    public partial class Test : GlobalForm
    {
        public Test()
        {
            CheckForIllegalCrossThreadCalls = false;
        }

        internal override void MainTimerProcess()
        {
            FightTimecount++;

            if (FightTimecount == 1)
                SetProcessBar(bunPowerBar_3, 18, "入侵");

            if (FightTimecount == 19)
                SetProcessBar(bunPowerBar_3, 18, "入侵");

            if (FightTimecount == 37)
            {
                SetProcessBar(bunPowerBar_1, 23, "幻境");
                SetProcessBar(bunPowerBar_2, 14, "鎖鏈");
                SetProcessBar(bunPowerBar_3, 19, "入侵");
            }

            if (FightTimecount == 56)
                SetProcessBar(bunPowerBar_3, 19, "入侵");

            if (FightTimecount == 75)
            {
                SetProcessBar(bunPowerBar_2, 23, "血球");
                SetProcessBar(bunPowerBar_3, 19, "入侵");
            }

            if (FightTimecount == 94)
            {
                SetProcessBar(bunPowerBar_1, 17, "鎖鏈");
              
                SetProcessBar(bunPowerBar_3, 26, "入侵");
            }

            if (FightTimecount == 98)
                SetProcessBar(bunPowerBar_2, 22, "幻境");
            if (FightTimecount == 120)
                SetProcessBar(bunPowerBar_3, 19, "入侵");

            if (FightTimecount == 139)
            {
                SetProcessBar(bunPowerBar_2, 25, "鎖鏈");
                SetProcessBar(bunPowerBar_3, 18, "入侵");
            }
            if (FightTimecount == 157)
                SetProcessBar(bunPowerBar_3, 19, "入侵");
 
            if (FightTimecount == 164)
                SetProcessBar(bunPowerBar_2, 15, "幻境");

            if (FightTimecount == 176)
                SetProcessBar(bunPowerBar_3, 18, "入侵");

            if (FightTimecount == 179)
                SetProcessBar(bunPowerBar_2, 32, "血球");


        }
    }
}
