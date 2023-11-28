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

namespace capture_tool.ScreenCapture
{
    /// <summary>
    /// CaptureUserControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CaptureUserControl : UserControl
    {
        public CaptureUserControl()
        {
            InitializeComponent();
            ImgCapture.Source = ScreenCapture.CaptureRegion(100, 100, 500, 500, true);

        }
    }
}
