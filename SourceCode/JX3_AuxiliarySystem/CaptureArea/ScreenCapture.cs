using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace JX3_AuxiliarySystem.CaptureArea {
    public class ScreenCapture {
        public int Zoon_X = 0;
        public int Zoon_Y = 0;

        public int Width;
        public int Height;

        public ScreenCapture () {
            RECT windowRect = new RECT ();
            GetWindowRect (GetDesktopWindow (), ref windowRect);

            Width = windowRect.right - windowRect.left;
            Height = windowRect.bottom - windowRect.top;
        }

        public void PictureCaptureSet (int Zoon_X, int Zoon_Y, int Width, int Height) {
            this.Zoon_X = Zoon_X;
            this.Zoon_Y = Zoon_Y;
            this.Width = Width;
            this.Height = Height;
        }

        public Image CaptureScreen () {
            return CaptureWindow (GetDesktopWindow ());
        }

        public Image CaptureWindow (IntPtr handle) {
            #region 獲取螢幕端口
            IntPtr hdcSrc = GetWindowDC (handle);
            IntPtr hdcDest = CreateCompatibleDC (hdcSrc);

            IntPtr hBitmap = CreateCompatibleBitmap (hdcSrc, Width, Height);
            IntPtr hOld = SelectObject (hdcDest, hBitmap);
            #endregion
            // (Hand , 起始X,起始Y,抓多少X,抓多少Y )
            BitBlt (hdcDest, 0, 0, Width, Height, hdcSrc, Zoon_X, Zoon_Y, SRCCOPY);
            Image img = Image.FromHbitmap (hBitmap);

            return img;
        }

        public void CaptureWindowToFile (IntPtr handle, string filename, ImageFormat format) {
            Image img = CaptureWindow (handle);
            img.Save (filename, format);
        }

        public void CaptureScreenToFile (string filename, ImageFormat format) {
            Image img = CaptureScreen ();
            img.Save (filename, format);
        }

        #region GDI32 API
        public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
        [DllImport ("gdi32.dll")]
        public static extern bool BitBlt (IntPtr hObject, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hObjectSource,
            int nXSrc, int nYSrc, int dwRop);
        [DllImport ("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap (IntPtr hDC, int nWidth,
            int nHeight);
        [DllImport ("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC (IntPtr hDC);
        [DllImport ("gdi32.dll")]
        public static extern bool DeleteDC (IntPtr hDC);
        [DllImport ("gdi32.dll")]
        public static extern bool DeleteObject (IntPtr hObject);
        [DllImport ("gdi32.dll")]
        public static extern IntPtr SelectObject (IntPtr hDC, IntPtr hObject);
        #endregion

        #region User32 API
        [StructLayout (LayoutKind.Sequential)]
        public struct RECT {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport ("user32.dll")]
        public static extern IntPtr GetDesktopWindow ();
        [DllImport ("user32.dll")]
        public static extern IntPtr GetWindowDC (IntPtr hWnd);
        [DllImport ("user32.dll")]
        public static extern IntPtr ReleaseDC (IntPtr hWnd, IntPtr hDC);
        [DllImport ("user32.dll")]
        public static extern IntPtr GetWindowRect (IntPtr hWnd, ref RECT rect);
        #endregion
    }
}