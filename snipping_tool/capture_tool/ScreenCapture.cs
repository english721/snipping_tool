using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using capture_tool.Win32Api;

namespace capture_tool.ScreenCapture
{
    class ScreenCapture
    {
        
        
        public static BitmapSource CaptureRegion(int x, int y, int width, int height, bool addToClipboard)
        {

            return CaptureRegion(User32.GetDesktopWindow(), x, y, width, height, addToClipboard);
            
        }

        public static BitmapSource CaptureRegion(
            IntPtr hWnd, int x, int y, int width, int height, bool addToClipboard)
        {
            IntPtr sourceDC = IntPtr.Zero;
            IntPtr targetDC = IntPtr.Zero;
            IntPtr compatibleBitmapHandle = IntPtr.Zero;
            BitmapSource bitmap = null;

            try
            {

                // gets the main desktop and all open windows
                sourceDC = User32.GetDC(User32.GetDesktopWindow());
                targetDC = Gdi32.CreateCompatibleDC(sourceDC);

                // create a bitmap compatible with our target DC
                compatibleBitmapHandle = Gdi32.CreateCompatibleBitmap(sourceDC, width, height);

                // gets the bitmap into the target device context
                Gdi32.SelectObject(targetDC, compatibleBitmapHandle);

                // copy from source to destination
                Gdi32.BitBlt(targetDC, 0, 0, width, height, sourceDC, x, y, Gdi32.SRCCOPY);

                // Here's the WPF glue to make it all work. It converts from an
                // hBitmap to a BitmapSource. Love the WPF interop functions
                bitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    compatibleBitmapHandle, IntPtr.Zero, Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                if (addToClipboard)
                {
                    // Clipboard.SetImage(bitmap); // high memory usage for large images
                    IDataObject data = new DataObject();
                    data.SetData(DataFormats.Dib, bitmap, false);
                    Clipboard.SetDataObject(data, false);
                }

            }
            catch (Exception ex)
            {
                throw new ScreenCaptureException(string.Format("Error capturing region {0}, {1}, {2}, {3}", x, y, width, height), ex);
            }
            finally
            {
                Gdi32.DeleteObject(compatibleBitmapHandle);

                User32.ReleaseDC(IntPtr.Zero, sourceDC);
                User32.ReleaseDC(IntPtr.Zero, targetDC);
            }
            return bitmap;
        }

        // 
        // 기존의 CaptureRegion 함수는 직접 x, y값을 인수로 주었음 어떤 기준점을 기반으로 그 x, y 값 만큼 저장했음
        // -> CaptureCoordinate 함수를 통해 전체 스크린샷을 한 화면에서 빨간색 상자로 선택된 x, y 좌표 값 만큼만 저장해야 함. 
        // 전체 스크린샷을 찍는다 + 투명도 => 그 화면 위에서 마우스 cross모양으로 화면의 부분을 선택할 수 있게 한다. => 마우스 다시 돌아오고 캡쳐된 부분만 보여진다. 
    }
}
