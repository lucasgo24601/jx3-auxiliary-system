using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace DisplayMessage
{
    public partial class MainWindow : Window
    {
        private AnnounceWindow MessageShow = new AnnounceWindow();  // 輸出訊息的物件
        private Timer MessageColseTimer = new Timer();              // 偵測外部輸入指令文件
   
        public MainWindow()
        {
            InitializeComponent();

            this.Hide();

            MessageColseTimer.Interval = 100;
            MessageColseTimer.Tick += MessageColseTimer_Tick;
            MessageColseTimer.Start();
        }

        private void MessageColseTimer_Tick(object sender, EventArgs e)
        {
            string[] MessageCMDLine=null;
            if (CheckFile(ref MessageCMDLine) == true)
            {
                string[] temp = MessageCMDLine[0].Split(',');
                if(temp.Length>2)
                {
                    MessageColseTimer.Interval = Convert.ToInt32(temp[1]);
                    MessageShow.time = MessageColseTimer.Interval;
                    MessageShow.OutputMessage(temp[2], temp[0]);
                    string WriteText = "";
                    for (int i = 1; i < MessageCMDLine.Length; i++)
                        WriteText += MessageCMDLine[i] + '\n';

                    if (WriteText.Length > 2)
                        File.WriteAllText(@".\JX3Message.txt", WriteText);
                    else
                        File.Delete(@".\JX3Message.txt");
                }
                else
                    File.Delete(@".\JX3Message.txt");
            }
            else
                MessageColseTimer.Interval = 100;
        }

        private bool CheckFile(ref string[] MessageCMDLine)
        {
            if(File.Exists(@".\JX3Message.txt"))
            {
                string MessageCMD = File.ReadAllText(@".\JX3Message.txt");
                MessageCMDLine = MessageCMD.Split('\n');
                return true;
            }
            return false;
        }
    }
}
