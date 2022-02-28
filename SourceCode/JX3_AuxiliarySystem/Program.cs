using System;
using System.Windows.Forms;

namespace JX3_AuxiliarySystem {
    static class Program {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        public static MainForm MainForm_Object;

        [STAThread]
        static void Main () {
            Application.EnableVisualStyles ();
            Application.SetCompatibleTextRenderingDefault (false);
            MainForm_Object = new MainForm ();
            Application.Run (MainForm_Object);
        }
    }
}