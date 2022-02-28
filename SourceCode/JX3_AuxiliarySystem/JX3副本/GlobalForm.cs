using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using JX3_AuxiliarySystem.CaptureArea;
using JX3_AuxiliarySystem.ImageLearnSystem;

namespace JX3_AuxiliarySystem.JX3 {
    public partial class GlobalForm : Form {
        #region 宣告區
        public bool IsDebugMode = false;
        internal System.Threading.Timer ThreadTimer_1;
        internal System.Threading.Timer ThreadTimer_2;
        internal System.Threading.Timer ThreadTimer_3;
        internal int FightTimecount = 0;
        internal string Ans = "";
        internal bool BossTemp = false;

        internal struct CountPowerBar {
            public BunifuProgressBar Bar;
            public Label Name;
            public Label CountSec;
            public Panel DisplayPanle;
        }
        internal bool AllPanelVisible {
            get {
                if (PanelSkill_1.Visible == true |
                    PanelSkill_2.Visible == true |
                    PanelSkill_3.Visible == true)
                    return true;
                return false;
            }
        }

        internal ScreenCapture PictureCapture = new ScreenCapture ();
        internal DatabaseSystem data = new DatabaseSystem ();
        internal ImageProcess ImageSystem = new ImageProcess ();

        public int FightTime_X;
        public int FightTime_Y;
        public int FightTime_High;
        public int FightTime_Width;

        public int HP_X;
        public int HP_Y;
        public int HP_High;
        public int HP_Width;

        public int Shout_X;
        public int Shout_Y;
        public int Shout_High;
        public int Shout_Width;

        #endregion

        public GlobalForm () {
            InitializeComponent ();
            CheckForIllegalCrossThreadCalls = false;
        }

        internal void GlobalForm_Shown (object sender, EventArgs e) {
            if (IsDebugMode) {
                TimerMainCount_Tick (null, null);
                TimerMainCount.Start ();
            } else {
                this.Size = new Size (330, 151);
                TimerStartFight.Start ();
            }
        }

        #region 時間軸 Timer
        internal void TimerStartFight_Tick (object sender, EventArgs e) {
            StartFightProcess ();
        }
        internal void StartFightProcess () {
            Trace.WriteLine (FightTime_X + "--" + FightTime_Y + "*--" + FightTime_Width + "--" + FightTime_High);
            CaptureTimerSet (FightTime_X, FightTime_Y, FightTime_Width, FightTime_High); // 偵測戰鬥開始的位置

            if (Convert.ToInt32 (ImageToString ("Timer")) == 0) {
                TimerStartFight.Stop ();
                TimerMainCount_Tick (null, null);
                TimerMainCount.Start ();
            }
        }

        internal void TimerMainCount_Tick (object sender, EventArgs e) {
            MainTimerProcess ();
        }
        internal virtual void MainTimerProcess () {
            // 空函數，等待繼承者重載覆寫
        }

        internal void TimerSupCount_Tick (object sender, EventArgs e) {
            SupTimerProcess ();
        }
        internal virtual void SupTimerProcess () {
            // 空函數，等待繼承者重載覆寫
        }

        internal void TimerHPCount_Tick (object sender, EventArgs e) {
            HPTimerProcess ();
        }
        internal virtual void HPTimerProcess () {
            // CaptureTimerSet(1638,909,40,21);
            // ImageToString("HPCodes");
            // 上述為基本示範，獲取HP後要如何運用則看使用者操作
            // 空函數，等待繼承者重載覆寫
        }

        internal void TimerShout_Tick (object sender, EventArgs e) {
            TimerShoutProcess ();
        }
        internal virtual void TimerShoutProcess () {
            // CaptureTimerSet(1638,909,21,40);
            // ImageToString("HPCodes");
            // 上述為基本示範，獲取HP後要如何運用則看使用者操作
            // 空函數，等待繼承者重載覆寫
        }

        #endregion

        #region 圖片擷取和解析
        internal void CaptureTimerSet (int x, int y, int w, int h) {
            data.DBSetPart (Application.StartupPath + "\\temp.mdb");
            data.DBOpen ();

            PictureCapture.Zoon_X = x;
            PictureCapture.Zoon_Y = y;
            PictureCapture.Width = w;
            PictureCapture.Height = h;
        }
        internal string ImageToString (string table) {

            Bitmap Source_Map = (Bitmap) PictureCapture.CaptureScreen (); // 拍攝後的圖形
            List<string> SingeCodes_String = new List<string> (); // 存放解析後的圖形文字
            List<string> Chinese_String = new List<string> (); // 存放查詢後的文字
            Stack<string> Ans_Stack = new Stack<string> (); // 存放結果用

            // 分析圖形
            string Graphical_All = ImageSystem.Decode_Orde (Source_Map, true, '1', '0', 570, true);

            // 判斷是否要分割圖形文字
            if (table != "喊話")
                SingeCodes_String = ImageSystem.SplitImage_Column (Graphical_All, '1');
            else
                SingeCodes_String.Add (Graphical_All);

            // 查詢資料庫進行單筆字元辨識
            for (int i = 0; i < SingeCodes_String.Count; i++)
                Chinese_String.Add (data.GetCode (SingeCodes_String[i], table));

            #region 將文字轉換成字串，並過濾有意義資料
            bool IsPercent = false;
            Ans_Stack.Push ("0");

            if (table == "HP") {
                #region 將(100%  -> 100  
                for (int i = Chinese_String.Count - 1; i >= 0; i--)
                    if (IsPercent) {
                        if (Chinese_String[i] == "Null" | Chinese_String[i] == "(")
                            IsPercent = false;
                        else
                            Ans_Stack.Push (Chinese_String[i]);
                    }
                else if (Chinese_String[i] == "24601" | Chinese_String[i] == "%")
                    IsPercent = true;
                #endregion
            } else if (table == "Timer") {
                int Min = 24601;
                int Sec = 24601;
                for (int i = Chinese_String.Count - 1; i >= 0; i--)
                    if (Chinese_String[i] == "24601" | Chinese_String[i] == ":") {
                        IsPercent = true;
                    }
                else if (IsPercent == false & Chinese_String[i] != "Null") {
                    if (Sec == 24601)
                        Sec = Convert.ToInt32 (Chinese_String[i]);
                    else
                        Sec += Convert.ToInt32 (Chinese_String[i]) * 10;

                    Trace.WriteLine ("Sec" + Sec + "--" + Chinese_String[i]);
                } else if (IsPercent == true & Chinese_String[i] != "Null") {
                    if (Min == 24601)
                        Min = Convert.ToInt32 (Chinese_String[i]);
                    else
                        Min += Convert.ToInt32 (Chinese_String[i]) * 10;
                    Trace.WriteLine ("Min" + Min + "--" + Chinese_String[i]);
                }

                Ans_Stack.Push (((Min * 60) + Sec).ToString ());
            } else
                Ans_Stack.Push (Chinese_String[Chinese_String.Count - 1]);

            #endregion

            Ans = "";
            for (int i = 0; i < Ans_Stack.Count + 1; i++)
                Ans += Ans_Stack.Pop ();

            return Ans;
        }
        #endregion

        #region PowerProcessBar Timer 
        internal void SetProcessBar (BunifuProgressBar Bar, int time, string SkilName) {
            CountPowerBar StrcutCountBar = new CountPowerBar ();
            StrcutCountBar.Bar = Bar;
            Bar.MaximumValue = time;
            Bar.Value = time;
            switch (Bar.Name) {
                case "bunPowerBar_1":
                    PanelSkill_1.Visible = true;
                    StrcutCountBar.Name = lblSkillName_1;
                    StrcutCountBar.Name.Text = SkilName;
                    StrcutCountBar.CountSec = lblSkillCount_1;
                    StrcutCountBar.DisplayPanle = PanelSkill_1;
                    if (ThreadTimer_1 != null)
                        ThreadTimer_1.Dispose ();
                    ThreadTimer_1 = new System.Threading.Timer (new TimerCallback (TimerSkill_1_Tick), StrcutCountBar, 0, 1000);
                    break;
                case "bunPowerBar_2":
                    PanelSkill_2.Visible = true;
                    StrcutCountBar.Name = lblSkillName_2;
                    StrcutCountBar.Name.Text = SkilName;
                    StrcutCountBar.CountSec = lblSkillCount_2;
                    StrcutCountBar.DisplayPanle = PanelSkill_2;
                    if (ThreadTimer_2 != null)
                        ThreadTimer_2.Dispose ();
                    ThreadTimer_2 = new System.Threading.Timer (new TimerCallback (TimerSkill_2_Tick), StrcutCountBar, 0, 1000);
                    break;
                case "bunPowerBar_3":
                    PanelSkill_3.Visible = true;
                    StrcutCountBar.Name = lblSkillName_3;
                    StrcutCountBar.Name.Text = SkilName;
                    StrcutCountBar.CountSec = lblSkillCount_3;
                    StrcutCountBar.DisplayPanle = PanelSkill_3;
                    if (ThreadTimer_3 != null)
                        ThreadTimer_3.Dispose ();
                    ThreadTimer_3 = new System.Threading.Timer (new TimerCallback (TimerSkill_3_Tick), StrcutCountBar, 0, 1000);
                    break;
            }
            // Threading.Timer(CallBack 函數,CallBack PassObject,延遲幾秒開始,每幾秒執行一次)

        }
        internal void TimerSkill_1_Tick (object sender) {
            try {
                CountPowerBar StrcutCountBar = (CountPowerBar) sender;
                StrcutCountBar.Bar.Value--;
                StrcutCountBar.CountSec.Text = StrcutCountBar.Bar.Value + " S";

                if (StrcutCountBar.Bar.Value == 0) {
                    ThreadTimer_1.Dispose ();
                    StrcutCountBar.DisplayPanle.Visible = false;
                }
            } catch {

            }
        }
        internal void TimerSkill_2_Tick (object sender) {
            try {
                CountPowerBar StrcutCountBar = (CountPowerBar) sender;
                StrcutCountBar.Bar.Value--;
                StrcutCountBar.CountSec.Text = StrcutCountBar.Bar.Value + " S";

                if (StrcutCountBar.Bar.Value == 0) {
                    ThreadTimer_2.Dispose ();
                    StrcutCountBar.DisplayPanle.Visible = false;
                }
            } catch {

            }
        }
        internal void TimerSkill_3_Tick (object sender) {
            try {
                CountPowerBar StrcutCountBar = (CountPowerBar) sender;
                StrcutCountBar.Bar.Value--;
                StrcutCountBar.CountSec.Text = StrcutCountBar.Bar.Value + " S";

                if (StrcutCountBar.Bar.Value == 0) {
                    ThreadTimer_3.Dispose ();
                    StrcutCountBar.DisplayPanle.Visible = false;
                }
            } catch {

            }
        }
        #endregion

        #region Button Click 
        internal void btnFast_Click (object sender, EventArgs e) {
            MainTimerProcess ();
            PowerBar_AddSub (-1);

        }
        internal void btnStartStop_Click (object sender, EventArgs e) {
            if (btnStartStop.Text == "口") {
                TimerMainCount.Stop ();
                ThreadTimer_StopStart ("Stop");
                btnStartStop.Text = "O";
            } else {
                TimerMainCount.Start ();
                ThreadTimer_StopStart ("Start");
                btnStartStop.Text = "口";
            }
        }
        internal void btnRewind_Click (object sender, EventArgs e) {
            FightTimecount--;
            PowerBar_AddSub (+1);
        }

        internal void btnRe_Click (object sender, EventArgs e) {
            FightTimecount = 0;
            BossTemp = false;
        }
        internal void btnExist_Click (object sender, EventArgs e) {
            this.Close ();
        }

        internal void PowerBar_AddSub (int key) {
            if (PanelSkill_1.Visible == true & bunPowerBar_1.Value < bunPowerBar_1.MaximumValue & bunPowerBar_1.Value > 0)
                bunPowerBar_1.Value += key;
            if (PanelSkill_2.Visible == true & bunPowerBar_2.Value < bunPowerBar_2.MaximumValue & bunPowerBar_2.Value > 0)
                bunPowerBar_2.Value += key;
            if (PanelSkill_3.Visible == true & bunPowerBar_3.Value < bunPowerBar_3.MaximumValue & bunPowerBar_3.Value > 0)
                bunPowerBar_3.Value += key;
        }
        internal void ThreadTimer_StopStart (string key) {
            if (key == "Stop") {
                if (PanelSkill_1.Visible == true)
                    ThreadTimer_1.Change (-1, 0);
                if (PanelSkill_2.Visible == true)
                    ThreadTimer_2.Change (-1, 0);
                if (PanelSkill_3.Visible == true)
                    ThreadTimer_3.Change (-1, 0);
            } else {
                if (PanelSkill_1.Visible == true)
                    ThreadTimer_1.Change (1, 1000);
                if (PanelSkill_2.Visible == true)
                    ThreadTimer_2.Change (1, 1000);
                if (PanelSkill_3.Visible == true)
                    ThreadTimer_3.Change (1, 1000);
            }

        }

        #endregion   

        #region GetCursorPos API 
        [DllImport ("user32.dll", SetLastError = true)]
        [
            return :MarshalAs (UnmanagedType.Bool)
        ]
        public static extern bool GetCursorPos (out POINTFX lpPoint);

        public struct POINTFX {
            public FIXED X;
            public FIXED Y;
        }

        public struct FIXED {
            public short fract;
            public short value;
        }

        #endregion

        #region Timeout 
        int TimerCount = 0;
        internal void Timeout_Sleep (int count) {
            TimerCount = count + 1;
            AutoResetEvent AutoResetEvent = new AutoResetEvent (false); //宣告一個執行續之間發送信號的物件
            TimerCallback TimerCallback = CheckStatus; //timer執行的函數委派
            System.Threading.Timer Timer = new System.Threading.Timer (TimerCallback, AutoResetEvent, 0, 1000); //延遲0.5秒後開始每一秒觸發
            AutoResetEvent.WaitOne (); //hold住目前主執行緒，直到副執行緒(Timer)委派的事件(CheckStatus)同意(AutoResetEvent.Set();)主執行緒才可以行動
            Timer.Dispose (); //取消副執行續timer動作
        }

        public void CheckStatus (Object stateInfo) {
            AutoResetEvent autoEvent = (AutoResetEvent) stateInfo; //autoEvent物件用於傳送訊息給主執行續((AutoResetEvent)stateInfo)
            if (--TimerCount == 0)
                autoEvent.Set (); //執行WaitOne執行緒(讓等候的WaitOne執行緒繼續執行)
        }

        #endregion
    }
}