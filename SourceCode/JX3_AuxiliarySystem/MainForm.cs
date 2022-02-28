using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using JX3_AuxiliarySystem.CaptureArea;
using JX3_AuxiliarySystem.Hook;
using JX3_AuxiliarySystem.JX3;

namespace JX3_AuxiliarySystem {
    public partial class MainForm : Form {
        #region Value Config Set
        public string ConfigPath = Application.StartupPath + "\\JX3MainConfig.ini";

        public bool IsDebugMode = false;

        private string PhotoHotKey;
        private int CheckImageTime = 200;
        private Rectangle_Value HP = new Rectangle_Value ();
        private Rectangle_Value FightTime = new Rectangle_Value ();
        private Rectangle_Value Shout = new Rectangle_Value ();

        private struct Rectangle_Value {
            public int X;
            public int Y;
            public int Width;
            public int Height;
        }

        private void RefreshValue () {
            txtHP_X.Text = HP.X.ToString ();
            txtHP_Y.Text = HP.Y.ToString ();
            txtHP_High.Text = HP.Height.ToString ();
            txtHP_Width.Text = HP.Width.ToString ();

            txtTime_X.Text = FightTime.X.ToString ();
            txtTime_Y.Text = FightTime.Y.ToString ();
            txtTime_High.Text = FightTime.Height.ToString ();
            txtTime_Width.Text = FightTime.Width.ToString ();

            txtShout_X.Text = Shout.X.ToString ();
            txtShout_Y.Text = Shout.Y.ToString ();
            txtShout_High.Text = Shout.Height.ToString ();
            txtShout_Width.Text = Shout.Width.ToString ();
        }

        #endregion

        private Manger_KeyboardHook KeyHook = new Manger_KeyboardHook ();

        public MainForm () {
            InitializeComponent ();
        }

        private void MainForm_Load (object sender, EventArgs e) {
            if (File.Exists (ConfigPath)) {
                if (ReadValueFromConfig ("Main", "IsDebugMode") == "1") IsDebugMode = true;
                PhotoHotKey = ReadValueFromConfig ("Main", "PhotoLocationHotKey");
                int.TryParse (ReadValueFromConfig ("Main", "CheckImageTime"), out CheckImageTime);

                int.TryParse (ReadValueFromConfig ("HP", "Location_X"), out HP.X);
                int.TryParse (ReadValueFromConfig ("HP", "Location_Y"), out HP.Y);
                int.TryParse (ReadValueFromConfig ("HP", "Width"), out HP.Width);
                int.TryParse (ReadValueFromConfig ("HP", "High"), out HP.Height);

                int.TryParse (ReadValueFromConfig ("FightTime", "Location_X"), out FightTime.X);
                int.TryParse (ReadValueFromConfig ("FightTime", "Location_Y"), out FightTime.Y);
                int.TryParse (ReadValueFromConfig ("FightTime", "Width"), out FightTime.Width);
                int.TryParse (ReadValueFromConfig ("FightTime", "High"), out FightTime.Height);

                int.TryParse (ReadValueFromConfig ("Shout", "Location_X"), out Shout.X);
                int.TryParse (ReadValueFromConfig ("Shout", "Location_Y"), out Shout.Y);
                int.TryParse (ReadValueFromConfig ("Shout", "Width"), out Shout.Width);
                int.TryParse (ReadValueFromConfig ("Shout", "High"), out Shout.Height);

                btnCaptureArea.Text += " (" + PhotoHotKey + ")";
                RefreshValue ();
            }

            if (IsDebugMode) Trace.WriteLine ("[MainForm] " + "Mainform Start Now " + Environment.TickCount);
            KeyHook.KeyDown += KeyHook_KeyDown;
            KeyHook.Start ();
        }

        private void KeyHook_KeyDown (object sender, KeyboardEvent e) {
            if (e.KeyCode.ToString () == PhotoHotKey)
                btnCaptureArea_Click (this, null);
        }

        private void btnCaptureArea_Click (object sender, EventArgs e) {

            CaptureArea_Form Capture_Form = new CaptureArea_Form ();
            ScreenCapture temp = new ScreenCapture ();

            Image CapImage = temp.CaptureScreen ();
            Capture_Form.Size = CapImage.Size;
            Capture_Form.picCanvas.Size = CapImage.Size;
            Capture_Form.picCanvas.BackgroundImage = CapImage;

            KeyHook.Stop ();
            Capture_Form.ShowDialog ();
            KeyHook.Start ();

            #region 將更新的數據放置UI
            txtLocation_X.Text = Capture_Form.Object_Zoon_X.ToString ();
            txtLocation_Y.Text = Capture_Form.Object_Zoon_Y.ToString ();
            txtSize_Width.Text = Capture_Form.Object_Width.ToString ();
            txtSize_High.Text = Capture_Form.Object_Height.ToString ();
            #endregion
        }

        private void cboFBName_SelectedIndexChanged (object sender, EventArgs e) {
            cboBossName.Items.Clear ();
            switch (cboFBName.Text) {
                case "鍛刀":
                    cboBossName.Items.Add ("史朝英");
                    cboBossName.Items.Add ("柳愚");
                    cboBossName.Items.Add ("柳哲");
                    cboBossName.Items.Add ("柳時清");
                    cboBossName.Items.Add ("謝語");
                    break;
                case "千雷":
                    cboBossName.Items.Add ("伊瑪目");
                    cboBossName.Items.Add ("柳秀岳");
                    cboBossName.Items.Add ("柳鸞旗");
                    break;
                case "戰獸":
                    cboBossName.Items.Add ("報九楓");
                    cboBossName.Items.Add ("無支祁");
                    cboBossName.Items.Add ("也漠河");
                    cboBossName.Items.Add ("烏靈風");
                    cboBossName.Items.Add ("唐書雁");
                    break;
                case "燕然":
                    cboBossName.Items.Add ("司晴");
                    cboBossName.Items.Add ("李令霞");
                    cboBossName.Items.Add ("石斑");
                    break;
                case "輝天":
                    cboBossName.Items.Add ("烏夜啼");
                    cboBossName.Items.Add ("月華");
                    cboBossName.Items.Add ("鐵獄機關室");
                    cboBossName.Items.Add ("百慕玲與莊愈華");
                    cboBossName.Items.Add ("月泉准");
                    break;
                case "狼神":
                    cboBossName.Items.Add ("勒空明");
                    cboBossName.Items.Add ("烏索");
                    cboBossName.Items.Add ("史思明");
                    break;

                default:
                    cboBossName.Items.Add ("不支援");
                    break;
            }

            cboBossName.SelectedIndex = 0;
        }

        private void btnStartFB_Click (object sender, EventArgs e) {
            if (IsDebugMode) {
                timerCursorPos.Interval = 100;
                timerCursorPos.Start ();
                btnStartFB.Enabled = false;
            } else
                SelectJX3FB ();
        }

        private void timerCursorPos_Tick (object sender, EventArgs e) {
            POINTFX Location;
            GetCursorPos (out Location);

            if (Location.X.fract == 0) {
                timerCursorPos.Stop ();
                btnStartFB.Enabled = true;
                SelectJX3FB ();
            }
        }

        private void SelectJX3FB () {
            switch (cboBossName.Text) {
                #region 鍛刀
                case "史朝英":
                    ShowJX3FB (new JX3.鍛刀.史朝英());
                    break;
                case "柳愚":
                    ShowJX3FB (new JX3.鍛刀.柳愚());
                    break;
                case "柳哲":
                    ShowJX3FB (new JX3.鍛刀.柳哲());
                    break;
                case "柳時清":
                    ShowJX3FB (new JX3.鍛刀.柳時清());
                    break;
                case "謝語":
                    if (osTenFB.Value)
                        ShowJX3FB (new JX3.鍛刀.謝語());
                    else
                        ShowJX3FB (new JX3.鍛刀.謝語_25 ());
                    break;
                    #endregion

                    #region 狼神
                case "勒空明":
                    ShowJX3FB (new JX3.狼神.勒空明());
                    break;
                case "烏索":
                    ShowJX3FB (new JX3.狼神.烏索());
                    break;
                case "史思明":
                    ShowJX3FB (new JX3.狼神.史思明());
                    break;
                    #endregion

                default:
                    ShowJX3FB (new JX3.Test.Test ());
                    break;
            }
        }

        private void ShowJX3FB (object sender) {
            GlobalForm temp = sender as GlobalForm;
            temp.IsDebugMode = IsDebugMode;

            temp.FightTime_X = Convert.ToInt32 (txtTime_X.Text);
            temp.FightTime_Y = Convert.ToInt32 (txtTime_Y.Text);
            temp.FightTime_High = Convert.ToInt32 (txtTime_High.Text);
            temp.FightTime_Width = Convert.ToInt32 (txtTime_Width.Text);

            temp.HP_X = Convert.ToInt32 (txtHP_X.Text);
            temp.HP_Y = Convert.ToInt32 (txtHP_Y.Text);
            temp.HP_High = Convert.ToInt32 (txtHP_High.Text);
            temp.HP_Width = Convert.ToInt32 (txtHP_Width.Text);

            temp.Shout_X = Convert.ToInt32 (txtShout_X.Text);
            temp.Shout_Y = Convert.ToInt32 (txtShout_Y.Text);
            temp.Shout_High = Convert.ToInt32 (txtShout_High.Text);
            temp.Shout_Width = Convert.ToInt32 (txtShout_Width.Text);

            KeyHook.Stop ();
            temp.ShowDialog ();
            KeyHook.Start ();
        }

        private void btnImageSystem_Click (object sender, EventArgs e) {
            ImageLearnSystem.ImageLearnSystem test = new ImageLearnSystem.ImageLearnSystem ();
            if (txtLocation_X.Text != "Null") {
                test.txtImage_X.Text = txtLocation_X.Text;
                test.txtImage_Y.Text = txtLocation_Y.Text;
                test.txtImage_W.Text = txtSize_Width.Text;
                test.txtImage_H.Text = txtSize_High.Text;
            }

            KeyHook.Stop ();
            test.ShowDialog ();
            KeyHook.Start ();

        }

        #region DLL Import API
        [DllImport ("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString (string section, string key, string val, string filePath);

        [DllImport ("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString (string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport ("user32.dll", EntryPoint = "GetForegroundWindow")]
        private static extern IntPtr GetForegroundWindow ();

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

        public string ReadValueFromConfig (string Section, string Key) {
            try {
                StringBuilder temp = new StringBuilder (255);
                int i = GetPrivateProfileString (Section, Key, "", temp, 255, ConfigPath);
                return temp.ToString ();
            } catch (Exception ex) {
                if (IsDebugMode) Trace.WriteLine ("[MainForm] " + "Config Error : " + ex.Message);
                return "";
            }
        }

        // 更改顯示的名字
        private void osTenFB_OnValueChange (object sender, EventArgs e) {
            if (osTenFB.Value == true)
                lblFBNumber.Text = "10人模式";
            else
                lblFBNumber.Text = "25人模式";
        }

        #region 拖曳功能
        private bool IsMouseDown = false;
        private Point MousePoint;
        private void PanelAll_MouseDown (object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                MousePoint = new Point (e.X, e.Y);
                IsMouseDown = true;
            }
        }
        private void PanelAll_MouseMove (object sender, MouseEventArgs e) {
            if (IsMouseDown)
                Location = new Point (Left + e.X - MousePoint.X, Top + e.Y - MousePoint.Y);
        }
        private void PanelAll_MouseUp (object sender, MouseEventArgs e) {
            IsMouseDown = false;
        }
        #endregion

        #region Picture Click
        private void picMinimized_Click (object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picClose_Click (object sender, EventArgs e) {
            this.Close ();
        }

        #endregion

        private void btnImperialExamination_Click (object sender, EventArgs e) {
            KeyHook.Stop ();
            new 考試.ImperialExamination ().Show ();
            KeyHook.Start ();
        }
    }
}