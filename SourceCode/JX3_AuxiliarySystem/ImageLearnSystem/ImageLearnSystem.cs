using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CG.Web.MegaApiClient;
using JX3_AuxiliarySystem.CaptureArea;

namespace JX3_AuxiliarySystem.ImageLearnSystem {
    public partial class ImageLearnSystem : Form {
        #region 宣告區
        public bool IsDebugMode = false;

        private ScreenCapture PictureCapture = new ScreenCapture ();
        private DatabaseSystem MainDB = new DatabaseSystem ();
        private ImageProcess ImageSystem = new ImageProcess ();
        private System.Windows.Forms.Timer Capture_Timer = new System.Windows.Forms.Timer ();

        private List<string> SingeCodes_String = new List<string> ();

        private bool Decode_IsGreater = true; // false
        private int Decode_KeyValue = 570; // 350

        private int NowDownloadCount = 0; // Count 當前下載的數量
        #endregion

        public ImageLearnSystem () {
            InitializeComponent ();
            CheckForIllegalCrossThreadCalls = false;

            MainDB.DBSetPart (Application.StartupPath + "\\temp.mdb");
            cboDatabase.SelectedIndex = 0; // 設定0為預選
        }

        private void btnCutImage_Click (object sender, EventArgs e) {
            Download_ProcessBar.Visible = false; // 讓時間條不顯示
            txtDownload_Message.Visible = false;

            #region 依照當前的設定去進行截圖
            int Zoon_X = Convert.ToInt32 (txtImage_X.Text);
            int Zoon_Y = Convert.ToInt32 (txtImage_Y.Text);
            int Zoon_H = Convert.ToInt32 (txtImage_H.Text);
            int Zoon_W = Convert.ToInt32 (txtImage_W.Text);

            PictureCapture.PictureCaptureSet (Zoon_X, Zoon_Y, Zoon_W, Zoon_H);
            picSourceImage.Image = PictureCapture.CaptureScreen ();

            if (IsDebugMode) Trace.WriteLine ("Capture ： X = " + Zoon_X + " Y = " + Zoon_Y + " W = " + Zoon_W + " H = " + Zoon_H);
            #endregion

            Bitmap Source_Map = (Bitmap) picSourceImage.Image;

            #region 如果是科舉的話進行判定修改
            if (IsTest (Source_Map)) {
                Decode_IsGreater = false;
                Decode_KeyValue = 350;
                cboDatabase.SelectedIndex = 2;
            } else {
                Decode_IsGreater = true;
                Decode_KeyValue = 570;
            }
            if (IsDebugMode) Trace.WriteLine ("Determine Value ： KeyValue = " + Decode_KeyValue + "IsGreater = " + Decode_IsGreater);
            #endregion

            // 解碼可視規格
            txtGraphical_All.Text = ImageSystem.Decode_Orde (Source_Map, true, '*', ' ', Decode_KeyValue, Decode_IsGreater);

            if (cboDatabase.SelectedIndex == 2)
                btnFixLocation_Click (null, null);

            btnDecode_Click (null, null);
        }

        private void btnFixLocation_Click (object sender, EventArgs e) {
            Download_ProcessBar.Visible = false;
            txtDownload_Message.Visible = false;

            Bitmap Source_Map = (Bitmap) picSourceImage.Image;
            bool Fixed = false; // 判斷是否有修正過位置軸

            int Zoon_X = Convert.ToInt32 (txtImage_X.Text);
            int Zoon_Y = Convert.ToInt32 (txtImage_Y.Text);
            int Zoon_H = Convert.ToInt32 (txtImage_H.Text);
            int Zoon_W = Convert.ToInt32 (txtImage_W.Text);

            #region 修正Y軸位置和H高度，用於過濾雜訊
            int Fix_Y = 0;
            int Fix_H = 0;
            ImageSystem.Fix_High (Source_Map, out Fix_Y, out Fix_H, '*', ' ', Decode_KeyValue, Decode_IsGreater);

            if (Fix_Y > 0 | Fix_H.ToString () != txtImage_H.Text) {
                if (IsDebugMode) Trace.WriteLine ("Fix ： Y = " + Fix_Y + " H = " + Fix_H);
                Fixed = true;
                if (cboDatabase.SelectedIndex == 2 | cboDatabase.SelectedIndex == 3) {
                    Zoon_Y = Convert.ToInt32 (txtImage_Y.Text) + Fix_Y;
                    Zoon_H = Fix_H;
                } else {
                    txtImage_Y.Text = (Convert.ToInt32 (txtImage_Y.Text) + Fix_Y).ToString ();
                    txtImage_H.Text = Fix_H.ToString ();
                }
            }
            #endregion

            #region 修正X軸位置和W寬度，用於過濾雜訊
            int Fix_X = 0;
            int Fix_W = 0;
            ImageSystem.Fix_Width (Source_Map, out Fix_X, out Fix_W, '*', ' ', Decode_KeyValue, Decode_IsGreater);

            if (Fix_X > 0 | Fix_W.ToString () != txtImage_W.Text) {
                if (IsDebugMode) Trace.WriteLine ("Fix ： X = " + Fix_X + " W = " + Fix_W);
                Fixed = true;
                if (cboDatabase.SelectedIndex == 2 | cboDatabase.SelectedIndex == 3) {
                    Zoon_X = Convert.ToInt32 (txtImage_X.Text) + Fix_X;
                    Zoon_W = Fix_W;
                } else {
                    txtImage_X.Text = (Convert.ToInt32 (txtImage_X.Text) + Fix_X).ToString ();
                    txtImage_W.Text = Fix_W.ToString ();
                }

            }
            #endregion

            if (Fixed) {
                #region 再進行一次數據更新
                if (cboDatabase.SelectedIndex == 2 | cboDatabase.SelectedIndex == 3)
                    PictureCapture.PictureCaptureSet (Zoon_X, Zoon_Y, Zoon_W, Zoon_H);
                else
                    PictureCapture.PictureCaptureSet (Convert.ToInt32 (txtImage_X.Text), Convert.ToInt32 (txtImage_Y.Text), Convert.ToInt32 (txtImage_W.Text), Convert.ToInt32 (txtImage_H.Text));
                picSourceImage.Image = PictureCapture.CaptureScreen ();
                Source_Map = (Bitmap) picSourceImage.Image;
                txtGraphical_All.Text = ImageSystem.Decode_Orde (Source_Map, true, '*', ' ', Decode_KeyValue, Decode_IsGreater);
                if (IsDebugMode) Trace.WriteLine ("Capture ： X = " + Zoon_X + " Y = " + Zoon_Y + " W = " + Zoon_W + " H = " + Zoon_H);
                #endregion
            }
        }

        private bool IsTest (Bitmap Source) {
            int Count = 0;

            for (int i = 0; i < Source.Size.Width; i++)
                for (int j = 0; j < Source.Height; j++) {
                    bool R = Source.GetPixel (i, j).R > 200 & Source.GetPixel (i, j).R < 220;
                    bool G = Source.GetPixel (i, j).G > 200 & Source.GetPixel (i, j).G < 220;
                    bool B = Source.GetPixel (i, j).B > 190 & Source.GetPixel (i, j).B < 210;
                    if (R & G & B)
                        if (++Count == 20)
                            return true;
                }

            return false;
        }

        private void btnDecode_Click (object sender, EventArgs e) {
            // Graphical
            MainDB.DBOpen ();
            Download_ProcessBar.Visible = false;
            txtDownload_Message.Visible = false;

            SingeCodes_String = new List<string> (); // 入庫用
            List<string> Chinese_String = new List<string> ();

            Bitmap Source_Map = (Bitmap) picSourceImage.Image;

            // 視覺化顯示單字元

            if (cboDatabase.SelectedIndex != 2 & cboDatabase.SelectedIndex != 3) {
                #region 進行切割
                SingeCodes_String = ImageSystem.SplitImage_Column (txtGraphical_All.Text, '*');

                if (IsDebugMode) Trace.WriteLine ("Codes Column = " + SingeCodes_String.Count);

                // 將圖形化解碼文字進行二值化
                for (int i = 0; i < SingeCodes_String.Count; i++)
                    SingeCodes_String[i] = SingeCodes_String[i].Replace ('*', '1').Replace (' ', '0');
                if (IsDebugMode) Trace.WriteLine ("DeCodes done = *->1 ");
                #endregion
            } else {
                if (IsDebugMode) Trace.WriteLine ("Test DeCodes done = *->1 ");
                // 將圖形化解碼文字進行二值化
                SingeCodes_String.Add (txtGraphical_All.Text.Replace ('*', '1').Replace (' ', '0'));
            }

            // 查詢資料庫進行單筆字元辨識
            for (int i = 0; i < SingeCodes_String.Count; i++) {
                Chinese_String.Add (MainDB.GetCode (SingeCodes_String[i], cboDatabase.Text));
                if (IsDebugMode) Trace.WriteLine ("Chinese Decode = " + Chinese_String[Chinese_String.Count - 1]);
            }

            try {

                // 刪除過多的文字方塊
                if (SingeCodes_String.Count < pnlInputMessage.Controls.Count)
                    for (int i = SingeCodes_String.Count; i < pnlInputMessage.Controls.Count; i++) {
                        if (IsDebugMode) Trace.WriteLine ("Delete TextBox number = " + i);

                        Control InputCtl = pnlInputMessage.Controls[pnlInputMessage.Controls.IndexOfKey ("InputMessage_") + i.ToString ()];
                        InputCtl.Dispose ();
                        pnlInputMessage.Controls.Remove (InputCtl);

                        Control OutputCtl = pnlOutMessage.Controls[pnlOutMessage.Controls.IndexOfKey ("OutMessage_") + i.ToString ()];
                        OutputCtl.Dispose ();
                        pnlOutMessage.Controls.Remove (OutputCtl);
                    }
            } catch {

            }

            // 將視覺化的字元顯示於Panel上的物件
            for (int i = SingeCodes_String.Count - 1; i >= 0; i--) {
                #region 設定顯示提示訊息 OutMessage_i
                TextBox OutMessage = new TextBox ();
                OutMessage.Name = "OutMessage_" + i.ToString ();
                OutMessage.Text = SingeCodes_String[i].Replace ('1', '*').Replace ('0', ' ');

                if (pnlOutMessage.Controls.IndexOfKey (OutMessage.Name) == -1) {
                    OutMessage.Dock = DockStyle.Left;
                    OutMessage.Font = new Font ("細明體", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (136)));
                    OutMessage.Multiline = true;
                    if (SingeCodes_String[i].Split ('\n') [0].Length > 200)
                        OutMessage.Size = new Size (SingeCodes_String[i].Split ('\n') [0].Length * 14, OutMessage.Size.Width);
                    else
                        OutMessage.Size = new Size (SingeCodes_String[i].Split ('\n') [0].Length * 9, OutMessage.Size.Width);
                    pnlOutMessage.Controls.Add (OutMessage);
                    if (IsDebugMode) Trace.WriteLine ("Create Out TextBox number = " + i + " Text = " + OutMessage.Text + " Size H = " + SingeCodes_String[i].Split ('\n') [0].Length);
                } else {
                    pnlOutMessage.Controls[pnlOutMessage.Controls.IndexOfKey (OutMessage.Name)].Text = SingeCodes_String[i].Replace ('1', '*').Replace ('0', ' ');
                    if (IsDebugMode) Trace.WriteLine ("Modify Out TextBox number = " + i + " Text = " + pnlOutMessage.Controls[pnlOutMessage.Controls.IndexOfKey (OutMessage.Name)].Text);
                }

                #endregion

                #region 設定輸入提示訊息 InputMessage_i
                TextBox InputMessage = new TextBox ();
                InputMessage.Name = "InputMessage_" + i.ToString ();
                InputMessage.Text = Chinese_String[i];

                if (pnlInputMessage.Controls.IndexOfKey (InputMessage.Name) == -1) {
                    InputMessage.TabIndex = i;
                    InputMessage.Dock = DockStyle.Left;
                    InputMessage.Font = new Font ("細明體", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte) (136)));
                    InputMessage.Multiline = true;
                    InputMessage.Size = new Size (SingeCodes_String[i].Split ('\n') [0].Length * 9, InputMessage.Size.Width);
                    pnlInputMessage.Controls.Add (InputMessage);
                    if (IsDebugMode) Trace.WriteLine ("Create Input TextBox number = " + i + " Text = " + InputMessage.Text);
                } else {
                    pnlInputMessage.Controls[pnlInputMessage.Controls.IndexOfKey (InputMessage.Name)].Text = Chinese_String[i];
                    if (IsDebugMode) Trace.WriteLine ("Modify Input TextBox number = " + i + " Text = " + pnlInputMessage.Controls[pnlInputMessage.Controls.IndexOfKey (InputMessage.Name)].Text);
                }

                #endregion
            }

            MainDB.DBClose ();
        }

        private void btnStorage_Click (object sender, EventArgs e) {
            string Sql = "";
            Download_ProcessBar.Visible = false;
            txtDownload_Message.Visible = false;

            for (int i = 0; i < pnlInputMessage.Controls.Count; i++)
                try {
                    TextBox temp_Number = (TextBox) pnlInputMessage.Controls[pnlInputMessage.Controls.IndexOfKey ("InputMessage_" + i.ToString ())];

                    if (string.IsNullOrEmpty (temp_Number.Text) | temp_Number.Text == "Null")
                        continue;

                    if (cboDatabase.SelectedIndex != 2) {
                        #region 撰寫SQL語法並傳送
                        switch (cboDatabase.Text) {
                            case "Timer":
                                Sql = string.Format ("insert into TimerCodes(文字,CodeValue) values('{0}','{1}')", temp_Number.Text, SingeCodes_String[i].TrimEnd ('\r'));
                                break;
                            case "HP":
                                Sql = string.Format ("insert into HPCodes(文字,CodeValue) values('{0}','{1}')", temp_Number.Text, SingeCodes_String[i].TrimEnd ('\r'));
                                break;
                        }
                        MainDB.SendCommand (Sql);
                        #endregion
                    } else {
                        #region 檢測使用者是否有正確依照格式輸入
                        if (temp_Number.Text.Contains ("：") == false) {
                            MessageBox.Show ("請輸入指定格式 = 題目：答案 \r\nex = 此程式系統傲血聯絡人為誰：西瓜居士");
                            continue;
                        }
                        while (temp_Number.Text.Count (p => p == '：') > 1) {
                            char[] temp_Array = temp_Number.Text.ToArray ();
                            temp_Array[temp_Number.Text.IndexOf ('：')] = ';';
                            temp_Number.Text = new string (temp_Array);
                        }
                        #endregion

                        if (temp_Number.Text.Contains ("：") == false)
                            MessageBox.Show ("Lucas : " + temp_Number.Text);

                        #region 獲取題目的內容
                        string Q = temp_Number.Text;
                        if (temp_Number.Text.Contains ("："))
                            Q = temp_Number.Text.Substring (0, temp_Number.Text.IndexOf ("："));
                        #endregion
                        #region 撰寫SQL語法並傳送
                        Sql = string.Format ("insert into 科舉中文(文字,CodeValue) values('{0}','{1}')", Q, SingeCodes_String[i].TrimEnd ('\r'));
                        if (IsDebugMode) Trace.WriteLine ("Sql = " + Sql.Substring (0, Sql.IndexOf (",'")));
                        MainDB.SendCommand (Sql);
                        #endregion

                        Sql = "";

                        #region 獲取答案的內容
                        string A = temp_Number.Text;
                        if (temp_Number.Text.Contains ("："))
                            A = temp_Number.Text.Substring (temp_Number.Text.IndexOf ("：") + "：".Length);
                        #endregion
                        #region 撰寫SQL語法並傳送
                        Sql = string.Format ("insert into 科舉題目(答案,題目) values('{0}','{1}')", A, Q);
                        if (IsDebugMode) Trace.WriteLine ("Sql = " + Sql);
                        MainDB.SendCommand (Sql);
                        #endregion
                    }
                }
            catch (Exception ex) {
                if (IsDebugMode) Trace.WriteLine ("btnStorage Error = " + ex.Message);
            }

            MessageBox.Show ("Done");
        }

        private void btnSynchronize_Click (object sender, EventArgs e) {
            IsDebugMode = true;
            Download_ProcessBar.Visible = true;
            txtDownload_Message.Visible = true;
            NowDownloadCount = 0;

            Thread ProcessSyn = new Thread (() => {
                string JX3Name = Environment.TickCount.ToString ();
                UpData ("正在獲取名稱..", 0);
                #region 獲取劍三名稱
                Process P = new Process ();

                P.StartInfo.FileName = Application.StartupPath + "\\FindJX3File.exe";
                P.StartInfo.CreateNoWindow = true;
                P.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                P.Start ();
                P.WaitForExit ();

                string[] temp = Directory.GetDirectories (Application.StartupPath);
                if (temp.Length == 0) {
                    Directory.CreateDirectory (Application.StartupPath + "\\使用者" + Environment.TickCount);
                    temp = Directory.GetDirectories (Application.StartupPath);
                }
                JX3Name = temp[0].Substring (temp[0].IndexOf (Application.StartupPath) + Application.StartupPath.Length + 1);

                #endregion
                UpData ("刪除本地資料..", 1);
                #region 刪除本地資料
                List<string> Files_Path = new List<string> (Directory.GetFiles (Application.StartupPath + "\\" + JX3Name + "\\"));
                for (int i = 0; i < Files_Path.Count; i++) {
                    File.Delete (Files_Path[i]);
                    UpData ("刪除本地資料..(" + i + "/" + Files_Path.Count, 1);
                }

                #endregion
                UpData ("連線MEGA..", 2);
                #region 設定MEGA 屬性
                MegaApiClient client = new MegaApiClient ();

                // 連線MEGA資料夾
                client.Login ("你的帳號", "你的密碼");

                // 列舉資料夾內的所有物件
                var nodes = client.GetNodes ();

                //選擇所存放在MEGA的哪個資料夾
                INode myFolder = nodes.FirstOrDefault (n => n.Type == NodeType.Directory && n.Name == "JX3_Database");
                #endregion
                UpData ("刪除雲端已存在檔案..", 3);
                #region 刪除雲端自身已存在的檔案
                var NextNodes = client.GetNodes (myFolder);
                INode del = NextNodes.FirstOrDefault (n => n.Type == NodeType.File && n.Name == JX3Name + ".mdb");
                if (del != null)
                    client.Delete (del, true);
                #endregion
                UpData ("上傳自己的檔案.." + JX3Name + ".mdb", 4);
                #region 上傳自身的檔案
                // 將上傳檔案轉換成資料流
                Stream FileLine = new FileStream (Application.StartupPath + "\\temp.mdb", FileMode.Open, FileAccess.Read);

                client.Upload (FileLine, JX3Name + ".mdb", myFolder);
                #endregion
                UpData ("下載他人檔案..", 5);
                #region 下載檔案
                var downloadfile = client.GetNodes (myFolder);
                IEnumerable<INode> root = downloadfile.Where (w => w.Type == NodeType.File & w.Name != JX3Name + ".mdb");
                Progress<double> DownloadeCount;

                foreach (var t in root.ToList ()) {
                    DownloadeCount = new Progress<double> (p => DownloadMEGAEven (p, root.ToList ().Count, t.Name, JX3Name));
                    client.DownloadFileAsync (t, Application.StartupPath + "\\" + JX3Name + "\\" + t.Name, DownloadeCount);
                }
                #endregion

            });

            ProcessSyn.IsBackground = true;
            ProcessSyn.Start ();
        }

        private void UpData (string text, int key) {
            txtGraphical_All.Text = "";

            txtDownload_Message.Text = text;

            Download_ProcessBar.Value = key;
        }

        private void DownloadMEGAEven (double ProgressValue, int FileCount, string NowDownName, string JX3Name) {
            if (IsDebugMode) Trace.WriteLine ("Now Download file = " + (NowDownloadCount + 1) + " " + ProgressValue + "% Name = " + NowDownName);
            string Message = string.Format ("下載： {0} = {1}.. ({2}/{3})", NowDownName, ProgressValue.ToString ().Substring (0, 3).Trim ('.') + "%", NowDownloadCount, FileCount);
            UpData (Message, 6);
            if (ProgressValue != 100)
                return;

            if (++NowDownloadCount != FileCount)
                return;

            UpData ("檢查檔案中", 6);
            // 凡是進行到此處即代表當前已完成單項MEGA的下載
            if (IsDebugMode) Trace.WriteLine ("Wait 5 Sec");
            Timeout_Sleep (50); // 暫停5秒，目的為等待MEGA Download API 系統順利關閉並離開剛下載的資料庫

            #region 更新數據庫
            int count = 0;
            List<string> Files_Path = new List<string> (Directory.GetFiles (Application.StartupPath + "\\" + "傲血戰意_凌捷" + "\\"));
            foreach (var File_Path in Files_Path) {
                if (File_Path.Contains (".ldb"))
                    continue;

                NowDownName = File_Path.Substring (File_Path.IndexOf ("\\" + JX3Name) + JX3Name.Length + 2);

                if (IsDebugMode) Trace.WriteLine ("Open Second Database = " + File_Path);

                #region 宣告副資料庫並打開所有資料庫
                DatabaseSystem SecondDBSystem = new DatabaseSystem ();
                SecondDBSystem.DBSetPart (File_Path);
                #endregion

                #region 獲取副資料庫的所有科舉中文
                DataTable SecondDBTable = new DataTable ();
                SecondDBTable = SecondDBSystem.SendCommand ("select 文字,CodeValue from 科舉中文").Tables[0];
                #endregion

                Trace.WriteLine ("----------------Main Start");
                #region 將副資料庫的科舉中文寫入主資料庫
                for (int i = 0; i < SecondDBTable.Rows.Count; i++)
                    try {
                        Message = string.Format ("更新數據 科舉中文： {0} = {1}/{2}..   ({3}/{4})", NowDownName, i, SecondDBTable.Rows.Count, count, FileCount);
                        UpData (Message, 7);
                        #region 進行Count將要寫入的副資料庫的Data是否已存在於主資料庫
                        DataTable MainDBTable = new DataTable ();
                        string sql = string.Format ("select 文字 from 科舉中文 where CodeValue = '{0}'", SecondDBTable.Rows[i][1]);
                        MainDBTable = MainDB.SendCommand (sql).Tables[0];
                        #endregion

                        #region 如果沒有重複(Count為0)的話，進行寫入
                        if (MainDBTable.Rows.Count == 0) {
                            sql = string.Format ("insert into 科舉中文(文字,CodeValue) values('{0}','{1}')", SecondDBTable.Rows[i][0], SecondDBTable.Rows[i][1]);
                            MainDB.SendCommand (sql);
                        }
                        #endregion
                    }
                catch (Exception ex) {
                    Trace.WriteLine (ex.Message);
                }
                #endregion
                Trace.WriteLine ("----------------Main End");

                SecondDBTable = SecondDBSystem.SendCommand ("select 答案,題目 from 科舉題目").Tables[0];
                Trace.WriteLine ("----------------Second Start");
                #region 將副資料庫的科舉題目寫入主資料庫
                for (int i = 0; i < SecondDBTable.Rows.Count; i++)
                    try {
                        Message = string.Format ("更新數據 科舉題庫： {0} = {1}/{2}..   ({3}/{4})", NowDownName, i, SecondDBTable.Rows.Count, count, FileCount);
                        UpData (Message, 7);
                        #region 進行Count將要寫入的副資料庫的Data是否已存在於主資料庫
                        DataTable MainDBTable = new DataTable ();
                        string sql = string.Format ("select 答案 from 科舉題目 where 題目 = '{0}'", SecondDBTable.Rows[i][1]);
                        MainDBTable = MainDB.SendCommand (sql).Tables[0];
                        #endregion

                        if (MainDBTable.Rows.Count == 0) {
                            sql = string.Format ("insert into 科舉題目(答案,題目) values('{0}','{1}')", SecondDBTable.Rows[i][0], SecondDBTable.Rows[i][1]);
                            MainDB.SendCommand (sql);
                        }
                    }
                catch (Exception ex) {
                    Trace.WriteLine (ex.Message);
                }
                #endregion
                Trace.WriteLine ("----------------Second End");

                #region 關閉所有的資料庫
                SecondDBSystem.DBClose ();
                MainDB.DBClose ();
                #endregion
                count++;
            }
            #endregion
            UpData ("完成", 8);
        }

        #region Panel Scroll Bar 移動同步
        private void Panel_Scroll (object sender, ScrollEventArgs e) {
            Panel temp = sender as Panel;
            pnlOutMessage.AutoScrollPosition = new Point (e.NewValue, pnlOutMessage.AutoScrollPosition.Y);
            pnlInputMessage.AutoScrollPosition = new Point (e.NewValue, pnlInputMessage.AutoScrollPosition.Y);
        }

        private void TimerPanelScroll_Tick (object sender, EventArgs e) {
            if (pnlInputMessage.AutoScrollPosition.X < 0)
                pnlOutMessage.AutoScrollPosition = new Point (Math.Abs (pnlInputMessage.AutoScrollPosition.X), pnlInputMessage.AutoScrollPosition.Y);
            else
                pnlOutMessage.AutoScrollPosition = new Point (pnlInputMessage.AutoScrollPosition.X, pnlInputMessage.AutoScrollPosition.Y);

        }
        #endregion

        #region Timeout 
        private int TimerCount = 0;
        internal void Timeout_Sleep (int count) {
            TimerCount = count + 1;
            AutoResetEvent AutoResetEvent = new AutoResetEvent (false); //宣告一個執行續之間發送信號的物件
            TimerCallback TimerCallback = CheckStatus; //timer執行的函數委派
            System.Threading.Timer Timer = new System.Threading.Timer (TimerCallback, AutoResetEvent, 0, 100); //延遲0.5秒後開始每一秒觸發
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