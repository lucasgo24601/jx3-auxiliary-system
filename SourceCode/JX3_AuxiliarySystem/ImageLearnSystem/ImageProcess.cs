using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;

namespace JX3_AuxiliarySystem.ImageLearnSystem {
    public class ImageProcess {
        public ImageProcess () {

        }

        #region GrayByPixels
        public Bitmap GrayByPixels_LowPrecision (Image bmpobj) {
            ColorMatrix cm = new ColorMatrix (new float[][] {
                new float[] { 0.30f, 0.30f, 0.30f, 0.00f, 0.00f },
                    new float[] { 0.59f, 0.59f, 0.59f, 0.00f, 0.00f },
                    new float[] { 0.11f, 0.11f, 0.11f, 0.00f, 0.00f },
                    new float[] { 0.00f, 0.00f, 0.00f, 1.00f, 0.00f },
                    new float[] { 0.00f, 0.00f, 0.00f, 0.00f, 1.00f }
            });
            ImageAttributes ia = new ImageAttributes ();
            ia.SetColorMatrix (cm);

            Bitmap bitmap = new Bitmap (bmpobj.Width, bmpobj.Height, bmpobj.PixelFormat);
            Graphics g = Graphics.FromImage (bitmap);
            Rectangle rect = new Rectangle (0, 0, bitmap.Width, bitmap.Height);
            g.DrawImage (bmpobj, rect, 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, ia);
            return bitmap;
        }

        public Bitmap GrayByPixels_HightPrecision (Bitmap bmpobj) {
            for (int i = 0; i < bmpobj.Height; i++)
                for (int j = 0; j < bmpobj.Width; j++) {
                    int tmpValue = GetGrayNumColor (bmpobj.GetPixel (j, i));
                    bmpobj.SetPixel (j, i, Color.FromArgb (tmpValue, tmpValue, tmpValue));
                }
            return bmpobj;
        }

        private int GetGrayNumColor (Color posClr) {
            // http://atlaboratary.blogspot.com/2013/08/rgb-g-rey-l-gray-r0.html
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }
        #endregion

        public Bitmap ClearPicBorder (Bitmap bmpobj, int borderWidth) {
            // 把特定的borderWidth範圍設為空白
            for (int i = 0; i < bmpobj.Height; i++)
                for (int j = 0; j < bmpobj.Width; j++)
                    if (i < borderWidth || j < borderWidth || j > bmpobj.Width - 1 - borderWidth || i > bmpobj.Height - 1 - borderWidth)
                        bmpobj.SetPixel (j, i, Color.FromArgb (255, 255, 255));

            return bmpobj;
        }

        public Bitmap[] GetSplitImg (Bitmap _bitmap, int row, int col, double CotPercent) {
            // 將一張圖切開成多張圖
            double singW = _bitmap.Width / row * CotPercent * 0.01;
            double singH = _bitmap.Height / col * CotPercent * 0.01;
            Bitmap[] arrmap = new Bitmap[row * col];
            Rectangle rect;
            for (int i = 0; i < col; i++)
                for (int j = 0; j < row; j++) {
                    rect = new Rectangle (Convert.ToInt32 (j * singW), Convert.ToInt32 (i * singH), Convert.ToInt32 (singW), Convert.ToInt32 (singH));
                    arrmap[i * row + j] = _bitmap.Clone (rect, _bitmap.PixelFormat);
                }

            return arrmap;
        }

        public string GetSingleBmpCode (Bitmap singlepic, int dgGrayValue) {
            string code = "";
            for (int posy = 0; posy < singlepic.Height; posy++)
                for (int posx = 0; posx < singlepic.Width; posx++) {
                    Color piexl = singlepic.GetPixel (posx, posy);
                    if (piexl.R < dgGrayValue)
                        code += "1";
                    else
                        code += "0";
                }
            return code;
        }

        #region 將以解碼的文字串，拆分成 行模式 or 列模式 
        public List<string> SplitImage_Row (string Source, char SignUp, char SignDown, bool IsChinese) {
            List<string> SingelImage_StringRow = new List<string> ();

            string[] Decodes = Source.Split ('\n');
            string SingleCode = "";
            for (int i = 0; i < Decodes.Length; i++)
                if (Decodes[i].Contains (SignUp.ToString ()))
                    SingleCode += Decodes[i];
                else if (i > 0 & i < Decodes.Length - 1) {
                if (Decodes[i - 1].Contains (SignUp.ToString ()) & Decodes[i + 1].Contains (SignUp.ToString ()))
                    SingleCode += Decodes[i];
                else if (SingleCode.Length > 0) {
                    SingelImage_StringRow.Add (SingleCode);
                    SingleCode = "";
                }
            } else if (SingleCode.Length > 0) {
                SingelImage_StringRow.Add (SingleCode);
                SingleCode = "";
            }

            return SingelImage_StringRow;
        }
        public List<string> SplitImage_Column (string Source, char Sign) {
            List<int> Space = new List<int> (); // 紀錄空白間隔的位置
            List<string> SingelImage_StringCol = new List<string> (); // 紀錄分隔後的"圖形字元" 
            string[] Columns = Source.Split ('\n');

            Space.Add (0);
            #region 尋找間隔位置，並記錄下來
            for (int x = 0; x < Columns[0].Length; x++) {
                int Count = 0;
                for (int y = 0; y < Columns.Length - 1; y++) {
                    if (Columns[y][x] == Sign | Columns[y].Length < x)
                        break;
                    if (++Count == Columns.Length - 1)
                        Space.Add (x);
                }
            }
            #endregion
            Space.Add (Space[Space.Count - 1]);

            #region 依照間隔位置進行分離
            for (int i = 0; i < Space.Count - 2; i++) {
                string SingelImage = "";
                for (int y = 0; y < Columns.Length - 1; y++) {
                    for (int x = Space[i]; x < Space[i + 1]; x++)
                        SingelImage += Columns[y][x];

                    SingelImage += '\r';
                    SingelImage += '\n';
                }

                if (SingelImage.Contains (Sign))
                    SingelImage_StringCol.Add (SingelImage);

            }
            #endregion

            return SingelImage_StringCol;
        }
        #endregion

        #region 依照RGB上下限進行解析，將其圖片解析成二位元的文字串
        private void DetermineRGB (ref StringBuilder code, int Value, int RGB, bool IsGreater, char SignUp, char SignDown) {
            if (IsGreater) {
                if (RGB > Value)
                    code.Append (SignUp);
                else
                    code.Append (SignDown);
            } else {
                if (RGB < Value)
                    code.Append (SignUp);
                else
                    code.Append (SignDown);
            }
        }
        public string Decode_Orde (Bitmap bitImage, bool IsPositive, char SignUp, char SignDown, int KeyValue, bool IsGreater) {
            StringBuilder code = new StringBuilder ();
            if (IsPositive)
                for (int i = 0; i < bitImage.Height; i++) {
                    for (int j = 0; j < bitImage.Width; j++) {
                        int R = bitImage.GetPixel (j, i).R;
                        int G = bitImage.GetPixel (j, i).G;
                        int B = bitImage.GetPixel (j, i).B;

                        DetermineRGB (ref code, KeyValue, R + G + B, IsGreater, SignUp, SignDown);
                    }
                    code.Append ('\r');
                    code.Append ('\n');
                }
            else
                for (int i = 0; i < bitImage.Width; i++) {
                    for (int j = 0; j < bitImage.Height; j++) {
                        int R = bitImage.GetPixel (i, j).R;
                        int G = bitImage.GetPixel (i, j).G;
                        int B = bitImage.GetPixel (i, j).B;

                        DetermineRGB (ref code, KeyValue, R + G + B, IsGreater, SignUp, SignDown);
                    }
                    code.Append ('\r');
                    code.Append ('\n');
                }
            return code.ToString ();
        }
        #endregion

        public void Fix_High (Bitmap bitImage, out int Fix_Y, out int Fix_H, char SignUp, char SignDown, int KeyValue, bool IsGreater) {
            Fix_Y = Fix_H = 0;

            // 先獲取正向的圖形解碼2Bit組合
            string[] temp = Decode_Orde (bitImage, true, SignUp, SignDown, KeyValue, IsGreater).Split ('\n');

            for (int i = 0; i < temp.Length; i++)
                if ((temp[i].Count (p => p == SignUp) > 0) == false & Fix_H == 0)
                    Fix_Y++; // 如果該行全是空白，則累加Y應該向下偏移數值
                else if (temp[i].Count (p => p == SignUp) > 0)
                Fix_H++; // 如果該行含有意義資料，則累加H計算這群字元的高度

        }

        public void Fix_Width (Bitmap bitImage, out int Fix_X, out int Fix_W, char SignUp, char SignDown, int KeyValue, bool IsGreater) {
            int Count = 0;
            int ColSpace = 0;
            Fix_X = Fix_W = 0;

            // 先獲取反向的圖形解碼2Bit組合
            string[] temp = Decode_Orde (bitImage, false, SignUp, SignDown, KeyValue, IsGreater).Split ('\n');

            for (int i = 0; i < temp.Length; i++)
                if ((temp[i].Count (p => p == SignUp) > 0) == false & Fix_W == 0)
                    Fix_X++; // 如果該行全是空白，則累加X應該向右偏移數值
                else if (temp[i].Count (p => p == SignUp) > 0) {
                if (Count == 2) // 2為如果字元與字元之間有兩行空白的話，將其視為間隔
                {
                    ColSpace++;
                    Count = 0;
                } else if (Count > 2) {
                    Fix_W += (Count - 2);
                    ColSpace++;
                    Count = 0;
                }

                Fix_W++; // 如果該行含有意義資料，則累加W計算這群字元的寬度
            } else
                Count++; // 此處Count為計算字元之間的空白間隔

            Fix_W += ColSpace * 2;
        }
    }
}