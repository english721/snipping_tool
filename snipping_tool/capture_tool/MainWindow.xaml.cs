using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using capture_tool.Win32Api;



namespace capture_tool.ScreenCapture
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void ToMiniButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToMaxOrNormalButton_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == System.Windows.WindowState.Maximized)
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MakeNewButton_Click(object sender, RoutedEventArgs e)
        {
            ImgCapture.Source = ScreenCapture.CaptureRegion(100, 100, 500, 500, true);
        }

        private void CaptureModeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        
        

        //public void ScreenCapture()
        //{
        //    this.Cursor = Cursors.Cross;

        //    // 주화면의 크기 정보 읽기
        //    int width = (int)SystemParameters.PrimaryScreenWidth;
        //    int height = (int)SystemParameters.PrimaryScreenHeight;

            

        //    // 화면 크기만큼의 Bitmap 생성
        //    using (Bitmap bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
        //    {
        //        // Bitmap 이미지 변경을 위해 Graphics 객체 생성
        //        using (Graphics gr = Graphics.FromImage(bmp))
        //        {
        //            // 화면을 그대로 카피해서 Bitmap 메모리에 저장
        //            gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);
        //        }



        //        // Bitmap 데이터를 파일로 저장
        //        // bmp.Save("test.png", ImageFormat.Png);

        //        // Bitmap 2 BitmapImage
        //        // Image에 캡처한 이미지를 뿌려주기 위해 Bitmap을 BitmapImage로 변환한다.
        //        using (MemoryStream memory = new MemoryStream())
        //        {
        //            bmp.Save(memory, ImageFormat.Bmp);
        //            memory.Position = 0;
        //            BitmapImage bitmapimage = new BitmapImage();
        //            bitmapimage.BeginInit();
        //            bitmapimage.StreamSource = memory;
        //            bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
        //            bitmapimage.EndInit();

        //            ImgCapture.Source = bitmapimage;
        //        }
        //    }
        //}
    }
}
