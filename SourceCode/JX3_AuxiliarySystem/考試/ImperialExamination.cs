using System;
using System.Drawing;
using System.Windows.Forms;
using JX3_AuxiliarySystem.CaptureArea;
using JX3_AuxiliarySystem.ImageLearnSystem;

namespace JX3_AuxiliarySystem.考試 {
    public partial class ImperialExamination : Form {
        public ScreenCapture PictureCapture = new ScreenCapture ();
        public DatabaseSystem DataSystem = new DatabaseSystem ();
        public ImageProcess ImageSystem = new ImageProcess ();

        public ImperialExamination () {
            InitializeComponent ();
        }

        private void ImperialExamination_Shown (object sender, EventArgs e) {
            DataSystem.DBSetPart (Application.StartupPath + "\\temp.mdb");
            DataSystem.DBOpen ();

            TimerIdentification.Start ();
        }

        private void TimerIdentification_Tick (object sender, EventArgs e) {
            int Zoon_X = 137;
            int Zoon_Y = 280;
            int Zoon_W = 615;
            int Zoon_H = 17;

            bool Fixed = false;

            // 設定拍下的區域和進行拍攝
            PictureCaptureSet (Zoon_X, Zoon_Y, Zoon_W, Zoon_H);
            Bitmap Source = (Bitmap) PictureCapture.CaptureScreen ();

            #region 修正Y軸位置和H高度，用於過濾雜訊
            int Fix_Y = 0;
            int Fix_H = 0;
            ImageSystem.Fix_High (Source, out Fix_Y, out Fix_H, '1', '0', 350, false);

            if (Fix_Y > 0 | Fix_H != 17) {
                Fixed = true;

                Zoon_Y = 280 + Fix_Y;
                Zoon_H = Fix_H;
            }
            #endregion

            #region 修正X軸位置和W寬度，用於過濾雜訊
            int Fix_X = 0;
            int Fix_W = 0;
            ImageSystem.Fix_Width (Source, out Fix_X, out Fix_W, '1', '0', 350, false);

            if (Fix_X > 0 | Fix_W != 615) {
                Fixed = true;

                Zoon_X = 137 + Fix_X;
                Zoon_W = Fix_W;
            }
            #endregion

            if (Fixed) {
                PictureCaptureSet (Zoon_X, Zoon_Y, Zoon_W, Zoon_H);
                Source = (Bitmap) PictureCapture.CaptureScreen ();
            }

            string Decode = ImageSystem.Decode_Orde (Source, true, '1', '0', 350, false);

            string Decode_StringCol = DataSystem.GetCode (Decode, "科舉");
            string Decode_Chinese = DataSystem.GetCode (Decode_StringCol, "題庫");

            lblAns.Text = Decode_Chinese;
            this.Size = lblAns.Size;
        }

        private void PictureCaptureSet (int Zoon_X, int Zoon_Y, int Width, int Height) {
            PictureCapture.Zoon_X = Zoon_X;
            PictureCapture.Zoon_Y = Zoon_Y;
            PictureCapture.Width = Width;
            PictureCapture.Height = Height;
        }

    }
}