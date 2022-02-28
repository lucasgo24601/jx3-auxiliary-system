using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FindJX3File {
    public class Program {
        static void Main (string[] args) {
            try {
                Process[] pJX3 = Process.GetProcessesByName ("JX3ClientX64");

                // 取得當前劍三的完整路徑
                string JX3Path = pJX3[0].MainModule.FileName;

                // 返回劍三的伺服器列表目錄
                JX3Path = JX3Path.Substring (0, JX3Path.IndexOf (@"bin\zhtw_hd\") + 12) + @"interface\LR_Plugin@DATA\LR_AccountStatistics\UsrData\TradeData\劍俠情緣叁";

                // 列舉當前伺服器列表
                string[] Files = Directory.GetDirectories (JX3Path);

                // 取得當前位置0的伺服器名稱
                string FileName = Files[0].Substring (Files[0].IndexOf (JX3Path) + JX3Path.Length + 1);

                // 列舉伺服器內位置0的角色
                Files = Directory.GetDirectories (JX3Path + "\\" + FileName);

                // 串接成: 伺服器_角色
                FileName += "_" + Files[0].Substring (Files[0].IndexOf (JX3Path + "\\" + FileName) + JX3Path.Length + "\\".Length + FileName.Length + 1);

                Directory.CreateDirectory (Application.StartupPath + "\\" + FileName);

                Application.Exit ();
            } catch {
                Application.Exit ();
            }
        }
    }
}