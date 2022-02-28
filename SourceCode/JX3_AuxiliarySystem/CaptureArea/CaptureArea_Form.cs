using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace JX3_AuxiliarySystem.CaptureArea {
    public partial class CaptureArea_Form : Form {
        private List<Point> DrawingPoints = new List<Point> (); // 紀錄滑鼠軌跡的陣列。
        private Pen pen = new Pen (Color.Red, 2);
        private Timer CheckImage = new Timer ();
        private bool IsMouseDown = false;
        private Graphics DrawingArea;
        private Image PanImage;
        private Point _MouseDown;

        #region 回傳子
        public int Object_Width {
            get {
                if (DrawingPoints.Count > 0)
                    return DrawingPoints[DrawingPoints.Count - 1].X - _MouseDown.X;

                return 0;
            }
        }
        public int Object_Height {
            get {
                if (DrawingPoints.Count > 0)
                    return DrawingPoints[DrawingPoints.Count - 1].Y - _MouseDown.Y;

                return 0;
            }
        }
        public int Object_Zoon_X {
            get {
                if (DrawingPoints.Count > 0)
                    return _MouseDown.X;

                return 0;
            }
        }
        public int Object_Zoon_Y {
            get {
                if (DrawingPoints.Count > 0)
                    return _MouseDown.Y;

                return 0;
            }
        }
        #endregion

        public CaptureArea_Form () {
            InitializeComponent ();
        }
        private void CaptureArea_Form_Shown (object sender, EventArgs e) {
            DrawingArea = picCanvas.CreateGraphics (); // 取得繪圖區物件
            PanImage = picCanvas.BackgroundImage;

            CheckImage.Interval = 200;
            CheckImage.Tick += CheckImage_Tick;
        }

        private void CheckImage_Tick (object sender, EventArgs e) {
            // 用於修正滑鼠移動停止時，圖形會消失的問題
            CheckImage.Stop ();
            DrawingArea.DrawRectangle (pen, new Rectangle (_MouseDown.X, _MouseDown.Y, DrawingPoints[DrawingPoints.Count - 1].X - _MouseDown.X, DrawingPoints[DrawingPoints.Count - 1].Y - _MouseDown.Y));
        }

        #region 滑鼠畫圖
        private void picCanvas_MouseDown (object sender, MouseEventArgs e) {
            IsMouseDown = true; // 滑鼠被按下後設定旗標值。
            btnExist.Visible = !IsMouseDown;

            _MouseDown = e.Location;
            picCanvas.Image = PanImage;

            DrawingPoints.Add (_MouseDown);
            DrawingPoints.Add (_MouseDown);
        }

        private void picCanvas_MouseMove (object sender, MouseEventArgs e) {
            CheckImage.Stop ();
            if (IsMouseDown) // 如果滑鼠被按下
            {
                CheckImage.Start ();
                if (e.X - _MouseDown.X > 0 & e.Y - _MouseDown.Y > 0) {
                    picCanvas.Image = PanImage;
                    DrawingPoints.Add (e.Location);
                    DrawingArea.DrawRectangle (pen, new Rectangle (_MouseDown.X, _MouseDown.Y, e.X - _MouseDown.X, e.Y - _MouseDown.Y));
                } else if (e.X - _MouseDown.X > 0) {
                    picCanvas.Image = PanImage;
                    DrawingPoints.Add (e.Location);
                    DrawingArea.DrawLine (pen, _MouseDown, new Point (e.X, _MouseDown.Y));
                } else if (e.Y - _MouseDown.Y > 0) {
                    picCanvas.Image = PanImage;
                    DrawingPoints.Add (e.Location);
                    DrawingArea.DrawLine (pen, _MouseDown, new Point (_MouseDown.X, e.Y));
                }

                if (e.X - DrawingPoints[DrawingPoints.Count - 2].X < 0 | e.Y - DrawingPoints[DrawingPoints.Count - 2].Y < 0)
                    picCanvas.Image = PanImage;
            }
        }

        private void picCanvas_MouseUp (object sender, MouseEventArgs e) {
            IsMouseDown = false; // 滑鼠已經沒有被按下了。
            btnExist.Visible = !IsMouseDown;
        }
        #endregion

        private void btnExist_Click (object sender, EventArgs e) {
            this.Close ();
        }
    }
}